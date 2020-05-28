using System;

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
            var dt = ExecSQL.ExecQueryDataFistOrDefault<ThongTin>("SELECT * FROM dbo.tbl_thongtin");
            if (dt == null) { return; }
            lbl_tencuahang.Text = dt.tencuahang;
            lbl_diachi.Text = dt.diachi;
            lbl_tinhthanh.Text = dt.tinhthanh;
            lbl_quanhuyen.Text = dt.quanhuyen;
            lbl_email.Text = dt.email;
            lbl_web.Text = dt.web;
        }
    }
}