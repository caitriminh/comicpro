using SimpleBroker;
using System;
using System.Globalization;
using System.Linq;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmDanhSachTuaTruyen : DevExpress.XtraEditors.XtraForm
    {
        public FrmDanhSachTuaTruyen()
        {
            InitializeComponent();
        }

        private void FrmDanhSachTuaTruyen_Load(object sender, EventArgs e)
        {
            GetDanhMuc();
        }

        public async void GetDanhMuc()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsync<TenTruyen>("pro_get_tentruyen", new { option = 1 });
            dgv_danhmuc.BeginInvoke(new Action(() =>
            {
                dgv_danhmuc.DataSource = dt;

                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));
        }

        private void btn_xacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                Form1.Default.ShowMessageWarning("Bạn vui lòng chọn tên các tập truyện để thực hiện.");
                return;
            }
            var selectedRow = gridView1.GetSelectedRows();
            ComicPro.StrMaTruyen = string.Join(",", from r in selectedRow where gridView1.IsDataRow(Convert.ToInt32(r)) select gridView1.GetRowCellValue(Convert.ToInt32(r), "matruyen"));
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "phieunhapdanhsach"
            };
            message.Publish();
            Close();
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetDanhMuc();
        }
    }
}