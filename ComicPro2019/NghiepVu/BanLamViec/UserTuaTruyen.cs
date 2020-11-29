using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.WinExplorer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu.BanLamViec
{
    public partial class UserTuaTruyen : XtraUserControl
    {
        public UserTuaTruyen()
        {
            InitializeComponent();
        }

        public async void GetLayout()
        {
            string strDuongDan = ComicPro.URL_HinhAnh;
            DataTable dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tuatruyen_hinhanh", new { duongdanhinh = strDuongDan });
            BindingList<PictureObject> list = new BindingList<PictureObject>();
            PictureObject item;
            object b = new object();
            //await Task.Factory.StartNew(() =>
            // {
            foreach (DataRow drow in dt.Rows)
            {
                lock (b)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (File.Exists(drow["hinhanh"].ToString()))
                        {
                            item = new PictureObject(Image.FromFile(drow["hinhanh"].ToString()), drow["tentruyen"].ToString(), drow["tuatruyen"].ToString());
                            //  item = new PictureObject(drow["hinhanh"].ToString(), drow["tentruyen"].ToString(), drow["tuatruyen"].ToString());
                        }
                        else
                        {
                            item = new PictureObject(Image.FromFile(strDuongDan + "no-image.png"), drow["tentruyen"].ToString(), drow["tuatruyen"].ToString());
                        }
                        list.Add(item);
                    }));
                }

            }
            //});
            gridControl1.DataSource = list;
        }

        public class PictureObject : INotifyPropertyChanged
        {
            public Image Image { get; set; }
            public string Tentruyen { get; set; }
            public string Tuatruyen { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;

            public PictureObject(Image url, string tentruyen, string tuatruyen)
            {
                Image = url;
                Tentruyen = tentruyen;
                Tuatruyen = tuatruyen;
            }
        }


        private void UserTuaTruyen_Load(object sender, EventArgs e)
        {
            GetLayout();
        }

        private void winExplorerView1_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            //switch (e.Item.Name)
            //{
            //    case "btn_open":
            //        var i = winExplorerView1.FocusedRowHandle;
            //        XtraMessageBox.Show("Bạn đang chọn tập: " + (string)winExplorerView1.GetRowCellValue(i, col_tentruyen));
            //        break;

            //}
            WinExplorerView view = sender as WinExplorerView;
            if (view == null)
            {
                return;
            }

            string caption = e.Item.Name;
            switch (caption)
            {
                case "btn_open":
                    var tentruyen = view.GetRowCellValue((int)e.DataItem, col_tentruyen).ToString();
                    MessageBox.Show(tentruyen);
                    break;


            }
        }

        private void winExplorerView1_ContextButtonCustomize(object sender, WinExplorerViewContextButtonCustomizeEventArgs e)
        {
            //switch (e.Item.Name)
            //{
            //    case "btn_open":
            //        var i = winExplorerView1.FocusedRowHandle;
            //        XtraMessageBox.Show("Bạn đang chọn tập: " + (string)winExplorerView1.GetRowCellValue(i, col_tentruyen));
            //        break;

            //}
        }

        private void winExplorerView1_Click(object sender, EventArgs e)
        {
            //var i = winExplorerView1.FocusedRowHandle;
            //XtraMessageBox.Show("Bạn đang chọn tập: " + (string)winExplorerView1.GetRowCellValue(i, col_tentruyen));
        }
    }
}