using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComicPro2019.HeThong;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmReport : XtraForm
    {
        public FrmReport()
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
            WindowState = FormWindowState.Maximized;
            switch (ComicPro.Report)
            {
                case 1:
                    {
                        Text = @"Danh Sách Truyện Tranh";
                        var rpt = new RptDanhSachTruyenTranh();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
                case 2:
                    {
                        Text = @"Danh Sách Truyện Tranh";
                        var rpt = new RptDanhSachTruyenTranh2();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
                case 3:
                    {
                        Text = @"Phiếu Nhập";
                        var rpt = new RptPhieuNhap();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
                case 4:
                    {
                        Text = @"Phiếu Xuất";
                        var rpt = new RptPhieuXuat();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
                case 5:
                    {
                        Text = @"Tồn Kho";
                        var rpt = new RptTonKho();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
                case 6:
                    {
                        Text = @"Danh Mục";
                        var rpt = new RptMaster();
                        documentViewer1.PrintingSystem = rpt.PrintingSystem;
                        rpt.DataSource = ComicPro.DtReport;
                        rpt.BindData();
                        rpt.CreateDocument();
                    }
                    break;
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}