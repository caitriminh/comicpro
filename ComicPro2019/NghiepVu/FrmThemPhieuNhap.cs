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
    public partial class FrmThemPhieuNhap : XtraForm
    {

        public FrmThemPhieuNhap()
        {
            InitializeComponent();
        }

        public void GetDonVi()
        {
            var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_donvi", new { option = 2 });
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
            cbo_loaiphieu.EditValue = 1;
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "phieunhapdanhsach")
            {
                ExecSQL.ExecProcedureNonData("pro_insert_phieunhapxuat", new { option = 2, maphieu = txt_maphieu.Text, madonvi = cbo_donvi.EditValue.ToString(), loaiphieu = "PN", idloaiphieunhapxuat = Convert.ToInt32(cbo_loaiphieu.EditValue), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), makho = cbo_kho.EditValue.ToString(), matruyen = ComicPro.StrMaTruyen, ghichu = "Nhập từ danh sách.", nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
                GetCtPhieuNhap();
                Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công phiếu nhập kho ({txt_maphieu.Text}) từ danh sách.");
            }
        }

        private void FrmThemPhieuNhap_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetDonVi();
            GetTenTruyen();
            GetLoaiPhieu();
            GetKho();
            txt_ngaynhap.EditValue = DateTime.Now.Date;
            txt_maphieu.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('PNK',FORMAT(GETDATE(),'MMyy'), FORMAT(ISNULL(RIGHT(MAX(maphieu),3),0)+1,'000')) FROM dbo.tbl_phieunhapxuat WHERE LEFT(maphieu,3)='PNK' AND MONTH(ngaynhap)=MONTH(GETDATE()) AND YEAR(ngaynhap)=YEAR(GETDATE())").ToString();
            if (ComicPro.Edit == false) { return; }
            txt_maphieu.Text = ComicPro.StrMaphieu;
            GetThongTin();
            txt_maphieu.Properties.ReadOnly = true;
        }

        public void GetThongTin()
        {
            var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            if (dt == null) { return; }
            cbo_donvi.Text = dt.Rows[0]["madonvi"].ToString();
            cbo_kho.EditValue = dt.Rows[0]["makho"];
            cbo_loaiphieu.EditValue = dt.Rows[0]["idloaiphieunhapxuat"];
            txt_diengiai.Text = dt.Rows[0]["diengiai"].ToString();
            txt_ngaynhap.EditValue = dt.Rows[0]["ngaynhap"];
        }

        private void cbo_donvi_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_donvi.Text)) { return; }
            var dt = ExecSQL.ExecProcedureDataFistOrDefault<DonVi>("pro_get_donvi", new { option = 4, madonvi = cbo_donvi.EditValue });
            txt_donvi.Text = dt.donvi;
            txt_diachi.Text = dt.diachi;
        }

        public async void GetCtPhieuNhap()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            dgv_ct_phieunhap.BeginInvoke(new Action(() =>
            {
                dgv_ct_phieunhap.DataSource = dt;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void txt_maphieu_TextChanged(object sender, EventArgs e)
        {
            GetCtPhieuNhap();
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
                    view.SetRowCellValue(i, "slnhap", 1);
                    view.SetRowCellValue(i, "thanhtien", dt.giabia);
                    break;
                case "slxuat":
                    view.SetRowCellValue(i, "thanhtien", Convert.ToInt32(e.Value) * Convert.ToInt32(view.GetRowCellValue(i, "dongia")));
                    break;
                case "giabia":
                    view.SetRowCellValue(i, "thanhtien", Convert.ToInt32(e.Value) * Convert.ToInt32(view.GetRowCellValue(i, "slnhap")));
                    break;
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_maphieu.Focus();
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn cập nhật phiếu nhập ({txt_maphieu.Text}) những thay đổi không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            if (string.IsNullOrEmpty(txt_maphieu.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập mã phiếu nhập.");
                txt_maphieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbo_donvi.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập đơn vị để lập phiếu nhập.");
                cbo_donvi.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_ngaynhap.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập ngày nhập phiếu.");
                txt_ngaynhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbo_kho.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên kho.");
                cbo_kho.Focus();
                return;
            }
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_phieunhapxuat WHERE maphieu='{txt_maphieu.Text}'")) == 0)
            {
                ExecSQL.ExecProcedureNonData("pro_insert_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text, madonvi = cbo_donvi.EditValue.ToString(), loaiphieu = "PN", idloaiphieunhapxuat = Convert.ToInt32(cbo_loaiphieu.EditValue), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), makho = cbo_kho.EditValue.ToString(), diengiai = txt_diengiai.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
            }
            else
            {
                ExecSQL.ExecProcedureNonData("pro_insert_phieunhapxuat", new { option = 3, maphieu = txt_maphieu.Text, madonvi = cbo_donvi.EditValue.ToString(), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), makho = cbo_kho.EditValue.ToString(), diengiai = txt_diengiai.Text, nguoitd2 = ComicPro.StrTenDangNhap.ToUpper() });
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
                        ExecSQL.ExecProcedureNonData("pro_insert_ct_phieunhapxuat", new { maphieu = txt_maphieu.Text, matruyen = dr["matruyen"].ToString(), slnhap = Convert.ToInt32(dr["slnhap"]), dongia = Convert.ToDecimal(dr["dongia"]), ghichu = dr["ghichu"].ToString(), nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
                        break;
                    case DataRowState.Modified:
                        ExecSQL.ExecProcedureNonData("pro_update_phieunhapxuat", new { option = 1, slnhap = Convert.ToInt32(dr["slnhap"]), dongia = Convert.ToDecimal(dr["dongia"]), ghichu = dr["ghichu"].ToString(), nguoitd2 = ComicPro.StrTenDangNhap.ToUpper(), id = Convert.ToInt32(dr["id"]) });
                        break;
                }
            }
            //ExecSQL.ExecProcedureNonData("pro_update_phieunhapxuat", new { option = 2, madonvi = cbo_donvi.EditValue.ToString(), ngaynhap = Convert.ToDateTime(txt_ngaynhap.EditValue), diengiai = txt_diengiai.Text, maphieu = txt_maphieu.Text, makho = cbo_kho.EditValue.ToString() });
            GetCtPhieuNhap();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công phiếu nhập ({txt_maphieu.Text})");
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "phieunhap"
            };
            message.Publish();
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetCtPhieuNhap();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa phiếu nhập ({txt_maphieu.Text}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecProcedureNonData("pro_delete_phieunhapxuat", new { maphieu = txt_maphieu.Text });
            Form1.Default.ShowMessageSuccess($"Đã xóa phiếu nhập ({txt_maphieu.Text}) thành công.");
            GetCtPhieuNhap();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "phieunhap"
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
                ExecSQL.ExecQueryNonData($"DELETE FROM dbo.tbl_ct_phieunhapxuat WHERE id='{gridView1.GetRowCellValue(i, "id")}'");
                Form1.Default.ShowMessageSuccess($"Đã xóa tên truyện ({gridView1.GetRowCellValue(i, "tentruyen")}) trong mã phiếu ({txt_maphieu.Text}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void FrmThemPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
            ComicPro.Edit = false;
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ComicPro.DtReport = ExecSQL.ExecQueryDataAsDataTable("pro_ct_phieunhapxuat", new { option = 1, maphieu = txt_maphieu.Text });
            if (ComicPro.DtReport.Rows.Count == 0)
            {
                Form1.Default.ShowMessageWarning("Không tìm thấy dữ liệu.");
                return;
            }
            ComicPro.Report = 3;
            FrmReport f = new FrmReport();
            f.Show();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_maphieu.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('PNK',FORMAT(GETDATE(),'MMyy'), FORMAT(ISNULL(RIGHT(MAX(maphieu),3),0)+1,'000')) FROM dbo.tbl_phieunhapxuat WHERE LEFT(maphieu,3)='PNK' AND MONTH(ngaynhap)=MONTH(GETDATE()) AND YEAR(ngaynhap)=YEAR(GETDATE())").ToString();
            cbo_donvi.EditValue = DBNull.Value;
            cbo_kho.EditValue = DBNull.Value;
            txt_donvi.Text = "";
            txt_diachi.Text = ""; cbo_kho.Properties.ReadOnly = false;
            txt_diengiai.Text = "";
            txt_maphieu.Properties.ReadOnly = false;
        }

        private void btn_them_tu_danhsach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maphieu.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập mã phiếu nhập.");
                txt_maphieu.Focus();
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
            FrmDanhSachTuaTruyen frm = new FrmDanhSachTuaTruyen();
            frm.Show();
        }
    }
}