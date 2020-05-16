using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemKho : XtraForm
    {
        public FrmThemKho()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_makho.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào mã kho.");
                txt_makho.Focus(); return;
            }
            if (string.IsNullOrEmpty(txt_tenkho.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên kho.");
                txt_tenkho.Focus(); return;
            }

            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_kho WHERE makho='{txt_makho.Text}'")) > 0)
            {
                Form1.Default.ShowMessageError("Mã kho này đã tồn tại.");
                txt_makho.Focus(); return;
            }
            var kho = new Kho { makho = txt_makho.Text, tenkho = txt_tenkho.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(kho);
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "kho"
            };
            message.Publish();
        }

        public void XoaText()
        {
            txt_makho.Text = "";
            txt_tenkho.Text = "";
            txt_makho.Focus();
        }

        private void FrmThemKho_KeyDown(object sender, KeyEventArgs e)
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