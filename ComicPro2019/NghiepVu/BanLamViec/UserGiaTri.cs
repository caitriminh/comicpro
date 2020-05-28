using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu.BanLamViec
{
    public partial class UserGiaTri : DevExpress.XtraEditors.XtraUserControl
    {
        public UserGiaTri()
        {
            InitializeComponent();
        }

        private void UserGiaTri_Load(object sender, EventArgs e)
        {
            var tong = ExecSQL.ExecQuerySacalar("SELECT SUM(slnhap*dongia) AS tong FROM dbo.tbl_phieunhapxuat");
            Text = @"Giá trị: " + string.Format("{0:#,##}", tong) + @" VND";
            var chartControl1 = new ChartControl();
            chartControl1.Dock = DockStyle.Fill;
            panelControl.Controls.Add(chartControl1);
            Task.Factory.StartNew(() =>
            {
                var dataTable = ExecSQL.ExecProcedureDataAsDataTable("pro_get_thongke_theothang");
                chartControl1.DataSource = dataTable;
                chartControl1.BeginInvoke(new Action(() =>
                {

                    Series seriesGiatri = new Series("Giá trị", ViewType.Line);
                    seriesGiatri.LabelsVisibility = DefaultBoolean.True;

                    foreach (DataRow dr in dataTable.Rows)
                    {
                        seriesGiatri.Points.Add(new SeriesPoint(dr["thangnam"], dr["thanhtien"]));
                    }

                    seriesGiatri.Label.TextPattern = "{V:#,##0}";

                    chartControl1.Series.AddRange(new[] { seriesGiatri });
                    chartControl1.Legend.Visibility = DefaultBoolean.True;

                    Legend legend = chartControl1.Legend;
                    // chartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.Center
                    legend.Margins.All = 8;
                    legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                    legend.AlignmentVertical = LegendAlignmentVertical.Top;
                    legend.Direction = LegendDirection.LeftToRight;

                }));

            });
        }

        private void chartControl1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            //if (e.Item.Axis is AxisX)
            //    e.Item.Text = "Tháng " + Convert.ToDateTime(e.Item.Text).ToString("MM-yyyy");
        }
    }
}
