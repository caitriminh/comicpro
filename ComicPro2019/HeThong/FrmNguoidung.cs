using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.HeThong
{
    public partial class FrmNguoidung : XtraForm
    {
        public FrmNguoidung()
        {
            InitializeComponent();
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        public async void GetNguoiDung()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<User>("SELECT * FROM dbo.tbl_user where tendangnhap<>'admin'");
            dgv_nguoidung.BeginInvoke(new Action(() =>
            {
                dgv_nguoidung.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemNguoidung frm = new FrmThemNguoidung();
            frm.Show(this);
        }
        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên đăng nhập ({gridView1.GetRowCellValue(i, "tendangnhap")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var nguoidung = gridView1.GetRow(i) as User;
            var affected = ExecSQL.Delete(nguoidung);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tên đăng nhập ({gridView1.GetRowCellValue(i, "tendangnhap")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetNguoiDung();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageWarning($"Không có dòng dữ liệu nào thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thay đổi danh mục khách hàng không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var nguoidung = gridView1.GetRow(item) as User;
                if (nguoidung != null)
                {
                    nguoidung.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    nguoidung.thoigian2 = DateTime.Now;
                    ExecSQL.Update(nguoidung);
                    dem += 1;
                }
            }
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
            GetNguoiDung();
            modifined.Clear();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_reset_password))
            {
                var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn khôi phục lại mật khẩu mặc định của tài khoản ({gridView1.GetRowCellValue(i, "tendangnhap")}) không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
                if (dgr != DialogResult.Yes) { return; }
                ExecSQL.ExecQueryNonData($"UPDATE dbo.tbl_user SET matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', tendangnhap), 2) WHERE tendangnhap='{gridView1.GetRowCellValue(i, "tendangnhap").ToString()}'");
                Form1.Default.ShowMessageSuccess("Đã khôi phục mật khẩu thành công.");
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "nguoidung")
            {
                GetNguoiDung();
            }
        }

        private List<int> modifined;
        private void FrmNguoidung_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            xtraSaveFileDialog1.Filter = "Excel file *|.xlsx";
            modifined = new List<int>();
            GetNguoiDung();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }
    }
}