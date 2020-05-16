using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmPhieuXuat : XtraForm
    {
        public FrmPhieuXuat()
        {
            InitializeComponent();
        }

        public async void GetPhieuXuat()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_phieunhapxuat", new { loaiphieu = "PX", tungay = Convert.ToDateTime(txt_tungay.EditValue), denngay = Convert.ToDateTime(txt_denngay.EditValue) });
            dgv_phieuxuat.BeginInvoke(new Action(() =>
            {
                dgv_phieuxuat.DataSource = dt;
                lbl_maphieu.DataBindings.Clear();
                lbl_maphieu.DataBindings.Add("text", dt, "maphieu");
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        public async void GetCtPhieuXuat(string maphieu)
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu });
            dgv_ct_phieuxuat.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieuxuat.DataSource = dt;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemPhieuXuat frm = new FrmThemPhieuXuat();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa phiếu xuất ({gridView1.GetRowCellValue(i, "maphieu")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_phieunhapxuat where maphieu='{gridView1.GetRowCellValue(i, "maphieu")}'");
            Form1.Default.ShowMessageSuccess($"Đã xóa phiếu xuất ({gridView1.GetRowCellValue(i, "maphieu")}) thành công.");
            gridView1.DeleteRow(i);
        }

        public async void GetNhatKyPhieuXuat()
        {
            var x = gridView6.FocusedRowHandle;
            var y = gridView6.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 5, tungay = Convert.ToDateTime(txt_tungay.EditValue), denngay = Convert.ToDateTime(txt_denngay.EditValue) });
            dgv_nhatky.BeginInvoke(new Action(() =>
            {
                dgv_nhatky.DataSource = dt;
            }));
            gridView6.FocusedRowHandle = x;
            gridView6.TopRowIndex = y;
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.Edit = true;
            ComicPro.StrMaphieu = lbl_maphieu.Text;
            FrmThemPhieuXuat frm = new FrmThemPhieuXuat();
            frm.Show(this);
        }

        public void GetKy()
        {
            cbo_Ky2.DataSource = DateTime.Now.GetDateOfWeek();
            cbo_Ky2.DisplayMember = "name";
            cbo_Ky2.ValueMember = "id";
            cbo_Ky.EditValue = 5;
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "phieuxuat")
            {
                GetPhieuXuat();
            }
        }

        private void FrmPhieuXuat_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetKy();
            txt_tungay.EditValue = DateTime.Now.ToString("01/MM/yyyy");
            txt_denngay.EditValue = DateTime.Now.Date;
            GetPhieuXuat();
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (i < 0) { return; }
            GetCtPhieuXuat(gridView1.GetRowCellValue(i, "maphieu").ToString());
        }

        private void btn_thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        public void RefreshData()
        {
            if (xtraTabControl1.SelectedTabPage == tab_phieuxuat)
            {
                GetPhieuXuat();
                GetCtPhieuXuat(lbl_maphieu.Text);
            }
            else
            {
                GetNhatKyPhieuXuat();
            }
        }

        private void btn_tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void cbo_Ky_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView rowSelected = (DataRowView)cbo_Ky2.GetRowByKeyValue(cbo_Ky.EditValue);
            txt_tungay.EditValue = Convert.ToDateTime(rowSelected.Row["from"]);
            txt_denngay.EditValue = Convert.ToDateTime(rowSelected.Row["to"]);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tab_phieuxuat)
            {
                GetPhieuXuat();
                GetCtPhieuXuat(lbl_maphieu.Text);
            }
            else
            {
                GetNhatKyPhieuXuat();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuXuat_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraTabControl1.SelectedTabPage == tab_phieuxuat)
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Bạn vui lòng chọn các mã phiếu để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var selectedRow = gridView1.GetSelectedRows();
                    var joinMaPhieu = string.Join(",", from r in selectedRow where gridView1.IsDataRow(Convert.ToInt32(r)) select gridView1.GetRowCellValue(Convert.ToInt32(r), "maphieu"));
                    var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 8, maphieu = joinMaPhieu });
                    ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
                }
            }
            else
            {
                if (gridView6.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Bạn vui lòng chọn các mã phiếu để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var selectedRow = gridView6.GetSelectedRows();
                    var joinId = string.Join(",", from r in selectedRow where gridView6.IsDataRow(Convert.ToInt32(r)) select gridView6.GetRowCellValue(Convert.ToInt32(r), "id"));

                    var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 9, id = joinId });
                    ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
                }
            }
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = lbl_maphieu.Text });
            if (ComicPro.DtReport.Rows.Count == 0)
            {
                XtraMessageBox.Show("Không tìm thấy dữ liệu.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComicPro.Report = 4;
            FrmReport f = new FrmReport();
            f.Show();
        }

        private void FrmPhieuXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }
    }
}