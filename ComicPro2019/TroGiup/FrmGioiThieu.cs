using System;
using BUS;

namespace ComicPro2019.TroGiup
{
    public partial class FrmGioiThieu : DevExpress.XtraEditors.XtraForm
    {
        public FrmGioiThieu()
        {
            InitializeComponent();
        }

        private void lbl_web_Click(object sender, EventArgs e)
        {
            ComicPro.OpenUri(lbl_web.Text);
        }

        private void FrmGioiThieu_Load(object sender, EventArgs e)
        {
            BusThongTin busThongTin = new BusThongTin();
            var dt = busThongTin.GetThongTin();
            if (dt.Rows.Count == 0) { return; }

            lbl_tencuahang.Text = dt.Rows[0]["tencuahang"].ToString();
            lbl_diachi.Text = dt.Rows[0]["diachi"].ToString();
            lbl_tinhthanh.Text = dt.Rows[0]["tinhthanh"].ToString();
            lbl_quanhuyen.Text = dt.Rows[0]["quanhuyen"].ToString();
            lbl_email.Text = dt.Rows[0]["email"].ToString();
            lbl_web.Text = dt.Rows[0]["web"].ToString();
        }
    }
}