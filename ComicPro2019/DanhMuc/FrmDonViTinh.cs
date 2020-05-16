using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmDonViTinh : XtraForm
    {
        public FrmDonViTinh()
        {
            InitializeComponent();
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "donvitinh")
            {
                GetDonViTinh();
            }
        }

        private List<int> modifined;
        private void FrmDonViTinh_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetDonViTinh();
            gridView1.CellValueChanged += GridView1_CellValueChanged;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        public async void GetDonViTinh()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var dt = await ExecSQL.ExecQueryDataAsync<DonViTinh>("SELECT * FROM dbo.tbl_donvitinh");
            dgv_donvitinh.BeginInvoke(new Action(() =>
            {
                dgv_donvitinh.DataSource = dt;
            }));
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemDonViTinh frm = new FrmThemDonViTinh();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetDonViTinh();
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
                var donvitinh = gridView1.GetRow(item) as DonViTinh;
                if (donvitinh != null)
                {
                    donvitinh.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    donvitinh.thoigian2 = DateTime.Now;
                    ExecSQL.Update(donvitinh);
                    dem += 1;
                }
            }
            GetDonViTinh();
            modifined.Clear();
            Form1.Default.ShowMessageSuccess($"Đã câp nhật {dem} dòng thành công.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên đơn vị tính ({gridView1.GetRowCellValue(i, "donvitinh")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var donvitinh = gridView1.GetRow(i) as DonViTinh;
            var affected = ExecSQL.Delete(donvitinh);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa đơn vị tính ({gridView1.GetRowCellValue(i, "donvitinh")}) thành công.");
                gridView1.DeleteRow(i);
            }
        }

        private void FrmDonViTinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }
    }
}