using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemLoaiBia : XtraForm
    {
        public FrmThemLoaiBia()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_loaibia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên loại bìa.");
                txt_loaibia.Focus(); return;
            }
            ExecSQL.ExecProcedureNonData("pro_insert_loaibia", new { loaibia = txt_loaibia.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() });
            txt_loaibia.Text = "";
            txt_loaibia.Focus();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "loaibia"
            };
            message.Publish();
        }


        private void FrmThemLoaiBia_KeyDown(object sender, KeyEventArgs e)
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