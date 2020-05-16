using System;
using System.IO;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmReadComic : DevExpress.XtraEditors.XtraForm
    {
        public FrmReadComic()
        {
            InitializeComponent();
            try
            {
                MdiParent = Form1.Default;
            }
            catch (Exception)
            {
                // throw;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            groupControl1.Visible = false;
            splitterControl1.Visible = false;
            try
            {
                pdfViewer1.LoadDocument(ComicPro.StrDuongDanPdf);
            }
            catch (Exception)
            {
                //Console.WriteLine(exception);
                //throw;
            }

        }

        public async void GetTuaTruyen()
        {
            var dt = await ExecSQL.ExecQueryDataAsyncAsDataTable("SELECT DISTINCT a.matua, b.tuatruyen FROM dbo.tbl_tentruyen a INNER JOIN dbo.tbl_tuatruyen b ON b.matua = a.matua WHERE a.filetruyen=1 ORDER BY b.tuatruyen");
            cbo_tuatruyen.Properties.DataSource = dt;
            cbo_tuatruyen.Properties.ValueMember = "matua";
            cbo_tuatruyen.Properties.DisplayMember = "tuatruyen";
        }

        private bool _flag = true;
        public async void GetTenTruyen()
        {
            if (string.IsNullOrEmpty(cbo_tuatruyen.Text)) { return; }
            var dt = await ExecSQL.ExecQueryDataAsyncAsDataTable($"SELECT a.matruyen, CASE WHEN LEN(a.ghichu)>0 THEN a.ghichu ELSE (CASE WHEN LEN(a.tentruyen)>6 THEN CONCAT(FORMAT(a.tap,'000'),' - ', a.tentruyen) ELSE a.tentruyen END) END AS tentruyen, a.matua FROM dbo.tbl_tentruyen a INNER JOIN dbo.tbl_tuatruyen b ON b.matua = a.matua WHERE a.filetruyen=1 AND a.matua='{cbo_tuatruyen.EditValue}' ORDER BY a.tap");
            dgv_tentruyen.BeginInvoke(new Action(() =>
            {
                dgv_tentruyen.DataSource = dt;
                lbl_matruyen.DataBindings.Clear();
                lbl_matua.DataBindings.Clear();

                lbl_matua.DataBindings.Add("text", dt, "matua");
                lbl_matruyen.DataBindings.Add("text", dt, "matruyen");
            }));
        }
        private void cbo_tuatruyen_EditValueChanged(object sender, EventArgs e)
        {
            GetTenTruyen();
        }

        private void lbl_matruyen_TextChanged(object sender, EventArgs e)
        {
            ComicPro.StrDuongDanPdf = Application.StartupPath + "\\pdf\\" + lbl_matua.Text + "\\" + lbl_matruyen.Text + ".pdf";
            if (File.Exists(ComicPro.StrDuongDanPdf))
            {
                pdfViewer1.LoadDocument(ComicPro.StrDuongDanPdf);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_flag == false)
            {
                groupControl1.Hide();
                splitterControl1.Hide();
                _flag = true;
            }
            else
            {
                GetTuaTruyen();
                groupControl1.Show();
                splitterControl1.Show();
                _flag = false;
            }
        }

        private void btn_rotation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pdfViewer1.RotationAngle += 90;
        }
    }
}