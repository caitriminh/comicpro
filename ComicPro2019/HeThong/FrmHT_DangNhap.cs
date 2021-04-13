using System;
using System.Windows.Forms;
using ComicPro2019.Extensions;
using DevExpress.XtraEditors;

namespace ComicPro2019.HeThong
{
    public partial class FrmHT_DangNhap : XtraForm
    {
        public string IsLogin { set; get; }
        public string Username { set; get; }
        public FrmHT_DangNhap()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsLogin = "OK";
            Application.Exit();
        }

        /// <summary>
        /// Create by Tri Minh, Date: 07/11/2020
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoginVinaGiay_Load(object sender, EventArgs e)
        {
            txt_tendangnhap.Text = ConfigAppSetting.GetSetting("UserName");

            txt_matkhau.Text = ConfigAppSetting.GetSetting("Password");
            chkGhiNho.Checked = ConfigAppSetting.GetSetting("GhiNho") == "True" ? true : false;
        }

        /// <summary>
        /// Create by Tri Minh, Date: 07/11/2020
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoginVinaGiay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnDangNhap_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_user WHERE tendangnhap='{txt_tendangnhap.Text.ToUpper()}' AND matkhau=CONVERT(VARCHAR(32), HashBytes('MD5', '{txt_matkhau.Text}'), 2)")) > 0)
            {
                ComicPro.StrTenDangNhap = txt_tendangnhap.Text.ToUpper();
                //Gửi dữ liệu load form chính

                IsLogin = "OK";
                Username = txt_tendangnhap.Text.Trim();
                DialogResult = DialogResult.OK;
                if (chkGhiNho.Checked)
                {
                    ConfigAppSetting.SetSetting("UserName", txt_tendangnhap.Text);
                    ConfigAppSetting.SetSetting("Password", txt_matkhau.Text);
                    ConfigAppSetting.SetSetting("GhiNho", "True");
                }
                Close();
            }
            else
            {
                txt_tendangnhap.Text = "";
                txt_matkhau.Text = "";
                txt_tendangnhap.Focus();
                XtraMessageBox.Show("Đăng nhập không thành công.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Create by Tri Minh, Date: 07/11/2020
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoginVinaGiay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsLogin != "OK")
                e.Cancel = true;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}