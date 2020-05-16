using System;
using System.Globalization;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DTO;

namespace ComicPro2019.HeThong
{
    public partial class FrmDoiMatKhau : XtraForm
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        BusUser _busUser = new BusUser();
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_matkhau.Text.ToLower() != txt_matkhau2.Text.ToLower())
            {
                XtraMessageBox.Show("Mật khẩu nhập lại không hợp lệ.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_matkhau2.Text = "";
                txt_matkhau2.Focus();
                return;
            }

            _busUser.DoiMatKhau(txt_tendanhnhap.Text, txt_matkhau.Text);
            XtraMessageBox.Show("Đổi mật khẩu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }


        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_tendanhnhap.Text = ComicPro.StrTenDangNhap.ToLower();
        }

        private void FrmDoiMatKhau_KeyDown(object sender, KeyEventArgs e)
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