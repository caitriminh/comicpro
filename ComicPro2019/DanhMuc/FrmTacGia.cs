using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmTacGia : XtraForm
    {
        public FrmTacGia()
        {
            InitializeComponent();
        }

        public async void GetTacGia()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var listTacGia = await ExecSQL.ExecQueryDataAsync<TacGia>("SELECT * FROM dbo.tbl_tacgia ORDER BY matacgia");
            dgv_tacgia.BeginInvoke(new Action(() =>
            {
                dgv_tacgia.DataSource = listTacGia;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemTacGia frm = new FrmThemTacGia();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTacGia();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            if (modifined.Count == 0)
            {
                Form1.Default.ShowMessageDefault("Không có dòng dữ liệu nào được thay đổi.");
                return;
            }
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            int dem = 0;
            foreach (var item in modifined)
            {
                var tacgia = gridView1.GetRow(item) as TacGia;
                if (tacgia != null)
                {
                    tacgia.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    tacgia.thoigian2 = DateTime.Now;
                    ExecSQL.Update(tacgia);
                    dem += 1;
                }
            }
            modifined.Clear();
            GetTacGia();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
        }


        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên tác giả ({gridView1.GetRowCellValue(i, "tacgia")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var tacgia = gridView1.GetRow(i) as TacGia;
            var affected = ExecSQL.Delete(tacgia);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tên tác giả ({gridView1.GetRowCellValue(i, "tacgia")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "tacgia")
            {
                GetTacGia();
            }
        }
        private List<int> modifined;
        private void FrmTacGia_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetTacGia();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        private void FrmTacGia_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }
    }
}