using System;
using DevExpress.XtraReports.UI;

namespace ComicPro2019.NghiepVu
{

    public partial class RptDanhSachTruyenTranh2
    {
        public RptDanhSachTruyenTranh2()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            GroupHeaderBand1.GroupFields.Add(new GroupField("tuatruyen", XRColumnSortOrder.Ascending));
            lbl_tuatruyen.DataBindings.Add("Text", null, "tuatruyen", "{0}");

            lbl_matruyen.DataBindings.Add("Text", DataSource, "matruyen");
            lbl_tentruyen.DataBindings.Add("Text", DataSource, "tentruyen"); lbl_tacgia.DataBindings.Add("Text", DataSource, "tacgia");
            lbl_giabia.DataBindings.Add("Text", DataSource, "giabia", "{0:#,##0}");
            lbl_tap.DataBindings.Add("Text", DataSource, "tap");
            lbl_hinhthuc.DataBindings.Add("Text", DataSource, "loaibia");
            lbl_taiban.DataBindings.Add("Text", DataSource, "taiban");
            stt.Summary = new XRSummary(SummaryRunning.Report, SummaryFunc.RecordNumber, "{0:#,##0}");
        }

    }
}

