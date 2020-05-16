using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmThemDonVi : XtraForm
    {
        public FrmThemDonVi()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_donvi.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên đơn vị.");
                txt_donvi.Focus(); return;
            }
            if (string.IsNullOrEmpty(txt_donvi.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập nhóm đơn vị.");
                cbo_nhomdonvi.Focus(); return;
            }
            var donvi = new DonVi { madonvi = txt_madonvi.Text, donvi = txt_donvi.Text, manhom = Convert.ToInt32(cbo_nhomdonvi.EditValue), diachi = txt_diachi.Text, sodt = txt_sodt.Text, sofax = txt_sofax.Text, email = txt_email.Text, ghichu = txt_ghichu.Text, nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(donvi);
            Form1.Default.ShowMessageSuccess($"Đã thêm mới đơn vị ({txt_donvi.Text}) thành công.");
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "donvi"
            };
            message.Publish();
        }


        public void XoaText()
        {
            txt_madonvi.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('DV', FORMAT(ISNULL(RIGHT(MAX(madonvi),3),0)+1,'000')) FROM dbo.tbl_donvi").ToString();
            txt_donvi.Text = "";
            txt_diachi.Text = "";
            txt_sodt.Text = "";
            txt_sofax.Text = "";
            txt_email.Text = "";
            cbo_nhomdonvi.EditValue = DBNull.Value;
            txt_donvi.Focus();
        }
        public async void GetNhomDonVi()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<NhomDonVi>("SELECT id, nhomdonvi FROM dbo.tbl_nhomdonvi");
            cbo_nhomdonvi.Properties.DataSource = dt;
            cbo_nhomdonvi.Properties.DisplayMember = "nhomdonvi";
            cbo_nhomdonvi.Properties.ValueMember = "id";
        }
        private void FrmThemDonVi_Load(object sender, EventArgs e)
        {
            txt_madonvi.Text = ExecSQL.ExecQuerySacalar("SELECT CONCAT('DV', FORMAT(ISNULL(RIGHT(MAX(madonvi),3),0)+1,'000')) FROM dbo.tbl_donvi").ToString();
            GetNhomDonVi();
        }

        private void FrmThemDonVi_KeyDown(object sender, KeyEventArgs e)
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