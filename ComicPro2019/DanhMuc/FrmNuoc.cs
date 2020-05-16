using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmNuoc : XtraForm
    {
        public FrmNuoc()
        {
            InitializeComponent();
        }

        public async void GetQuocGia()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<QuocGia>("SELECT * FROM dbo.tbl_quocgia");
            dgv_nuoc.BeginInvoke(new Action(() =>
            {
                dgv_nuoc.DataSource = dt;
                gridView1.FocusedRowHandle = x;
                gridView1.TopRowIndex = y;
            }));
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemNuoc frm = new FrmThemNuoc();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetQuocGia();
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
                var quocgia = gridView1.GetRow(item) as QuocGia;
                if (quocgia != null)
                {
                    quocgia.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    quocgia.thoigian2 = DateTime.Now;
                    ExecSQL.Update(quocgia);
                    dem += 1;
                }
            }
            GetQuocGia();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật {dem} dòng thành công.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa quốc gia ({gridView1.GetRowCellValue(i, "quocgia")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var quocgia = gridView1.GetRow(i) as QuocGia;
            var affected = ExecSQL.Delete(quocgia);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa quốc gia ({gridView1.GetRowCellValue(i, "quocgia")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "quocgia")
            {
                GetQuocGia();
            }
        }

        private List<int> modifined;
        private void FrmNuoc_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetQuocGia();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }
    }
}