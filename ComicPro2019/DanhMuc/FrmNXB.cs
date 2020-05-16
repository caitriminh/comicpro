using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmNxb : XtraForm
    {
        public FrmNxb()
        {
            InitializeComponent();
        }

        public async void GetNxb()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<NXB>("SELECT * FROM dbo.tbl_nhaxuatban");
            dgv_nhaxuatban.BeginInvoke(new Action(() =>
            {
                dgv_nhaxuatban.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemNxb frm = new FrmThemNxb();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetNxb();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageDefault("Không có dòng dữ liệu nào thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var nxb = gridView1.GetRow(item) as NXB;
                if (nxb != null)
                {
                    nxb.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    nxb.thoigian2 = DateTime.Now;
                    ExecSQL.Update(nxb);
                    dem += 1;
                }
            }
            GetNxb();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên nhà xuất bản ({gridView1.GetRowCellValue(i, "nhaxuatban")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var nxb = gridView1.GetRow(i) as NXB;
            var affected = ExecSQL.Delete(nxb);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tên nhà xuất bản ({gridView1.GetRowCellValue(i, "nhaxuatban")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "nxb")
            {
                GetNxb();
            }
        }

        private List<int> modifined;
        private void FrmNXB_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetNxb();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        private void FrmNxb_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = @"Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "NXB_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = ExecSQL.ExecQueryDataAsDataTable("SELECT manxb AS [Mã nhà xuất bản], nhaxuatban AS [Nhà xuất bản], diachi AS [Địa chỉ], sodt AS [Số ĐT], sofax AS [Số Fax], ghichu AS [Ghi chú] FROM dbo.tbl_nhaxuatban ORDER BY nhaxuatban");
                ComicPro.ExportExcelFromDataTable(dt, xtraSaveFileDialog1.FileName);
            }
        }
    }
}