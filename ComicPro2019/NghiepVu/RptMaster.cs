using System.Drawing.Printing;
using DevExpress.XtraReports.UI;

namespace ComicPro2019.NghiepVu
{
    public partial class RptMaster : XtraReport
    {
        public RptMaster()
        {
            InitializeComponent();
        }


        public void BindData()
        {
            xrSubreport1.ReportSource = new RptDetail();
            xrSubreport2.ReportSource = new RptDetail();
            DataSource = ComicPro.DtReport;
        }

        private void xrSubreport1_BeforePrint(object sender, PrintEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.FilterString = "[stt] % 2 != 0";
        }

        private void xrSubreport2_BeforePrint(object sender, PrintEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.FilterString = "[stt] % 2 = 0";
        }
    }
}
