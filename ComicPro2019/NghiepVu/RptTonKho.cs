using System;
using DevExpress.XtraReports.UI;

namespace ComicPro2019.NghiepVu
{

    public partial class RptTonKho
    {
        public RptTonKho()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            GroupHeaderBand1.GroupFields.Add(new GroupField("tuatruyen", XRColumnSortOrder.Ascending));
            lbl_tuatruyen.DataBindings.Add("Text", null, "tuatruyen", "{0}");
            lbl_ky.Text = @"Kỳ " + Convert.ToDateTime(ComicPro.DtReport.Rows[0]["ky"]).Month + @"/" + Convert.ToDateTime(ComicPro.DtReport.Rows[0]["ky"]).Year;
            lbl_matruyen.DataBindings.Add("Text", DataSource, "matruyen");
            lbl_tentruyen.DataBindings.Add("Text", DataSource, "tentruyen"); col_donvitinh.DataBindings.Add("Text", DataSource, "donvitinh");
            col_nhaptrongky.DataBindings.Add("Text", DataSource, "nhaptrongky", "{0:#,##0}");
            col_xuattrongky.DataBindings.Add("Text", DataSource, "xuattrongky", "{0:#,##0}");
            col_soducuoiky.DataBindings.Add("Text", DataSource, "soducuoiky", "{0:#,##0}");
            col_sodudauky.DataBindings.Add("Text", DataSource, "sodudauky", "{0:#,##0}");
            col_tong_sodudauky.DataBindings.Add("Text", DataSource, "sodudauky");
            col_tong_sodudauky.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");

            col_tong_nhaptrongky.DataBindings.Add("Text", DataSource, "nhaptrongky");
            col_tong_nhaptrongky.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");

            col_tong_xuattrongky.DataBindings.Add("Text", DataSource, "xuattrongky");
            col_tong_xuattrongky.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");

            col_tong_soducuoiky.DataBindings.Add("Text", DataSource, "soducuoiky"); col_tong_soducuoiky.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");

            col_tong2_sodudauky.DataBindings.Add("Text", DataSource, "sodudauky");
            col_tong2_sodudauky.Summary = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:#,##0}");

            col_tong2_nhaptrongky.DataBindings.Add("Text", DataSource, "nhaptrongky");
            col_tong2_nhaptrongky.Summary = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:#,##0}");

            col_tong2_xuattrongky.DataBindings.Add("Text", DataSource, "xuattrongky");
            col_tong2_xuattrongky.Summary = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:#,##0}");

            col_tong2_soducuoiky.DataBindings.Add("Text", DataSource, "soducuoiky");
            col_tong2_soducuoiky.Summary = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:#,##0}");

            stt.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.RecordNumber, "{0:#,##0}");
        }

    }
}

