namespace ComicPro2019.HeThong
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Grid;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class FrmBackupData : XtraForm
    {

        public FrmBackupData()
        {
            InitializeComponent();
        }


        public string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        public string ToPrettySize(double value, int decimalPlaces = 0)
        {
            long oneKb = 1024;
            long oneMb = oneKb * 1024;
            long oneGb = oneMb * 1024;
            long oneTb = oneGb * 1024;
            var asTb = Math.Round(value / oneTb, decimalPlaces);
            var asGb = Math.Round(value / oneGb, decimalPlaces);
            var asMb = Math.Round(value / oneMb, decimalPlaces);
            var asKb = Math.Round(value / oneKb, decimalPlaces);
            string chosenValue = asTb > 1 ? string.Format("{0}TB", asTb)
                : asGb > 1 ? string.Format("{0} GB", asGb)
                : asMb > 1 ? string.Format("{0} MB", asMb)
                : asKb > 1 ? string.Format("{0} KB", asKb)
                : string.Format("{0} Byte", Math.Round(value, decimalPlaces));
            return chosenValue;
        }

        private void FrmBackupData_Load(object sender, EventArgs e)
        {
            progress_upload.Visibility = BarItemVisibility.Never;
            bar_status_download.Visibility = BarItemVisibility.Never;
            GetLoadFileBackup();
        }

        public void GetLoadFileBackup()
        {
            var filters = new[] { "bak" };
            var files = GetFilesFrom(Application.StartupPath + "\\backup\\", filters, true).ToList();
            var backupInfos = new List<FileBackupInfo>();
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(file);
                long s1 = f.Length;
                var obj = FileVersionInfo.GetVersionInfo(file);
                var fileBackupInfo = new FileBackupInfo();
                fileBackupInfo.FileName = Path.GetFileName(obj.FileName);
                fileBackupInfo.Size = ToPrettySize(s1);
                fileBackupInfo.DateFile = File.GetLastWriteTime(file);
                fileBackupInfo.Description = obj.FileName;
                backupInfos.Add(fileBackupInfo);
            }
            dgv_backup.DataSource = backupInfos;
        }

        public class FileBackupInfo
        {
            public string FileName { set; get; }
            public string Size { set; get; }
            public DateTime DateFile { set; get; }
            public string Description { set; get; }
        }

        internal string FileNameBak;
        internal string FullPathSave;
        internal bool IsRestore;
        public void BackupAndRestore(bool isRestore)
        {
            IsRestore = isRestore;
            progress_upload.Visibility = BarItemVisibility.Always;
            bar_status_download.Visibility = BarItemVisibility.Always;
            FileNameBak = $"{ConfigDatabase.DATABASE}" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            btn_backup.Enabled = false;
            FullPathSave = xtraSaveFileDialog1.FileName + ".bak";
            Task.Factory.StartNew(() =>
             {

                 Server dbServer = new Server(new ServerConnection(ConfigDatabase.IP_SERVER_NAME, ConfigDatabase.USER_NAME_DB, ConfigDatabase.PASSWORD_DB));
                 Backup bkpDbFull = new Backup();
                 bkpDbFull.Action = BackupActionType.Database;
                 bkpDbFull.Database = ConfigDatabase.DATABASE;
                 bkpDbFull.Devices.AddDevice(Application.StartupPath + "\\backup\\" + FileNameBak, DeviceType.File);
                 bkpDbFull.BackupSetName = "ComicPro2019 database Backup";
                 bkpDbFull.BackupSetDescription = "ComicPro2019 database - Full Backup";
                 bkpDbFull.ExpirationDate = DateTime.Today.AddDays(10);
                 //NÉN FILE BACKUP
                 bkpDbFull.CompressionOption = BackupCompressionOptions.On;

                 bkpDbFull.Initialize = false;

                 bkpDbFull.PercentCompleteNotification = 1; // cứ 1% thì xuất hiện procress
                 bkpDbFull.PercentComplete += CompletionStatusInPercent;
                 bkpDbFull.Complete += Backup_Completed;

                 BeginInvoke(new Action(() =>
                 {
                     progress_upload.Visibility = BarItemVisibility.Always;
                 }));
                 bkpDbFull.SqlBackup(dbServer);
             });
        }


        private void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            BeginInvoke(new Action(() =>
            {
                progress_upload.EditValue = args.Percent;
                bar_status_download.Caption = @"Đang backup database {ConfigDatabase.DATABASE} tại Server: {ConfigDatabase.IP_SERVER_NAME}: {args.Percent}% ";
                progress_upload.Visibility = BarItemVisibility.Never;
            }));
        }


        private void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
            BeginInvoke(new Action(() =>
            {
                alertControl1.Show(this, "Thông báo", "Đã backup database thành công, đang download file...");
            }));
        }

        private void btn_backup_ItemClick(object sender, ItemClickEventArgs e)
        {
            BackupAndRestore(false);
            btn_lammoi_ItemClick(sender, e);
        }

        private void btn_restore_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraOpenFileDialog dialog = new XtraOpenFileDialog();
            dialog.Title = @"Restore Database {ConfigDatabase.DATABASE}";
            dialog.Filter = @"Backup File | *.bak| All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.GetFullPath(dialog.FileName);

                var dt = ExecuteQuery($@"RESTORE HEADERONLY FROM DISK = '{filePath}'");
                string backupSize = FormatSize(long.Parse(dt.Rows[0]["BackupSize"].ToString()));
                string compressedBackupSize = FormatSize(long.Parse(dt.Rows[0]["CompressedBackupSize"].ToString()));

                //string databaseCreationDate = dt.Rows[0]["DatabaseCreationDate"].ToString();
                string backupDescription = dt.Rows[0]["BackupDescription"].ToString();
                string backupStartDate = dt.Rows[0]["BackupStartDate"].ToString();
                string backupFinishDate = dt.Rows[0]["BackupFinishDate"].ToString();


                string databaseName = dt.Rows[0]["DatabaseName"].ToString();
                string serverName = dt.Rows[0]["ServerName"].ToString();
                string recoveryModel = dt.Rows[0]["RecoveryModel"].ToString();
                string collation = dt.Rows[0]["Collation"].ToString();

                string message = $@"Server Name: {serverName + Environment.NewLine} <b><color=255,0,0>Database Name: {databaseName + Environment.NewLine}</color></b> BackupDescription: {backupDescription + Environment.NewLine} <b><color=blue>Backup Size: {backupSize + Environment.NewLine}</color></b> Compress Backup Size: {compressedBackupSize + Environment.NewLine} Recovery Model: {recoveryModel + Environment.NewLine} Collation: {collation + Environment.NewLine} Backup Start Date: {backupStartDate + Environment.NewLine} Backup Finish Date: {backupFinishDate}";

                var xtraMess = XtraMessageBox.Show(message, "Bạn có chắc chắn muốn Restore Database không?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, DefaultBoolean.True);
                if (xtraMess == DialogResult.Yes)
                {
                    RestoreDataBase(filePath);
                }
            }
        }

        public void RestoreDataBase(string fileBak)
        {
            progress_upload.EditValue = 0;
            progress_upload.Visibility = BarItemVisibility.Always;
            bar_status_download.Visibility = BarItemVisibility.Always;
            btn_restore.Enabled = false;
            try
            {
                string strConnection = $"Server={ConfigDatabase.IP_SERVER_LOCAL};Database={ConfigDatabase.DATABASE};Trusted_Connection=True;";
                var conn = new SqlConnection(strConnection);
                //Server dbServer = new Server(new ServerConnection(serverLocal, configDatabase.USER_NAME_DB, configDatabase.PASSWORD_DB));
                Server dbServer = new Server(new ServerConnection(conn));
                // Kill all processes
                Restore dbRestore = new Restore { Database = ConfigDatabase.DATABASE, Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false };
                dbServer.KillAllProcesses(dbRestore.Database);
                // Set single-user mode
                Database db = dbServer.Databases[dbRestore.Database];
                db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                db.Alter(TerminationClause.RollbackTransactionsImmediately);

                dbRestore.Devices.AddDevice(fileBak, DeviceType.File);
                dbRestore.PercentCompleteNotification = 1;
                dbRestore.PercentComplete += DbRestore_PercentComplete;
                dbRestore.Complete += DbRestore_Complete;
                dbRestore.SqlRestoreAsync(dbServer);
            }
            catch (Exception ex)
            {
                alertControl1.Show(this, "Thông báo", $"Error: => {ex.Message}");
            }
        }

        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                //bar_status_download.Visibility = BarItemVisibility.Never;
                BeginInvoke(new Action(() =>
                {
                    //  btn_backup_restore.Enabled = true;
                    progress_upload.Visibility = BarItemVisibility.Never;
                    bar_status_download.Caption = e.Error.Message;
                    alertControl1.Show(this, "Thông báo", $"Đã Restore Database to {ConfigDatabase.IP_SERVER_LOCAL} thành công!");
                    bar_status_download.Visibility = BarItemVisibility.Never;
                }));
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            string strConnection = $"Server={ConfigDatabase.IP_SERVER_LOCAL};Database={ConfigDatabase.DATABASE};Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progress_upload.BeginUpdate();
                progress_upload.EditValue = e.Percent;
                progress_upload.EndUpdate();
                bar_status_download.Caption = @"Đang Restore database {ConfigDatabase.DATABASE} - Server: {ConfigDatabase.IP_SERVER_LOCAL} : {e.Percent}%";
            }));
        }

        internal static readonly string[] Suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        public static string FormatSize(long bytes)
        {
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, Suffixes[counter]);
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (e.Column == col_restore)
            {

                string filePath = Path.GetFullPath(Application.StartupPath + "\\backup\\" + gridView1.GetRowCellValue(i, "FileName"));

                var dt = ExecuteQuery($@"RESTORE HEADERONLY FROM DISK = '{filePath}'");
                string backupSize = FormatSize(long.Parse(dt.Rows[0]["BackupSize"].ToString()));
                string compressedBackupSize = FormatSize(long.Parse(dt.Rows[0]["CompressedBackupSize"].ToString()));

                string databaseCreationDate = dt.Rows[0]["DatabaseCreationDate"].ToString();
                string backupDescription = dt.Rows[0]["BackupDescription"].ToString();
                string backupStartDate = dt.Rows[0]["BackupStartDate"].ToString();
                string backupFinishDate = dt.Rows[0]["BackupFinishDate"].ToString();


                string databaseName = dt.Rows[0]["DatabaseName"].ToString();
                string serverName = dt.Rows[0]["ServerName"].ToString();
                string recoveryModel = dt.Rows[0]["RecoveryModel"].ToString();
                string collation = dt.Rows[0]["Collation"].ToString();

                string message = $@"Server Name: {serverName + Environment.NewLine} <b><color=255,0,0>Database Name: {databaseName + Environment.NewLine}</color></b> BackupDescription: {backupDescription + Environment.NewLine} <b><color=blue>Backup Size: {backupSize + Environment.NewLine}</color></b> Compress Backup Size: {compressedBackupSize + Environment.NewLine} Recovery Model: {recoveryModel + Environment.NewLine} Collation: {collation + Environment.NewLine} Backup Start Date: {backupStartDate + Environment.NewLine} Backup Finish Date: {backupFinishDate}";

                var xtraMess = XtraMessageBox.Show(message, "Bạn có chắc chắn muốn Restore Database không?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, DefaultBoolean.True);
                if (xtraMess == DialogResult.Yes)
                {
                    RestoreDataBase(filePath);
                }
            }
        }

        private void btn_lammoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetLoadFileBackup();
        }
    }
}
