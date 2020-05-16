using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemDonViTinh : XtraForm
    {
        public FrmThemDonViTinh()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tendvt.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên đơn vị tính.");
                txt_tendvt.Focus(); return;
            }
            var donvitinh = new DonViTinh { donvitinh = txt_tendvt.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(donvitinh);
            Form1.Default.ShowMessageSuccess($"Đã thêm mới đơn vị tính ({txt_tendvt.Text}) thành công.");
            txt_tendvt.Text = "";
            txt_tendvt.Focus();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "donvitinh"
            };
            message.Publish();
        }

        private void FrmThemDonViTinh_KeyDown(object sender, KeyEventArgs e)
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