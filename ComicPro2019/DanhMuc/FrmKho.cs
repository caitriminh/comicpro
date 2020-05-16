using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmKho : XtraForm
    {
        public FrmKho()
        {
            InitializeComponent();
        }

        public async void GetKho()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var listKho = await ExecSQL.ExecQueryDataAsync<Kho>("SELECT * FROM dbo.tbl_kho");
            dgv_kho.BeginInvoke(new Action(() =>
            {
                dgv_kho.DataSource = listKho;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemKho frm = new FrmThemKho();
            frm.Show(this);
        }
        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetKho();
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
                var kho = gridView1.GetRow(item) as Kho;
                if (kho != null)
                {
                    kho.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    kho.thoigian2 = DateTime.Now;
                    ExecSQL.Update(kho);
                    dem += 1;
                }
            }
            GetKho();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật {dem} dòng thành công.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên kho ({gridView1.GetRowCellValue(i, "tenkho")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var kho = gridView1.GetRow(i) as Kho;
            var affected = ExecSQL.Delete(kho);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tên kho ({gridView1.GetRowCellValue(i, "tenkho")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "kho")
            {
                GetKho();
            }
        }

        private List<int> modifined;
        private void FrmKho_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetKho();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        private void FrmKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }
    }
}