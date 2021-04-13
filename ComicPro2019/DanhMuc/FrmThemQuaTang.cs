using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemQuaTang : XtraForm
    {
        public FrmThemQuaTang()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuaTang.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên quà tặng.");
                txtQuaTang.Focus(); return;
            }
            ExecSQL.ExecProcedureNonData("prottQuaTang", new { action = "SAVE", quatang = txtQuaTang.Text, nguoitao = ComicPro.StrTenDangNhap.ToUpper() });
            Form1.Default.ShowMessageSuccess($"Đã thêm mới quà tặng ({txtQuaTang.Text}) thành công.");
            txtQuaTang.Text = "";
            txtQuaTang.Focus();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "quatang"
            };
            message.Publish();
        }
        private void FrmThemQuaTang_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_Luu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}