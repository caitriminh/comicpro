using ComicPro2019.Extensions;
using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmTonKho : XtraForm
    {
        public FrmTonKho()
        {
            InitializeComponent();

            grvViewTonKho.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcTonKho, grvViewTonKho); };
            grvViewTonKho.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcTonKho, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcTonKho, Name);

            grvViewCTPhieuNhap.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcCTPhieuNhap, grvViewCTPhieuNhap); };
            grvViewCTPhieuNhap.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcCTPhieuNhap, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcCTPhieuNhap, Name);

            grvViewCTPhieuXuat.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcCTPhieuXuat, grvViewCTPhieuXuat); };
            grvViewCTPhieuXuat.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcCTPhieuXuat, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcCTPhieuXuat, Name);
        }

        public async void GetTonKho()
        {
            var x = grvViewCTPhieuNhap.FocusedRowHandle;
            var y = grvViewCTPhieuNhap.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tonkho", new { option = 1, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            grcTonKho.DataSource = dt;
            lbl_matruyen.DataBindings.Clear();
            lbl_matua.DataBindings.Clear();

            lbl_matruyen.DataBindings.Add("text", dt, "matruyen");
            lbl_matua.DataBindings.Add("text", dt, "matua");
            grvViewCTPhieuNhap.FocusedRowHandle = x;
            grvViewCTPhieuNhap.TopRowIndex = y;
        }

        public async void GetCtPhieuNhap(string matruyen)
        {
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 2, matruyen, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            grcCTPhieuNhap.BeginInvoke(new Action(() =>
            {
                grcCTPhieuNhap.DataSource = dt;
            }));
        }

        public async void GetCtPhieuXuat(string matruyen)
        {
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 3, matruyen, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            grcCTPhieuNhap.BeginInvoke(new Action(() =>
            {
                grcCTPhieuXuat.DataSource = dt;
            }));
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTonKho();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tất cả dữ liệu tồn kho?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_tonkho WHERE MONTH(ky)='{Convert.ToDateTime(txt_tungay.EditValue).Month}' AND YEAR(ky)='{Convert.ToDateTime(txt_tungay.EditValue).Year}'");
            GetTonKho();
        }



        public void GetKy()
        {
            cbo_Ky2.DataSource = DateTime.Now.GetDateOfWeek();
            cbo_Ky2.DisplayMember = "name";
            cbo_Ky2.ValueMember = "id";
            cbo_Ky.EditValue = 4;
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "tonkho")
            {
                GetTonKho();
            }
        }

        private void FrmTonKho_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetKy();
            txt_tungay.EditValue = DateTime.Now.ToString("01/MM/yyyy");
            txt_denngay.EditValue = DateTime.Now.Date;
            GetTonKho();
            grvViewTonKho.FocusedRowChanged += GridView4_FocusedRowChanged;
        }

        private void GridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var i = grvViewTonKho.FocusedRowHandle;
            if (i < 0) { return; }
            GetCtPhieuNhap(grvViewTonKho.GetRowCellValue(i, "matruyen").ToString());
            GetCtPhieuXuat(grvViewTonKho.GetRowCellValue(i, "matruyen").ToString());
        }

        private void btn_tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTonKho();
        }

        private void btn_thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_chuyensodu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChuyenSoDu frm = new FrmChuyenSoDu();
            frm.Show(this);
        }

        private void cbo_Ky_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView rowSelected = (DataRowView)cbo_Ky2.GetRowByKeyValue(cbo_Ky.EditValue);
            txt_tungay.EditValue = Convert.ToDateTime(rowSelected.Row["from"]);
            txt_denngay.EditValue = Convert.ToDateTime(rowSelected.Row["to"]);
        }

        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //InfoDanhMuc myUC1;

            //if (e.Column == col_thongtin)
            //{
            //    myUC1 = new InfoDanhMuc();
            //    Controls.Add(myUC1);
            //    myUC1.BringToFront();
            //}
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_get_tonkho", new { option = 1, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            if (ComicPro.DtReport.Rows.Count == 0)
            {
                Form1.Default.ShowMessageWarning("Không tìm thấy dữ liệu.");
                return;
            }
            ComicPro.Report = 5;
            FrmReport f = new FrmReport();
            f.Show();
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucTonKho_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_tonkho", new { option = 2, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
                ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
            }
        }

        public async void GetLayout(string matua)
        {
            string strDuongDan = Application.StartupPath + "\\img\\origin\\";
            DataTable dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tonkho", new { option = 3, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year, duongdanhinh = strDuongDan, matua });
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
                             if (File.Exists(drow["hinhanh"].ToString()))
                             {
                                 item = new PictureObject(drow["tentruyen"].ToString(), Image.FromFile(drow["hinhanh"].ToString()), drow["tuatruyen"].ToString());
                             }
                             else
                             {
                                 item = new PictureObject(drow["tentruyen"].ToString(), Image.FromFile(strDuongDan + "no-image.png"), drow["tuatruyen"].ToString());
                             }
                             list.Add(item);
                         }));
                     }

                 }
             });
            dgv_Layout.DataSource = list;
        }

        public class PictureObject : INotifyPropertyChanged
        {
            public string Name { get; set; }
            public Image Image { get; set; }
            public string Tuatruyen { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            //Image noImage;
            public PictureObject(string name, Image url, string tuatruyen)
            {
                Name = name;
                Image = url;
                Tuatruyen = tuatruyen;
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

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return newBitmap;
        }

        private void lbl_matua_TextChanged(object sender, EventArgs e)
        {
            GetLayout(lbl_matua.Text);
        }
    }
}