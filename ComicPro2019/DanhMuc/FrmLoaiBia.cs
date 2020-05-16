using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmLoaiBia : XtraForm
    {
        public FrmLoaiBia()
        {
            InitializeComponent();
        }

        public async void GetLoaiBia()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<LoaiBia>("SELECT * FROM dbo.tbl_loaibia");
            dgv_loaibia.BeginInvoke(new Action(() =>
            {
                dgv_loaibia.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));

        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemLoaiBia frm = new FrmThemLoaiBia();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetLoaiBia();
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
                var loaibia = gridView1.GetRow(item) as LoaiBia;
                if (loaibia != null)
                {
                    loaibia.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    loaibia.thoigian2 = DateTime.Now;
                    ExecSQL.Update(loaibia);
                    dem += 1;
                }
            }
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
            GetLoaiBia();
            modifined.Clear();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên loại bìa ({gridView1.GetRowCellValue(i, "loaibia")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var loaibia = gridView1.GetRow(i) as LoaiBia;
            var affected = ExecSQL.Delete(loaibia);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tên loại bìa ({gridView1.GetRowCellValue(i, "loaibia")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "loaibia")
            {
                GetLoaiBia();
            }
        }

        private List<int> modifined;
        private void FrmLoaiBia_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetLoaiBia();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }
    }
}