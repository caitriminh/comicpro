using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SimpleBroker;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmThemPhieuXuat : XtraForm
    {
        public FrmThemPhieuXuat()
        {
            InitializeComponent();
        }

        public async void GetDonVi()
        {
            var dt = await ExecSQL.ExecProcedureDataAsync<DonVi>("pro_get_donvi", new { option = 2 });
            cbo_donvi.Properties.DataSource = dt;
            cbo_donvi.Properties.DisplayMember = "madonvi";
            cbo_donvi.Properties.ValueMember = "madonvi";
        }

        public async void GetKho()
        {
            var listKho = await ExecSQL.ExecQueryDataAsync<Kho>("SELECT makho, tenkho FROM dbo.tbl_kho ORDER BY tenkho");
            cbo_kho.Properties.DataSource = listKho;
            cbo_kho.Properties.DisplayMember = "tenkho";
            cbo_kho.Properties.ValueMember = "makho";
        }

        public async void GetTenTruyen()
        {
            var listTenTruyen = await ExecSQL.ExecProcedureDataAsync<TenTruyen>("pro_get_tentruyen", new { option = 1 });
            cbo_tentruyen.DataSource = listTenTruyen;
            cbo_tentruyen.DisplayMember = "matruyen";
            cbo_tentruyen.ValueMember = "matruyen";
        }

        public async void GetLoaiPhieu()
        {
            var listLoaiPhieu = await ExecSQL.ExecQueryDataAsync<LoaiPhieu>("SELECT id, loaiphieu FROM dbo.tbl_loaiphieunhapxuat");
            cbo_loaiphieu.Properties.DataSource = listLoaiPhieu;
            cbo_loaiphieu.Properties.DisplayMember = "loaiphieu";
            cbo_loaiphieu.Properties.ValueMember = "id";
            cbo_loaiphieu.EditValue = 2;
        }

        private void cbo_donvi_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_donvi.Text)) { return; }
            var dt = ExecSQL.ExecProcedureDataFistOrDefault<DonVi>("pro_get_donvi", new { option = 4, madonvi = cbo_donvi.EditValue });
            txt_donvi.Text = dt.donvi;
            txt_diachi.Text = dt.diachi;
        }

        public async void GetCtPhieuXuat()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            dgv_ct_phieuxuat.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieuxuat.DataSource = dt;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void txt_maphieu_TextChanged(object sender, EventArgs e)
        {
            GetCtPhieuXuat();
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maphieu.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn vui lòng nhập vào mã phiếu để tiếp tục.");
                return;
            }
            var view = (GridView)sender;
            var i = view.FocusedRowHandle;
            switch (view.FocusedColumn.FieldName)
            {
                case "matruyen":
                    var dt = ExecSQL.ExecProcedureDataFistOrDefault<TenTruyen>("pro_get_tentruyen", new { option = 2, matruyen = e.Value.ToString() });
                    if (dt == null) { return; }
                    view.SetRowCellValue(i, "donvitinh", dt.donvitinh);
                    view.SetRowCellValue(i, "tuatruyen", dt.tuatruyen);
                    view.SetRowCellValue(i, "tentruyen", dt.tentruyen);
                    view.SetRowCellValue(i, "tap", dt.tap);
                    view.SetRowCellValue(i, "dongia", dt.giabia);
                    view.SetRowCellValue(i, "slxuat", 1);
                    view.SetRowCellValue(i, "thanhtien2", dt.giabia);
                    break;
                case "slxuat":
                    view.SetRowCellValue(i, "thanhtien2", Convert.ToInt32(e.Value) * Convert.ToInt32(view.GetRowCellValue(i, "dongia")));
                    break;
                case "giabia":
                    view.SetRowCellValue(i, "thanhtien2", Convert.ToInt32(e.Value) * Convert.ToInt32(view.GetRowCellValue(i, "slxuat")));
                    break;
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_maphieu.Focus();
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn cập nhật lại những thay đổi không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            if (string.IsNullOrEmpty(txt_maphieu.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào mã phiếu.");
                txt_maphieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_ngaynhap.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào ngày xuất.");
                txt_ngaynhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbo_donvi.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập đơn vị để lập phiếu nhập.");
                cbo_donvi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbo_kho.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên kho.");
                cbo_kho.Focus();
                return;
            }
            for (var i = 0; i <= gridView1.RowCount; i++)
            {
                var dr = gridView1.GetDataRow(Convert.ToInt32(i));
                if (ReferenceEquals(dr, null))
                {
                    break;
                }
                switch (dr.RowState)
                {
                    case DataRowState.Added:
                        ExecSQL.ExecProcedureNonData("pro_insert_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text, madonvi = cbo_donvi.EditValue.ToString(), loaiphieu = "PX", idloaiphieunhapxuat = Convert.ToInt32(cbo_loaiphieu.EditValue), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), makho = cbo_kho.EditValue.ToString(), matruyen = dr["matruyen"].ToString(), slxuat = Convert.ToInt32(dr["slxuat"]), dongia = Convert.ToDecimal(dr["dongia"]), ghichu = dr["ghichu"].ToString(), nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
                        break;
                    case DataRowState.Modified:
                        ExecSQL.ExecProcedureNonData("pro_update_phieunhapxuat", new { option = 1, slxuat = Convert.ToInt32(dr["slxuat"]), dongia = Convert.ToDecimal(dr["dongia"]), ghichu = dr["ghichu"].ToString(), nguoitd2 = ComicPro.StrTenDangNhap.ToUpper(), id = Convert.ToInt32(dr["id"]) });
                        break;
                }
            }
            ExecSQL.ExecProcedureNonData("pro_update_phieunhapxuat", new { option = 2, madonvi = cbo_donvi.EditValue.ToString(), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), diengiai = txt_diengiai.Text, maphieu = txt_maphieu.Text });
            GetCtPhieuXuat();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "phieuxuat"
            };
            message.Publish();
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetCtPhieuXuat();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa phiếu nhập ({txt_maphieu.Text}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_phieunhapxuat where maphieu='{txt_maphieu.Text}'");
            Form1.Default.ShowMessageSuccess($"Đã xóa phiếu nhập ({txt_maphieu.Text}) thành công.");
            GetCtPhieuXuat();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "phieuxuat"
            };
            message.Publish();
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (e.Column == col_xoa)
            {
                var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên truyện ({gridView1.GetRowCellValue(i, "tentruyen")}) trong mã phiếu ({txt_maphieu.Text}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
                if (dgr != DialogResult.Yes) { return; }
                ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_phieunhapxuat WHERE id='{gridView1.GetRowCellValue(i, "id")}'");
                Form1.Default.ShowMessageSuccess($"Đã xóa tên truyện ({gridView1.GetRowCellValue(i, "tentruyen")}) trong mã phiếu ({txt_maphieu.Text}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void FrmThemPhieuXuat_Load(object sender, EventArgs e)
        {
            GetDonVi();
            GetKho();
            GetTenTruyen();
            GetLoaiPhieu(); txt_ngaynhap.EditValue = DateTime.Now.Date;
            txt_maphieu.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('PXK',FORMAT(GETDATE(),'MMyy'), FORMAT(ISNULL(RIGHT(MAX(maphieu),3),0)+1,'000')) FROM dbo.tbl_phieunhapxuat WHERE LEFT(maphieu,3)='PXK' AND MONTH(ngaynhap)=MONTH(GETDATE()) AND YEAR(ngaynhap)=YEAR(GETDATE())").ToString();

            if (ComicPro.Edit == false) { return; }
            txt_maphieu.Text = ComicPro.StrMaphieu;
            GetThongTin();
            cbo_kho.Properties.ReadOnly = true;
            txt_maphieu.Properties.ReadOnly = true;
        }

        public void GetThongTin()
        {
            var dt = ExecSQL.ExecProcedureDataFistOrDefault<PhieuNhapXuat>("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            cbo_donvi.EditValue = dt.madonvi;
            cbo_kho.EditValue = dt.makho;
            cbo_loaiphieu.EditValue = dt.idloaiphieunhapxuat;
            txt_diengiai.Text = dt.diengiai;
            txt_ngaynhap.EditValue = dt.ngaynhap;
        }

        private void FrmThemPhieuXuat_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComicPro.Edit = false;
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.DtReport = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            if (ComicPro.DtReport.Rows.Count == 0)
            {
                Form1.Default.ShowMessageWarning("Không tìm thấy dữ liệu.");
                return;
            }
            ComicPro.Report = 4;
            FrmReport f = new FrmReport();
            f.Show();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.Edit = false;
            txt_maphieu.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('PXK',FORMAT(GETDATE(),'MMyy'), FORMAT(ISNULL(RIGHT(MAX(maphieu),3),0)+1,'000')) FROM dbo.tbl_phieunhapxuat WHERE LEFT(maphieu,3)='PXK' AND MONTH(ngaynhap)=MONTH(GETDATE()) AND YEAR(ngaynhap)=YEAR(GETDATE())").ToString();
            cbo_donvi.EditValue = DBNull.Value;
            cbo_kho.EditValue = DBNull.Value;
            txt_donvi.Text = "";
            txt_diachi.Text = "";
            cbo_kho.Properties.ReadOnly = false;
            txt_maphieu.Properties.ReadOnly = false;
        }
    }
}