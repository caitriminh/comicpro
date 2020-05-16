using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemTacGia : XtraForm
    {
        public FrmThemTacGia()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_matacgia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào mã tác giả.");
                txt_matacgia.Focus(); return;
            }
            if (string.IsNullOrEmpty(txt_tentacgia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên tác giả.");
                txt_tentacgia.Focus(); return;
            }
            var tacgia = new TacGia { matacgia = txt_matacgia.Text, tacgia = txt_tentacgia.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(tacgia);
            ComicPro.StrMaTacGia = txt_matacgia.Text;
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "tacgia"
            };
            message.Publish();
        }

        public void XoaText()
        {
            txt_matacgia.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('TG', FORMAT(RIGHT(ISNULL(MAX(matacgia),0),3)+1,'000')) FROM dbo.tbl_tacgia").ToString();
            txt_tentacgia.Text = "";
            txt_tentacgia.Focus();
        }

        private void FrmThemTacGia_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmThemTacGia_Load(object sender, EventArgs e)
        {
            txt_matacgia.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('TG', FORMAT(RIGHT(ISNULL(MAX(matacgia),0),3)+1,'000')) FROM dbo.tbl_tacgia").ToString();
        }
    }
}