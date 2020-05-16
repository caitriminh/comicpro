using System;
using DevExpress.XtraReports.UI;

namespace ComicPro2019.NghiepVu
{

    public partial class RptPhieuXuat
    {
        public RptPhieuXuat()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            lbl_maphieu.Text = @"Số: " + ComicPro.DtReport.Rows[0]["maphieu"];
            lbl_ngaythang.Text = @"Ngày  " + Convert.ToDateTime(ComicPro.DtReport.Rows[0]["ngaynhap"]).Day + @"  tháng  " + Convert.ToDateTime(ComicPro.DtReport.Rows[0]["ngaynhap"]).Month + @"  năm  " + Convert.ToDateTime(ComicPro.DtReport.Rows[0]["ngaynhap"]).Year;
            lbl_diachi1.Text = @": " + ComicPro.DtReport.Rows[0]["diachi"]; lbl_donvi.Text = @": " + ComicPro.DtReport.Rows[0]["donvi"];
            lbl_tenkho.Text = @": " + ComicPro.DtReport.Rows[0]["tenkho"];
            lbl_diengiai.Text = @": " + ComicPro.DtReport.Rows[0]["diengiai"];
            lbl_matruyen.DataBindings.Add("Text", DataSource, "matruyen");
            lbl_tentruyen.DataBindings.Add("Text", DataSource, "tentruyen");
            col_donvitinh.DataBindings.Add("Text", DataSource, "donvitinh");
            col_giabia.DataBindings.Add("Text", DataSource, "giabia", "{0:#,##0}");
            col_tap.DataBindings.Add("Text", DataSource, "tap"); col_soluong.DataBindings.Add("Text", DataSource, "slxuat", "{0:#,##0}");
            col_dongia.DataBindings.Add("Text", DataSource, "dongia", "{0:#,##0}");
            col_thanhtien.DataBindings.Add("Text", DataSource, "thanhtien2", "{0:#,##0}");
            stt.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.RecordNumber, "{0:#,##0}");
            col_tongsoluong.DataBindings.Add("Text", DataSource, "slxuat");
            col_tongsoluong.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");

            col_tongthanhtien.DataBindings.Add("Text", DataSource, "thanhtien2");
            col_tongthanhtien.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:#,##0}");
        }

    }
}

