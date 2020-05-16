using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.HeThong
{
    public partial class FrmThemNguoidung : XtraForm
    {
        public FrmThemNguoidung()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tendanhnhap.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên đăng nhập.");
                txt_tendanhnhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_hoten.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào họ tên đăng ký tài khoản.");
                txt_hoten.Focus();
                return;
            }

            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_user WHERE tendangnhap='{txt_tendanhnhap.Text}'")) > 0)
            {
                Form1.Default.ShowMessageWarning("Tên người dùng này đã tồn tại.");
                txt_tendanhnhap.Text = "";
                txt_tendanhnhap.Focus();
                return;
            }

            if (txt_matkhau.Text.ToLower() != txt_matkhau2.Text.ToLower())
            {
                Form1.Default.ShowMessageWarning("Mật khẩu nhập lại không hợp lệ.");
                txt_matkhau2.Text = "";
                txt_matkhau2.Focus();
                return;
            }
            var nguoidung = new User { tendangnhap = txt_tendanhnhap.Text, matkhau = ComicPro.Md5(txt_matkhau.Text), hoten = txt_hoten.Text, truycap = true, ghichu = txt_ghichu.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(nguoidung);
            Form1.Default.ShowMessageSuccess($"Đã thêm mới người dùng ({txt_hoten.Text}) thành công.");
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "nguoidung"
            };
            message.Publish();

        }

        public void XoaText()
        {
            txt_ghichu.Text = "";
            txt_hoten.Text = "";
            txt_matkhau.Text = "";
            txt_tendanhnhap.Text = "";
            txt_tendanhnhap.Focus();
        }
        private void FrmThemNguoidung_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_Luu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}