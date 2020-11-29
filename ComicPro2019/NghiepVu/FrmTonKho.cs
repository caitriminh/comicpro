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
        }

        public async void GetTonKho()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tonkho", new { option = 1, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            dgv_tonkho.BeginInvoke(new Action(() =>
            {
                dgv_tonkho.DataSource = dt;
                lbl_matruyen.DataBindings.Clear();
                lbl_matua.DataBindings.Clear();

                lbl_matruyen.DataBindings.Add("text", dt, "matruyen");
                lbl_matua.DataBindings.Add("text", dt, "matua");
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        public async void GetCtPhieuNhap(string matruyen)
        {
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 2, matruyen, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            dgv_ct_phieunhap.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieunhap.DataSource = dt;
            }));
        }

        public async void GetCtPhieuXuat(string matruyen)
        {
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 3, matruyen, thang = Convert.ToDateTime(txt_tungay.EditValue).Month, nam = Convert.ToDateTime(txt_tungay.EditValue).Year });
            dgv_ct_phieunhap.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieuxuat.DataSource = dt;
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

        private void chk_chitiet_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chk_chitiet.Checked)
            {
                dgv_tonkho.Dock = DockStyle.Top;
                splitterControl1.Visible = true;
                xtraTabControl1.Visible = true;
            }
            else
            {
                dgv_tonkho.Dock = DockStyle.Fill;
                splitterControl1.Visible = false;
                xtraTabControl1.Visible = false;
            }
        }

        public void GetKy()
        {
            cbo_Ky2.DataSource = DateTime.Now.GetDateOfWeek();
            cbo_Ky2.DisplayMember = "name";
            cbo_Ky2.ValueMember = "id";
            cbo_Ky.EditValue = 4;
        }

        public async void GetTuaTruyen()
        {
            var listTuaTruyen = await ExecSQL.ExecQueryDataAsync<TuaTruyen>("SELECT matua, tuatruyen FROM dbo.tbl_tuatruyen ORDER BY tuatruyen");
            cbo_tuatuyen2.DataSource = listTuaTruyen;
            cbo_tuatuyen2.DisplayMember = "tuatruyen";
            cbo_tuatuyen2.ValueMember = "matua";
            cbo_tuatruyen.EditValue = lbl_matua.Text;
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
            GetTuaTruyen();
            ///////////////////
            dgv_tonkho.Dock = DockStyle.Fill;
            splitterControl1.Visible = false; xtraTabControl1.Visible = false;
            gridView4.FocusedRowChanged += GridView4_FocusedRowChanged;
        }

        private void GridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (chk_chitiet.Checked == false) { return; }
            var i = gridView4.FocusedRowHandle;
            if (i < 0) { return; }
            GetCtPhieuNhap(gridView4.GetRowCellValue(i, "matruyen").ToString());
            GetCtPhieuXuat(gridView4.GetRowCellValue(i, "matruyen").ToString());
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
            string strDuongDan = Application.StartupPath + "\\img\\thumb\\";
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

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == tab_layout)
            {
                cbo_tuatruyen.Enabled = true;
                cbo_Ky.Enabled = false;
                txt_tungay.Enabled = false;
                txt_denngay.Enabled = false;
                btn_tim.Enabled = false;
                cbo_tuatruyen.EditValue = lbl_matua.Text;
                GetLayout(cbo_tuatruyen.EditValue.ToString().Replace(" ", ""));
            }
            else if (xtraTabControl2.SelectedTabPage == tab_tonkho)
            {
                cbo_tuatruyen.Enabled = false;
                cbo_Ky.Enabled = true;
                txt_tungay.Enabled = true;
                txt_denngay.Enabled = true;
                btn_tim.Enabled = true;
            }
        }

        private void cbo_tuatruyen_EditValueChanged(object sender, EventArgs e)
        {
            GetLayout(cbo_tuatruyen.EditValue.ToString().Replace(" ", ""));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}