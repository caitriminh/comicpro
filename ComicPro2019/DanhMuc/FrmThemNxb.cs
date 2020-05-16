using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemNxb : XtraForm
    {
        public FrmThemNxb()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manxb.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào mã nhà xuất bản.");
                txt_nhaxuatban.Focus(); return;
            }

            if (string.IsNullOrEmpty(txt_nhaxuatban.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên nhà xuất bản.");
                txt_nhaxuatban.Focus(); return;
            }
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_nhaxuatban WHERE manxb='{txt_manxb.Text}'")) > 0)
            {
                Form1.Default.ShowMessageWarning($"Mã nhà xuất bản đã tồn tại.");
                txt_manxb.Focus();
                return;
            }

            var nxb = new NXB { manxb = txt_manxb.Text, nhaxuatban = txt_nhaxuatban.Text, diachi = txt_diachi.Text, sodt = txt_sodt.Text, sofax = txt_sofax.Text, ghichu = txt_ghichu.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(nxb);
            Form1.Default.ShowMessageSuccess($"Đã thêm mới nhà xuất bản ({txt_nhaxuatban.Text}) thành công.");
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "nxb"
            };
            message.Publish();
        }

        public void XoaText()
        {
            txt_manxb.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('NXB', FORMAT(ISNULL(RIGHT(MAX(manxb),3),0)+1,'000')) FROM dbo.tbl_nhaxuatban").ToString();
            txt_nhaxuatban.Text = "";
            txt_diachi.Text = "";
            txt_sodt.Text = "";
            txt_sofax.Text = "";
            txt_manxb.Focus();
        }

        private void FrmThemNxb_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmThemNxb_Load(object sender, EventArgs e)
        {
            txt_manxb.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('NXB', FORMAT(ISNULL(RIGHT(MAX(manxb),3),0)+1,'000')) FROM dbo.tbl_nhaxuatban").ToString();
        }
    }
}