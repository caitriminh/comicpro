using System;
using System.Windows.Forms;
using ComicPro2019.HeThong;
using ComicPro2019.Properties;
using DevExpress.XtraEditors;

namespace ComicPro2019.TroGiup
{
    public partial class FrmDangKy : XtraForm
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (Settings.Default.key.Length == 0)
            {
                Application.Exit();
            }
            else
            {
                Close();
            }
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            txt_serial.Text = Config.CreateMd5(Config.GetSerialHdd().Trim());
            if (Settings.Default.key.Length == 0)
            {
                txt_key.Properties.ReadOnly = false;
                btn_dangky.Text = @"&Đăng ký";
            }
            else
            {
                txt_key.Properties.ReadOnly = true;
                btn_dangky.Text = @"&Hủy đăng ký";
                txt_key.Text = Config.Encrypt(Settings.Default.key);
            }
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            if (btn_dangky.Text == @"&Đăng ký")
            {
                if (string.IsNullOrEmpty(txt_key.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập key vào để đăng ký phần mềm.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //DataProvider provider = new DataProvider();
                string hddSerial = Config.Encrypt(Config.CreateMd5(Config.GetSerialHdd().Trim()));
                // kiểm tra key có đúng không
                string keyDecrypt = Config.Decrypt(txt_key.Text);


                if (Config.Decrypt(hddSerial).Equals(keyDecrypt))
                {
                    Settings.Default.key = keyDecrypt;
                    Settings.Default.Save();

                    Hide();
                    var frm = new FrmDangnhap();
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Key không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var dgr = XtraMessageBox.Show("Bạn có muốn hủy đăng ký không?", "Xác Nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dgr != DialogResult.Yes) { return; }
                Settings.Default.key = "";
                Settings.Default.Save();

                txt_key.Text = "";
                txt_key.Properties.ReadOnly = false;
                txt_key.Focus();
            }
        }
    }
}