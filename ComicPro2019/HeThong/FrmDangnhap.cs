using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace ComicPro2019.HeThong
{
    public partial class FrmDangnhap : XtraForm
    {
        public FrmDangnhap()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_dangnhap_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void FrmDangnhap_Load(object sender, EventArgs e)
        {
            txt_tendangnhap.Focus();

        }

        public string IsLogin { set; get; }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_user WHERE tendangnhap='{txt_tendangnhap.Text.ToUpper()}' AND matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', '{txt_matkhau.Text}'), 2)")) > 0)
            {
                IsLogin = "OK";
                ComicPro.StrTenDangNhap = txt_tendangnhap.Text.ToUpper();
                ComicPro.StrThoiGianDangNhap = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Form1.Default.ShowMessageError("Đăng nhập không thành công.");
                txt_tendangnhap.Text = "";
                txt_matkhau.Text = "";
                txt_tendangnhap.Focus();
            }
        }

    }
}