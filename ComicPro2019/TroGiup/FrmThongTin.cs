using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.TroGiup
{
    public partial class FrmThongTin : XtraForm
    {
        public FrmThongTin()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmThongTin_Load(object sender, EventArgs e)
        {
            txt_serial.Text = Config.CreateMd5(Config.GetSerialHdd().Trim());
            GetThongTin();
            txt_tennguoidung.Text = ComicPro.StrTenDangNhap.ToUpper();
            txt_ngaydangnhap.Text = ComicPro.StrThoiGianDangNhap;
        }

        public void GetThongTin()
        {
            var dt = ExecSQL.ExecQueryDataFistOrDefault<ThongTin>("SELECT * FROM dbo.tbl_thongtin");
            if (dt == null) { return; }
            txt_tencuahang.Text = dt.tencuahang;
            txt_diachi.Text = dt.diachi;
            txt_tinhthanh.Text = dt.tinhthanh;
            txt_quanhuyen.Text = dt.quanhuyen;
            txt_email.Text = dt.email;
            txt_sodt.Text = dt.sodt;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var thongtin = new ThongTin { tencuahang = txt_tencuahang.Text, diachi = txt_diachi.Text, tinhthanh = txt_tinhthanh.Text, quanhuyen = txt_quanhuyen.Text, email = txt_email.Text, sodt = txt_sodt.Text, web = txt_web.Text };
            ExecSQL.Insert(thongtin);
        }
    }
}