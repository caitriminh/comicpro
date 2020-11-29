using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraTab;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmDanhMuc : XtraForm
    {
        public FrmDanhMuc()
        {
            InitializeComponent();
            fTPHelper = new FTPHelper("ftp://triminh.xyz/", "gv1mpaj216", "Ue77uPjhH3");
            // Đánh số thứ tự
            gridView1.CustomDrawRowIndicator += (s, e) => { GridviewHelper.GridView_CustomDrawRowIndicator(s, e, dgv_danhmuc, gridView1); };
            // thêm menu vào gridview
            gridView1.PopupMenuShowing += (s, e) => { GridviewHelper.AddFontAndColortoPopupMenuShowing(s, e, dgv_danhmuc, this.Name); };
            this.Shown += (s, e) =>
            {
                GridviewHelper.SaveAndRestoreLayout(dgv_danhmuc, this.Name);
            };
        }

        public FTPHelper fTPHelper;
        public async void GetDanhMuc()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var listTentruyen = await ExecSQL.ExecProcedureDataAsync<TenTruyen>("pro_get_tentruyen", new { option = 1 });

            dgv_danhmuc.DataSource = listTentruyen;
            lbl_matua.DataBindings.Clear();
            lbl_matruyen.DataBindings.Clear();
            cbo_tua.DataBindings.Clear();

            lbl_matua.DataBindings.Add("text", listTentruyen, "matua");
            lbl_matruyen.DataBindings.Add("text", listTentruyen, "matruyen");
            cbo_tua.DataBindings.Add("editvalue", listTentruyen, "matua");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;

        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            ComicPro.StrMaTua = lbl_matua.Text;
            FrmThemDanhMuc frm = new FrmThemDanhMuc();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetDanhMuc();
        }

        private void btn_luu_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageDefault("Không có dòng dữ liệu nào thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var tentruyen = gridView1.GetRow(item) as TenTruyen;
                if (tentruyen != null)
                {
                    ExecSQL.ExecProcedureNonData("pro_update_tentruyen", new { tentruyen.matruyen, tentruyen.tentruyen, tentruyen.maloaibia, tentruyen.madvt, tentruyen.tap, tentruyen.giabia, tentruyen.ngayxuatban, tentruyen.ghichu, tentruyen.nguoitd2, tentruyen.sotrang });
                    dem += 1;
                }
            }
            modifined.Clear();
            GetDanhMuc();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
        }

        private void btn_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var x = Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_ct_phieunhapxuat WHERE matruyen='{gridView1.GetRowCellValue(i, "matruyen")}'"));
            var y = Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_tonkho WHERE matruyen='{gridView1.GetRowCellValue(i, "matruyen")}'"));
            if (x > 0 || y > 0)
            {
                Form1.Default.ShowMessageError($"Mã tựa truyện ({gridView1.GetRowCellValue(i, "matruyen")} - {gridView1.GetRowCellValue(i, "tentruyen")}) đã được sử dụng.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên truyện ({gridView1.GetRowCellValue(i, "tentruyen")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_tentruyen WHERE matruyen='{gridView1.GetRowCellValue(i, "matruyen")}'");
            Form1.Default.ShowMessageSuccess($"Đã xóa tên truyện ({gridView1.GetRowCellValue(i, "tentruyen")}) thành công.");
            gridView1.DeleteRow(i);

        }

        public async void GetTuaTruyen2()
        {
            var listTuaTruyen = await ExecSQL.ExecQueryDataAsync<TuaTruyen>("SELECT matua, tuatruyen FROM dbo.tbl_tuatruyen ORDER BY tuatruyen");
            cbo_tua2.DataSource = listTuaTruyen;
            cbo_tua2.DisplayMember = "tuatruyen";
            cbo_tua2.ValueMember = "matua";
        }

        public async void GetLoaiBia()
        {
            var listLoaiBia = await ExecSQL.ExecQueryDataAsync<LoaiBia>("SELECT id, loaibia FROM dbo.tbl_loaibia");
            cbo_loaibia.DataSource = listLoaiBia;
            cbo_loaibia.DisplayMember = "loaibia";
            cbo_loaibia.ValueMember = "id";
        }

        public async void GetDonViTinh()
        {
            var listDonViTinh = await ExecSQL.ExecQueryDataAsync<DonViTinh>("SELECT id, donvitinh FROM dbo.tbl_donvitinh");
            cbo_donvitinh.DataSource = listDonViTinh;
            cbo_donvitinh.DisplayMember = "donvitinh";
            cbo_donvitinh.ValueMember = "id";
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "danhmuc")
            {
                GetDanhMuc();
            }
        }

        private UserCredential credential;
        private List<int> modifined;
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetLoaiBia();
            GetDonViTinh();
            GetDanhMuc();
            GetTuaTruyen2();
            //////////////////////////
            col_googledrive.Visible = false;
            col_upload.Visible = false;
            col_progress.Visible = false;
            ////////////////////
            groupControl1.Hide();
            splitterControl1.Hide();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); };
        }

        private void btn_excel_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucTenTruyen_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var selectedRow = gridView1.GetSelectedRows();
                var joinMaTruyen = string.Join(",",
                    from r in selectedRow
                    where gridView1.IsDataRow(Convert.ToInt32(r))
                    select gridView1.GetRowCellValue(Convert.ToInt32(r), "matruyen"));

                var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_tentruyen", new { option = 3, matruyen = joinMaTruyen });
                ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
            }
        }

        public static Image CreateThumbnailImageByOriginImage(string url, int width = 220, int height = 280)
        {
            Image image = Image.FromFile(url);
            Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
            image.Dispose();
            return thumb;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public Image ReadImageToStream(string url)
        {
            //FileStream byteImg = new FileStream(url, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            var arrbyte = File.ReadAllBytes(url);
            using (Stream stream = new MemoryStream(arrbyte))
            {
                //byteImg.CopyTo(stream);
                //byteImg.Dispose();
                Image image = System.Drawing.Image.FromStream(stream);
                stream.Dispose();
                return image;
            }
        }


        private static string ApplicationName = "Comic Pro 2020";
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (e.Column == col_themhinh)
            {
                xtraOpenFileDialog1.Filter = @"Image files (*.jpg)|*.jpg|Image files(*.png)|*.png|All files (*.*)|*.*";
                xtraOpenFileDialog1.FileName = "Chọn file cần import";
                if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strNewDirPathOrigin = Application.StartupPath + "\\img\\origin\\" + gridView1.GetRowCellValue(i, "matua");
                    //Tạo đường dẫn mới
                    if (!Directory.Exists(strNewDirPathOrigin))
                    {
                        Directory.CreateDirectory(strNewDirPathOrigin);
                    }

                    File.Copy(xtraOpenFileDialog1.FileName, strNewDirPathOrigin + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".jpg", true);

                    string strNewDirPathThumb = Application.StartupPath + "\\img\\thumb\\" + gridView1.GetRowCellValue(i, "matua");
                    if (!Directory.Exists(strNewDirPathThumb))
                    {
                        Directory.CreateDirectory(strNewDirPathThumb);
                    }
                    var img = CreateThumbnailImageByOriginImage(xtraOpenFileDialog1.FileName);
                    Encoder myEncoder = Encoder.Quality;
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 80L);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    img.Save(strNewDirPathThumb + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".jpg", jpgEncoder, myEncoderParameters);
                    //Tao folder
                    var folder = "httpdocs/img/thumb/" + lbl_matua.Text;
                    fTPHelper.createDirectory(folder);
                    //UploadFileToFTP(lbl_matua.Text, lbl_matruyen.Text, Application.StartupPath + "\\img\\thumb\\" + gridView1.GetRowCellValue(i, "matua") + "\\" + lbl_matruyen.Text + ".jpg");
                    var remotefile = "httpdocs/img/thumb/" + lbl_matua.Text + "/" + lbl_matruyen.Text + ".jpg";
                    var localfile = strNewDirPathThumb + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".jpg";
                    fTPHelper.upload(remotefile, localfile);
                    pictureEdit1.Image = ReadImageToStream(strNewDirPathOrigin + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".jpg");
                    ExecSQL.ExecQueryNonData($"UPDATE dbo.tbl_tentruyen SET filehinh='{xtraOpenFileDialog1.FileName}' WHERE matruyen='{gridView1.GetRowCellValue(i, "matua")}'");
                }
            }
            else if (e.Column == col_pdf)
            {
                ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + gridView1.GetRowCellValue(i, "matua") + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".pdf";
                if (File.Exists(ComicPro.StrDuongDanPdf))
                {
                    ComicPro.StrCaption = gridView1.GetRowCellValue(i, "tentruyen").ToString();
                    var f = new FrmReadComic();
                    f.Show();
                }
                else
                {
                    //Thêm file mới
                    xtraOpenFileDialog1.Filter = @"PDF files |*.pdf";
                    xtraOpenFileDialog1.FileName = "Chọn file cần import";
                    if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string strNewDirPath = Application.StartupPath + "\\pdf\\" + gridView1.GetRowCellValue(i, "matua");
                        //Tạo đường dẫn mới
                        if (!Directory.Exists(strNewDirPath))
                        {
                            Directory.CreateDirectory(strNewDirPath);
                        }
                        try
                        {
                            File.Copy(xtraOpenFileDialog1.FileName, strNewDirPath + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".pdf", true);
                            ExecSQL.ExecQueryNonData($"UPDATE dbo.tbl_tentruyen SET filetruyen=1 WHERE matruyen='{gridView1.GetRowCellValue(i, "matruyen").ToString()}'");
                            ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + gridView1.GetRowCellValue(i, "matua") + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".pdf";
                            GetDanhMuc();
                            var f = new FrmReadComic();
                            f.Show();
                        }
                        catch (Exception exception)
                        {
                            XtraMessageBox.Show(exception.Message, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            }
            else if (e.Column == col_upload)
            {
                if (gridView1.GetRowCellValue(i, "uploadfile").ToString() == "Not upload")
                {
                    Form1.Default.ShowMessageWarning($"File {gridView1.GetRowCellValue(i, "tentruyen")} không tồn tại.");
                    return;
                }

                if (gridView1.GetRowCellValue(i, "uploadfile").ToString() == "Đã upload")
                {
                    Form1.Default.ShowMessageWarning($"File {gridView1.GetRowCellValue(i, "tentruyen")} đã được upload lên google drive.");
                    return;
                }
                ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + gridView1.GetRowCellValue(i, "matua") + "\\" + gridView1.GetRowCellValue(i, "matruyen") + ".pdf";
                progressBarControl3.Visible = true;
                lbl_upload.Visible = true;
                lbl_upload.Text = @"Đang upload file lên google drive...";
                UploadFilePdf(gridView1.GetRowCellValue(i, "tuatruyen").ToString(), e.RowHandle);
            }
            else if (e.Column == col_copy)
            {
                ExecSQL.ExecProcedureNonData("pro_copy_tentruyen", new { matruyencu = gridView1.GetRowCellValue(i, "matruyen"), nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
                GetDanhMuc();
            }
        }

        private void UpdateProgressByRowHandle(int rowHandle, string column, string message)
        {
            dgv_Layout.BeginInvoke((Action)(() =>
            {
                gridView1.SetRowCellValue(rowHandle, column, message);
            }));
        }

        public async void UploadFilePdf(string tuatruyen, int rowHandle)
        {
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
            //Folder đã được tạo
            string folderid;
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_tuatruyen WHERE tuatruyen=N'{tuatruyen}' AND LEN(folderid)>0")) > 0)
            {
                folderid = ExecSQL.ExecQuerySacalar($"SELECT folderid FROM dbo.tbl_tuatruyen WHERE tuatruyen=N'{tuatruyen}'").ToString();
            }
            else
            {
                //get folder id by name
                var fileMetadatas = new Google.Apis.Drive.v3.Data.File
                {
                    Name = tuatruyen,
                    MimeType = "application/vnd.google-apps.folder"
                };
                //Lây ID từ google trả về
                var requests = service.Files.Create(fileMetadatas);
                requests.Fields = "id";
                var folder = requests.Execute();
                //Update lại folder id
                ExecSQL.ExecQueryNonData($"UPDATE dbo.tbl_tuatruyen SET folderid='{folder.Id}' WHERE tuatruyen=N'{tuatruyen}'");
                folderid = folder.Id;
            }
            await UploadImage(ComicPro.StrDuongDanPdf, service, folderid, rowHandle);
        }

        private System.Threading.Tasks.Task UploadImage(string path, DriveService service, string folderUpload, int rowHandle)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "application/*";
            fileMetadata.Parents = new List<string>
            {
                folderUpload
            };

            var stream = new FileStream(path, FileMode.Open);
            var maxByte = (int)stream.Length;
            progressBarControl3.Properties.Maximum = maxByte;
            var request = service.Files.Create(fileMetadata, stream, "application/*");

            request.ChunkSize = ResumableUpload.MinimumChunkSize * 2;
            request.ProgressChanged += new Action<IUploadProgress>((s) => OnUploadProgress(s, rowHandle, maxByte)); ;
            request.Fields = "id";
            var task = request.UploadAsync();
            return task;
        }

        private void OnUploadProgress(IUploadProgress progress, int rowHanle, int maxByte)
        {
            switch (progress.Status)
            {
                case UploadStatus.Starting:

                    progressBarControl3.Properties.Minimum = 0;
                    progressBarControl3.EditValue = 0;
                    break;
                case UploadStatus.Completed:
                    progressBarControl3.BeginInvoke(new Action(() =>
                    {
                        UpdateProgressByRowHandle(rowHanle, "progress", "100");
                        UpdateProgressByRowHandle(rowHanle, "uploadfile", "Đã upload");
                        _matruyen = gridView1.GetRowCellValue(rowHanle, "matruyen").ToString();
                        ExecSQL.ExecQueryNonData($"UPDATE dbo.tbl_tentruyen SET fileid=N'Đã hoàn tất' WHERE matruyen='{_matruyen}'");
                        progressBarControl3.EditValue = progressBarControl3.Properties.Maximum;
                        progressBarControl3.Visible = false;
                        lbl_upload.Visible = false;
                    }));
                    break;
                case UploadStatus.Uploading:
                    var percent = Convert.ToDouble(progress.BytesSent) / Convert.ToDouble(maxByte) * 100.0;
                    UpdateProgressByRowHandle(rowHanle, "progress", Convert.ToInt16(percent).ToString());
                    UpdateProgressBar(progress.BytesSent);
                    break;
                case UploadStatus.Failed:
                    XtraMessageBox.Show("Upload failed" + Environment.NewLine + progress.Exception);
                    break;
            }
        }

        private void UpdateProgressBar(long value)
        {
            progressBarControl3.BeginInvoke(new Action(() =>
            {
                progressBarControl3.EditValue = (int)value;

            }));
        }

        private string _matruyen;
        //private void UploadPdf(string path, DriveService service, string folderUpload)
        //{
        //    var fileMetadata = new Google.Apis.Drive.v3.Data.File();
        //    fileMetadata.Name = Path.GetFileName(path);
        //    fileMetadata.MimeType = "application/pdf";
        //    fileMetadata.Parents = new List<string>
        //    {
        //        folderUpload
        //    };

        //    FilesResource.CreateMediaUpload request;
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        request = service.Files.Create(fileMetadata, stream, "application/pdf");
        //        request.Fields = "id";
        //        request.Upload();
        //    }
        //    var file = request.ResponseBody;
        //    //Update file ID;
        //    _busDanhMuc.UpdateFileid(_matruyen, file.Id);
        //    //textBox1.Text += ("File ID: " + file.Id);
        //}

        private static string[] Scopes = { DriveService.Scope.Drive };
        private UserCredential GetCredentials()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, System.IO.FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, "client_secreta.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                //  textBox1.Text = string.Format("Credential file saved to: " + credPath);
            }

            return credential;
        }

        private void lbl_matruyen_TextChanged(object sender, EventArgs e)
        {
            var dt = ExecSQL.ExecProcedureDataFirstOrDefaultAsync<TenTruyen>("pro_get_tentruyen", new { option = 2, matruyen = lbl_matruyen.Text });
            if (dt == null) { return; }
            lbl_tuatruyen.Text = dt.tuatruyen;
            lbl_tentruyen.Text = dt.tentruyen;
            lbl_hinhthuc.Text = dt.loaibia;
            lbl_ngayxuatban.Text = dt.ngayxuatban.ToString();

            lbl_loaitruyen.Text = dt.loaitruyen;
            lbl_tacgia.Text = dt.tacgia;
            lbl_tap.Text = dt.tap.ToString();
            lbl_nhaxuatban.Text = dt.nhaxuatban;
            lbl_xuatxu.Text = dt.quocgia;
            string strNewDirPath = Application.StartupPath + "\\img\\origin\\" + lbl_matua.Text + "\\" + lbl_matruyen.Text + ".jpg";
            if (File.Exists(strNewDirPath))
            {
                pictureEdit1.Image = ReadImageToStream(strNewDirPath);
            }
            else
            {
                pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\img\\origin\\default.jpg");
            }

        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + lbl_matua.Text + "\\" + lbl_matruyen.Text + ".pdf";
            if (File.Exists(ComicPro.StrDuongDanPdf))
            {
                var i = gridView1.FocusedRowHandle;
                ComicPro.StrCaption = gridView1.GetRowCellValue(i, "tentruyen").ToString();
                var f = new FrmReadComic();
                f.Show();
            }
        }


        private void btn_in_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                Form1.Default.ShowMessageWarning("Bạn vui lòng chọn các mã truyện để thực hiện.");
                return;
            }
            string strDuongDan = Application.StartupPath + "\\img\\thumb\\";
            var selectedRow = gridView1.GetSelectedRows();
            var strMatruyen = string.Join(",", from r in selectedRow where gridView1.IsDataRow(Convert.ToInt32(r)) select gridView1.GetRowCellValue(Convert.ToInt32(r), "matruyen"));
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_get_tentruyen", new { option = 2, matruyen = strMatruyen, duongdanfilehinh = strDuongDan });
            ComicPro.Report = 6;
            FrmReport f = new FrmReport();
            f.Show();

        }

        private void btn_danhsach_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                Form1.Default.ShowMessageWarning("Bạn vui lòng chọn các mã truyện để thực hiện.");
                return;
            }
            var selectedRow = gridView1.GetSelectedRows();
            var strMatruyen = string.Join(",", from r in selectedRow where gridView1.IsDataRow(Convert.ToInt32(r)) select gridView1.GetRowCellValue(Convert.ToInt32(r), "matruyen"));
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_get_tentruyen", new { option = 2, matruyen = strMatruyen, duongdanfilehinh = "" });
            ComicPro.Report = 2;
            FrmReport f = new FrmReport();
            f.Show();
        }

        public async void GetLayout(string matua)
        {
            string strDuongDan = Application.StartupPath + "\\img\\thumb\\";
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tentruyen", new { option = 4, duongdanfilehinh = strDuongDan, matua });
            BindingList<PictureObject> list = new BindingList<PictureObject>();
            PictureObject item;
            object b = new object();
            await System.Threading.Tasks.Task.Factory.StartNew(() =>
             {
                 foreach (DataRow drow in dt.Rows)
                 {
                     lock (b)
                     {
                         BeginInvoke(new Action(() =>
                         {
                             if (drow["sohuu"].ToString().ToLower() == "true")
                             {
                                 if (File.Exists(drow["hinhanh"].ToString()))
                                 {
                                     item = new PictureObject(drow["tentruyen"].ToString(), Image.FromFile(drow["hinhanh"].ToString()), drow["tuatruyen"].ToString(), drow["matruyen"].ToString(), drow["matua"].ToString());
                                 }
                                 else
                                 {
                                     item = new PictureObject(drow["tentruyen"].ToString(), Image.FromFile(strDuongDan + "no-image.png"), drow["tuatruyen"].ToString(), drow["matruyen"].ToString(), drow["matua"].ToString());
                                 }
                                 list.Add(item);
                             }
                             else
                             {
                                 if (File.Exists(drow["hinhanh"].ToString()))
                                 {
                                     item = new PictureObject(drow["tentruyen"].ToString(), MakeGrayscale((Bitmap)Image.FromFile(drow["hinhanh"].ToString())), drow["tuatruyen"].ToString(), drow["matruyen"].ToString(), drow["matua"].ToString());
                                 }
                                 else
                                 {
                                     item = new PictureObject(drow["tentruyen"].ToString(), MakeGrayscale((Bitmap)Image.FromFile(strDuongDan + "no-image.png")), drow["tuatruyen"].ToString(), drow["matruyen"].ToString(), drow["matua"].ToString());
                                 }
                                 list.Add(item);
                             }
                         }));
                     }
                 }
             });
            dgv_Layout.DataSource = list;

        }
        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tab_layout)
            {
                groupControl1.Visible = false;
                splitterControl1.Visible = false;
                GetLayout(lbl_matua.Text);
            }
            else
            {
                groupControl1.Visible = true;
                splitterControl1.Visible = true;
            }
        }

        public class PictureObject : INotifyPropertyChanged
        {
            public string Name { get; set; }
            public Image Image { get; set; }
            public string Tuatruyen { get; set; }
            public string Matruyen { get; set; }
            public string Matua { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            //Image noImage;
            public PictureObject(string name, Image url, string tuatruyen, string matruyen, string matua)
            {
                Name = name;
                Image = url;
                Tuatruyen = tuatruyen;
                Matruyen = matruyen;
                Matua = matua;
            }
        }

        private void cbo_tua_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != tab_layout) { return; }
            if (cbo_tua.EditValue != null)
            {
                GetLayout(cbo_tua.EditValue.ToString().Replace(" ", ""));
            }
        }
        public Bitmap MakeGrayscale(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
                new[]
                {
                    new[] {.3f, .3f, .3f, 0, 0},
                    new[] {.59f, .59f, .59f, 0, 0},
                    new[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return newBitmap;
        }

        private void winExplorerView1_ItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            var i = winExplorerView1.FocusedRowHandle;
            ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + (string)winExplorerView1.GetRowCellValue(i, col_matua) + "\\" + (string)winExplorerView1.GetRowCellValue(i, col_matruyen) + ".pdf";
            if (File.Exists(ComicPro.StrDuongDanPdf))
            {
                ComicPro.StrCaption = (string)winExplorerView1.GetRowCellValue(i, col_tentruyen);
                var f = new FrmReadComic();
                f.Show();
            }
            else
            {
                XtraMessageBox.Show("Không tồn tại file.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chk_upload_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chk_upload.Checked)
            {
                credential = GetCredentials();
                col_googledrive.Visible = true;
                col_upload.Visible = true;
                col_progress.Visible = true;
            }
            else
            {
                col_googledrive.Visible = false;
                col_upload.Visible = false;
                col_progress.Visible = false;
            }
        }

        private void chk_thongtin_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chk_thongtin.Checked)
            {
                groupControl1.Show();
                splitterControl1.Show();
            }
            else
            {
                groupControl1.Hide();
                splitterControl1.Hide();
            }
        }

        private void FrmDanhMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UploadFileToFTP(lbl_matua.Text, lbl_matruyen.Text, xtraOpenFileDialog1.FileName);
            }

        }

        private void UploadFileToFTP(string matua, string matruyen, string source)
        {

            //try
            //{
            //string filename = Path.GetFileName(source);
            //string ftpfullpath = "ftp://125.212.221.113/httpdocs/img/thumb/" + matua + "/" + matruyen + ".jpg";
            //FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
            //ftp.Credentials = new NetworkCredential("caitriminhcom", "H6MT9BSYRwJ4");

            //ftp.KeepAlive = true;
            //ftp.UseBinary = true;
            //ftp.Method = WebRequestMethods.Ftp.UploadFile;

            //FileStream fs = File.OpenRead(source);
            //byte[] buffer = new byte[fs.Length];
            //fs.Read(buffer, 0, buffer.Length);
            //fs.Close();

            //Stream ftpstream = ftp.GetRequestStream();
            //ftpstream.Write(buffer, 0, buffer.Length);
            //ftpstream.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}