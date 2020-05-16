using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemLoaiTruyen : XtraForm
    {
        public FrmThemLoaiTruyen()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maloai.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào mã loại truyện.");
                txt_maloai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_loaitruyen.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên loại truyện.");
                txt_loaitruyen.Focus();
                return;
            }
            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_loaitruyen WHERE maloai='{txt_maloai.Text}'")) > 0)
            {
                Form1.Default.ShowMessageWarning("Mã loại truyện này đã tồn tại.");
                txt_maloai.Text = "";
                txt_maloai.Focus();
                return;
            }
            var loaitruyen = new LoaiTruyen { maloai = txt_maloai.Text, loaitruyen = txt_loaitruyen.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(loaitruyen);
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "loaitruyen"
            };
            message.Publish();
        }

        public void XoaText()
        {
            txt_maloai.Text = "";
            txt_loaitruyen.Text = "";
            txt_maloai.Focus();
        }
        private void FrmThemLoaiTruyen_KeyDown(object sender, KeyEventArgs e)
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