using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmDonVi : XtraForm
    {
        public FrmDonVi()
        {
            InitializeComponent();
        }

        public async void GetDonVi()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsync<DonVi>("pro_get_donvi", new { option = 1 });
            dgv_donvi.BeginInvoke(new Action(() =>
            {
                dgv_donvi.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));

        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemDonVi frm = new FrmThemDonVi();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetDonVi();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageDefault($"Không có dòng nào thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var donvi = gridView1.GetRow(item) as DonVi;
                if (donvi != null)
                {
                    donvi.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    donvi.thoigian2 = DateTime.Now;
                    ExecSQL.Update(donvi);
                    dem += 1;
                }
            }
            GetDonVi();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã câp nhật {dem} dòng thành công.");
        }


        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_phieunhapxuat where madonvi='{gridView1.GetRowCellValue(i, "madonvi")}'")) > 0)
            {
                Form1.Default.ShowMessageError($"Đơn vị ({gridView1.GetRowCellValue(i, "donvi")}) đã được sử dụng, bạn không thể xóa.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên đơn vị ({gridView1.GetRowCellValue(i, "donvi")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var donvi = gridView1.GetRow(i) as DonVi;
            var affected = ExecSQL.Delete(donvi);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa đơn vị ({gridView1.GetRowCellValue(i, "donvi")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        public async void GetNhomDonVi()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<NhomDonVi>("SELECT id, nhomdonvi FROM dbo.tbl_nhomdonvi");
            cbo_nhomdonvi.DataSource = dt;
            cbo_nhomdonvi.DisplayMember = "nhomdonvi";
            cbo_nhomdonvi.ValueMember = "id";
        }
        private void OnNext(MessageBroker value)
        {
            if (value.task == "donvi")
            {
                GetDonVi();
            }
        }

        private List<int> modifined;
        private void FrmDonVi_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetNhomDonVi();
            GetDonVi();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DonVi_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_donvi", new { option = 5 });
                ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
            }
        }
    }
}