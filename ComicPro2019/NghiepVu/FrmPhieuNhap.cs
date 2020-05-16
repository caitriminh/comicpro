using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmPhieuNhap : XtraForm
    {
        public FrmPhieuNhap()
        {
            InitializeComponent();
        }

        public async void GetPhieuNhap()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_phieunhapxuat", new { loaiphieu = "PN", tungay = Convert.ToDateTime(txt_tungay.EditValue), denngay = Convert.ToDateTime(txt_denngay.EditValue) });
            dgv_phieunhap.BeginInvoke(new Action(() =>
            {
                dgv_phieunhap.DataSource = dt;
                lbl_maphieu.DataBindings.Clear();
                lbl_maphieu.DataBindings.Add("text", dt, "maphieu");
            }));

            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        public async void GetCtPhieuNhap(string maphieu)
        {
            var x = gridView4.FocusedRowHandle;
            var y = gridView4.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu });
            dgv_ct_phieunhap.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieunhap.DataSource = dt;
            }));
            gridView4.FocusedRowHandle = x;
            gridView4.TopRowIndex = y;
        }

        public async void GetNhatKyPhieuNhap()
        {
            var x = gridView6.FocusedRowHandle;
            var y = gridView6.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 4, tungay = Convert.ToDateTime(txt_tungay.EditValue), denngay = Convert.ToDateTime(txt_denngay.EditValue) });
            dgv_nhatky.BeginInvoke(new Action(() =>
            {
                dgv_nhatky.DataSource = dt;
                if (xtraTabControl1.SelectedTabPage == tab_nhatky)
                {
                    lbl_maphieu.DataBindings.Clear();
                    lbl_maphieu.DataBindings.Add("text", dt, "maphieu");
                }
            }));
            gridView6.FocusedRowHandle = x;
            gridView6.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemPhieuNhap frm = new FrmThemPhieuNhap();
            frm.Show(this);
        }

        public void RefreshData()
        {
            if (xtraTabControl1.SelectedTabPage == tab_phieunhap)
            {
                GetPhieuNhap();
                GetCtPhieuNhap(lbl_maphieu.Text);
            }
            else
            {
                GetNhatKyPhieuNhap();
            }
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa phiếu nhập ({gridView1.GetRowCellValue(i, "maphieu")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_phieunhapxuat where maphieu='{gridView1.GetRowCellValue(i, "maphieu")}'");
            Form1.Default.ShowMessageSuccess($"Đã xóa phiếu nhập ({gridView1.GetRowCellValue(i, "maphieu")}) thành công.");
            gridView1.DeleteRow(i);

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
            if (value.task == "phieunhap")
            {
                GetPhieuNhap();
            }
        }

        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetKy();
            txt_tungay.EditValue = DateTime.Now.ToString("01/MM/yyyy");
            txt_denngay.EditValue = DateTime.Now.Date;
            GetPhieuNhap();
            GetCtPhieuNhap(lbl_maphieu.Text);
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (i < 0) { return; }
            GetCtPhieuNhap(gridView1.GetRowCellValue(i, "maphieu").ToString());
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.Edit = true;
            ComicPro.StrMaphieu = lbl_maphieu.Text;
            FrmThemPhieuNhap frm = new FrmThemPhieuNhap();
            frm.Show();
        }
        private void btn_tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }


        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuNhap_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraTabControl1.SelectedTabPage == tab_phieunhap)
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    Form1.Default.ShowMessageSuccess("Bạn vui lòng chọn các mã phiếu để thực hiện.");
                    return;
                }
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var selectedRow = gridView1.GetSelectedRows();
                    var joinMaPhieu = string.Join(",", from r in selectedRow where gridView1.IsDataRow(Convert.ToInt32(r)) select gridView1.GetRowCellValue(Convert.ToInt32(r), "maphieu"));

                    var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 6, maphieu = joinMaPhieu });
                    ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
                }
            }
            else
            {
                if (gridView6.SelectedRowsCount == 0)
                {
                    Form1.Default.ShowMessageSuccess("Bạn vui lòng chọn các mã phiếu để thực hiện.");
                    return;
                }
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var selectedRow = gridView6.GetSelectedRows();
                    var joinId = string.Join(",", from r in selectedRow where gridView6.IsDataRow(Convert.ToInt32(r)) select gridView6.GetRowCellValue(Convert.ToInt32(r), "id"));
                    var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 7, id = joinId });
                    ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
                }
            }
        }

        private void cbo_Ky_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView rowSelected = (DataRowView)cbo_Ky2.GetRowByKeyValue(cbo_Ky.EditValue);
            txt_tungay.EditValue = Convert.ToDateTime(rowSelected.Row["from"]);
            txt_denngay.EditValue = Convert.ToDateTime(rowSelected.Row["to"]);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tab_phieunhap)
            {
                GetPhieuNhap();
                GetCtPhieuNhap(lbl_maphieu.Text);
            }
            else if (xtraTabControl1.SelectedTabPage == tab_nhatky)
            {
                GetNhatKyPhieuNhap();
            }
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = lbl_maphieu.Text });
            if (ComicPro.DtReport.Rows.Count == 0)
            {
                Form1.Default.ShowMessageSuccess("Không tìm thấy dữ liệu.");
                return;
            }
            ComicPro.Report = 3;
            FrmReport f = new FrmReport();
            f.Show();
        }

        private void FrmPhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }
    }
}