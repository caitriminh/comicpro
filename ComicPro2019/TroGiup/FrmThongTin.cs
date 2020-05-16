using System;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;

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

        BusThongTin _busThongTin = new BusThongTin();
        public void GetThongTin()
        {
            var dt = _busThongTin.GetThongTin();
            if (dt.Rows.Count == 0) { return; }
            txt_tencuahang.Text = dt.Rows[0]["tencuahang"].ToString();
            txt_diachi.Text = dt.Rows[0]["diachi"].ToString();
            txt_tinhthanh.Text = dt.Rows[0]["tinhthanh"].ToString();
            txt_quanhuyen.Text = dt.Rows[0]["quanhuyen"].ToString();
            txt_email.Text = dt.Rows[0]["email"].ToString();
            txt_sodt.Text = dt.Rows[0]["sodt"].ToString();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn lưu lại những thông tin này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr != DialogResult.Yes) { return; }
            _busThongTin.Insert(txt_tencuahang.Text, txt_diachi.Text, txt_tinhthanh.Text, txt_quanhuyen.Text, txt_email.Text, txt_sodt.Text, txt_web.Text);
        }
    }
}