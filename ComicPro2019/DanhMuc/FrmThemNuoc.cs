using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemNuoc : XtraForm
    {
        public FrmThemNuoc()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tennuoc.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên nước.");
                txt_tennuoc.Focus(); return;
            }
            var quocgia = new QuocGia { quocgia = txt_tennuoc.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(quocgia);
            Form1.Default.ShowMessageSuccess($"Đã thêm tên nước ({txt_tennuoc.Text}) thành công.");
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "quocgia"
            };
            message.Publish();
        }

        public void XoaText()
        {
            txt_tennuoc.Text = "";
            txt_tennuoc.Focus();
        }
        private void FrmThemNuoc_KeyDown(object sender, KeyEventArgs e)
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