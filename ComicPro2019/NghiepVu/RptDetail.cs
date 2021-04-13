using DevExpress.XtraReports.UI;

namespace ComicPro2019.NghiepVu
{

    public partial class RptDetail
    {
        public RptDetail()
        {
            InitializeComponent();

            DataSource = ComicPro.DtReport;
            GroupHeader1.GroupFields.Add(new GroupField("tuatruyen", XRColumnSortOrder.Ascending));
            xrLabel1.DataBindings.Add("Text", null, "tuatruyen", "{0}");

            lbl_sotrang.DataBindings.Add("Text", DataSource, "sotrang", "Số trang: {0}");
            lbl_tentruyen.DataBindings.Add("Text", DataSource, "tentruyen");
            lbl_tacgia.DataBindings.Add("Text", DataSource, "tacgia", "Tác giả: {0}");
            lbl_giabia2.DataBindings.Add("Text", DataSource, "giabia", "Giá bìa: {0:#,##0}");
            lbl_tap.DataBindings.Add("Text", DataSource, "tap", "Tập: {0}");
            lbl_nxb.DataBindings.Add("Text", DataSource, "nhaxuatban", "NXB: {0}");
            lbl_ngayxuatban.DataBindings.Add("Text", DataSource, "ngayxuatban", "Ngày xuất bản: {0:dd/MM/yyyy}");
            XrPictureBox1.DataBindings.Add(new XRBinding("ImageUrl", DataSource, "hinhanh"));
        }

       
        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //_stt++;
            //xrLabel2.Text = _stt.ToString();
        }
    }
}

