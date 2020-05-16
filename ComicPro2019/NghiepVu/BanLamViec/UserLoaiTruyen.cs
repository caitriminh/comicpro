using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu.BanLamViec
{
    public partial class UserLoaiTruyen : XtraUserControl
    {
        public UserLoaiTruyen()
        {
            InitializeComponent();
        }

        private async void UserLoaiTruyen_Load(object sender, EventArgs e)
        {
            var tong = ExecSQL.ExecQuerySacalar("SELECT COUNT(DISTINCT matruyen) AS tong FROM dbo.tbl_phieunhapxuat WHERE slnhap>0");
            Text = @"Loại truyện: " + tong + @" cuốn";
            var chartControl1 = new ChartControl();
            chartControl1.Dock = DockStyle.Fill;
            panelControl.Controls.Add(chartControl1);
            var dataTable = await ExecSQL.ExecProcedureDataAsyncAsDataTable("pro_get_tongso_loaitruyen");
            await Task.Factory.StartNew(new Action(() =>
             {
                 chartControl1.DataSource = dataTable;
                 chartControl1.BeginInvoke(new Action(() =>
                 {
                     Series seriesloaitruyen = new Series("Loại truyện", ViewType.Bar);
                     seriesloaitruyen.LabelsVisibility = DefaultBoolean.True;
                     // Add points to them, with their arguments different.
                     foreach (DataRow dr in dataTable.Rows)
                     {
                         seriesloaitruyen.Points.Add(new SeriesPoint(dr["loaitruyen"], dr["soluong"]));
                     }
                     chartControl1.Series.AddRange(new Series[] { seriesloaitruyen });
                     chartControl1.Legend.Visibility = DefaultBoolean.True;

                     Legend legend = chartControl1.Legend;
                     legend.Margins.All = 8;
                     legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                     legend.AlignmentVertical = LegendAlignmentVertical.Top;
                     legend.Direction = LegendDirection.LeftToRight;
                 }));
             }));
        }
    }
}
