using ComicPro2019.Extensions;
using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmTuaTruyen : XtraForm
    {
        public FrmTuaTruyen()
        {
            InitializeComponent();

            grvViewTuaTruyen.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcTuaTruyen, grvViewTuaTruyen); };
            grvViewTuaTruyen.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcTuaTruyen, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcTuaTruyen, Name);
        }

        public async void GetTuatruyen()
        {
            var x = grvViewTuaTruyen.FocusedRowHandle;
            var y = grvViewTuaTruyen.TopRowIndex;
            var dt = await ExecSQL.ExecProcedureDataAsync<TuaTruyen>("pro_get_tuatruyen", new { option = 1 });
            grcTuaTruyen.BeginInvoke(new Action(() =>
            {
                grcTuaTruyen.DataSource = dt;
                grvViewTuaTruyen.FocusedRowHandle = x;
                grvViewTuaTruyen.TopRowIndex = y;
            }));
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemTuaTruyen frm = new FrmThemTuaTruyen();
            frm.Show(this);
        }
        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTuatruyen();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvViewTuaTruyen.PostEditor();
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
                var tuatruyen = grvViewTuaTruyen.GetRow(item) as TuaTruyen;
                if (tuatruyen != null)
                {
                    tuatruyen.nguoitd2 = ComicPro.StrTenDangNhap.ToUpper();
                    tuatruyen.thoigian2 = DateTime.Now;
                    ExecSQL.Update(tuatruyen);
                    dem += 1;
                }
            }
            modifined.Clear();
            GetTuatruyen();
            Form1.Default.ShowMessageSuccess($"Đã cập nhật thành công {dem} dòng.");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = grvViewTuaTruyen.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên tựa truyện ({grvViewTuaTruyen.GetRowCellValue(i, "tuatruyen")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var tuatruyen = grvViewTuaTruyen.GetRow(i) as TuaTruyen;
            var affected = ExecSQL.Delete(tuatruyen);
            if (affected)
            {
                Form1.Default.ShowMessageSuccess($"Đã xóa tựa truyện ({grvViewTuaTruyen.GetRowCellValue(i, "tuatruyen")}) thành công.");
                grvViewTuaTruyen.DeleteRow(i);
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "tuatruyen")
            {
                GetTuatruyen();
            }
        }

        private List<int> modifined;
        private void FrmTuaTruyen_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            modifined = new List<int>();
            GetLoaiTruyen();
            GetQuocGia();
            GetTacGia();
            GetNhaXuatBan();
            GetTuatruyen();
            grvViewTuaTruyen.CellValueChanged += GridView5_CellValueChanged;
        }

        private void GridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!modifined.Contains(e.RowHandle)) { modifined.Add(e.RowHandle); }
        }

        public async void GetLoaiTruyen()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<LoaiTruyen>("SELECT maloai, loaitruyen FROM dbo.tbl_loaitruyen ORDER BY loaitruyen");
            cbo_loaitruyen2.DataSource = dt;
            cbo_loaitruyen2.DisplayMember = "loaitruyen";
            cbo_loaitruyen2.ValueMember = "maloai";
        }

        public async void GetQuocGia()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<QuocGia>("SELECT id, quocgia FROM dbo.tbl_quocgia ORDER BY quocgia");
            cbo_quocgia2.DataSource = dt;
            cbo_quocgia2.DisplayMember = "quocgia";
            cbo_quocgia2.ValueMember = "id";
        }

        public async void GetTacGia()
        {
            var listTacGia = await ExecSQL.ExecQueryDataAsync<TacGia>("SELECT matacgia, tacgia FROM dbo.tbl_tacgia ORDER BY tacgia");
            cbo_tacgia2.DataSource = listTacGia;
            cbo_tacgia2.DisplayMember = "tacgia";
            cbo_tacgia2.ValueMember = "matacgia";
        }

        public async void GetNhaXuatBan()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<NXB>("SELECT manxb, nhaxuatban FROM dbo.tbl_nhaxuatban ORDER BY nhaxuatban");
            cbo_nxb2.DataSource = dt;
            cbo_nxb2.DisplayMember = "nhaxuatban";
            cbo_nxb2.ValueMember = "manxb";
        }
    }
}