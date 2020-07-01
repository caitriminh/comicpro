using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ComicPro2019.Properties;
using Chilkat;
using System.Diagnostics;
using System.IO;

namespace ComicPro2019
{
    public partial class FrmThietLapHeThong : DevExpress.XtraEditors.XtraForm
    {
        public FrmThietLapHeThong()
        {
            InitializeComponent();
        }

        private void FrmThietLapHeThong_Load(object sender, EventArgs e)
        {
            txt_server.Text = Settings.Default.server;
            txt_user.Text = Settings.Default.user;
            txt_database.Text = Settings.Default.database;
            txt_matkhau.Text = Settings.Default.matkhau;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            Settings.Default.server = txt_server.Text;
            Settings.Default.user = txt_user.Text;
            Settings.Default.database = txt_database.Text;
            Settings.Default.matkhau = txt_matkhau.Text;
            Settings.Default.Save();
            XtraMessageBox.Show("Đã thiết lập cấu hình thành công.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();
        }
    }
}