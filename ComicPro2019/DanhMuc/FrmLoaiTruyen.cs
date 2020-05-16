using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmLoaiTruyen : XtraForm
    {
        public FrmLoaiTruyen()
        {
            InitializeComponent();
        }

        public async void GetLoaiTruyen()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<LoaiTruyen>("SELECT * FROM dbo.tbl_loaitruyen");
            dgv_loaitruyen.BeginInvoke(new Action(() =>
            {
                dgv_loaitruyen.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemLoaiTruyen frm = new FrmThemLoaiTruyen();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetLoaiTruyen();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageDefault($"Không có dòng nào thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var loaitruyen = gridView1.GetRow(item) as LoaiTruyen;
                if (loaitruyen != null)
                {
                    loaitruyen.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    loaitruyen.thoigian2 = DateTime.Now;
                    ExecSQL.Update(loaitruyen);
                    dem += 1;
                }
            }
            GetLoaiTruyen();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật {dem} dòng thành công.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa loại truyện ({gridView1.GetRowCellValue(i, "loaitruyen")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var loaitruyen = gridView1.GetRow(i) as LoaiTruyen;
            var affected = ExecSQL.Delete(loaitruyen);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa loại truyện ({gridView1.GetRowCellValue(i, "loaitruyen")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "loaitruyen")
            {
                GetLoaiTruyen();
            }
        }

        private List<int> modifined;
        private void FrmLoaiTruyen_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetLoaiTruyen();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }
    }
}