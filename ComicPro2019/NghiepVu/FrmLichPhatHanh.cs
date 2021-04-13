using ComicPro2019.Extensions;
using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmLichPhatHanh : XtraForm
    {
        public FrmLichPhatHanh()
        {
            InitializeComponent();
            grvViewChiTietLichPhatHanh.CustomRowCellEdit += GrvViewChiTietLichPhatHanh_CustomRowCellEdit;
            grvViewChiTietLichPhatHanh.RowCellClick += GrvViewChiTietLichPhatHanh_RowCellClick;

            grvViewLichPhatHanh.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcLichPhatHanh, grvViewLichPhatHanh); };
            grvViewLichPhatHanh.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcLichPhatHanh, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcLichPhatHanh, Name);

            grvViewChiTietLichPhatHanh.CustomDrawRowIndicator += (ss, ee) => { GridViewHelper.GridView_CustomDrawRowIndicator(ss, ee, grcChiTietLichPhatHanh, grvViewChiTietLichPhatHanh); };
            grvViewChiTietLichPhatHanh.PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, grcChiTietLichPhatHanh, Name); };
            GridViewHelper.SaveAndRestoreLayout(grcChiTietLichPhatHanh, Name);
        }

        private void GrvViewChiTietLichPhatHanh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = grvViewChiTietLichPhatHanh.FocusedRowHandle;
            if (i < 0) { return; }
            if (e.Column == colXacNhan)
            {
                ExecSQL.ExecProcedureNonData("pro_insert_ct_lichphathanh", new { action = "DAMUA", id = Convert.ToInt32(grvViewChiTietLichPhatHanh.GetRowCellValue(i, "id")) });
                GetChiTietLichPhatHanh();
            }
            else if (e.Column == colXoa)
            {
                var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa chi tiết lịch phát hành ({grvViewChiTietLichPhatHanh.GetRowCellValue(i, "tuatruyen")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
                if (dgr != DialogResult.Yes) { return; }
                ExecSQL.ExecProcedureNonData("pro_delete_ct_lichphathanh", new { id = Convert.ToInt32(grvViewChiTietLichPhatHanh.GetRowCellValue(i, "id")) });
                GetChiTietLichPhatHanh();
            }
        }

        private void GrvViewChiTietLichPhatHanh_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colXacNhan)
                {
                    if (grvViewChiTietLichPhatHanh.GetRowCellValue(e.RowHandle, "tinhtrang").ToString() == "Đã mua")
                    {
                        e.RepositoryItem = btnThuHoi;
                    }
                    else
                    {
                        e.RepositoryItem = btnXacNhan;
                    }
                }
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "lichphathanh")
            {
                GetLichPhatHanh();
            }
        }

        public void GetLichPhatHanh()
        {
            var x = grvViewLichPhatHanh.FocusedRowHandle;
            var y = grvViewLichPhatHanh.TopRowIndex;
            var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_lichphathanh", new { action = "TATCA" });
            grcLichPhatHanh.DataSource = dt;
            lbl_malich.DataBindings.Clear();
            lbl_malich.DataBindings.Add("text", dt, "malich");
            grvViewLichPhatHanh.FocusedRowHandle = x;
            grvViewLichPhatHanh.TopRowIndex = y;
        }

        public void GetChiTietLichPhatHanh()
        {
            var x = grvViewChiTietLichPhatHanh.FocusedRowHandle;
            var y = grvViewChiTietLichPhatHanh.TopRowIndex;
            var dt = ExecSQL.ExecProcedureDataAsDataTable("pro_get_ct_lichphathanh", new { malich = lbl_malich.Text });
            grcChiTietLichPhatHanh.DataSource = dt;

            grvViewChiTietLichPhatHanh.FocusedRowHandle = x;
            grvViewChiTietLichPhatHanh.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemDonViTinh frm = new FrmThemDonViTinh();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetLichPhatHanh();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbl_malich.Focus();
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            for (var index = 0; index <= grvViewChiTietLichPhatHanh.RowCount - 1; index++)
            {
                var dr = grvViewChiTietLichPhatHanh.GetDataRow(Convert.ToInt32(index));
                if (dr is null)
                {
                    break;
                }
                if (dr.RowState == DataRowState.Modified)
                {
                    ExecSQL.ExecProcedureNonData("pro_insert_ct_lichphathanh", new { action = "UPDATE", ngayphathanh = Convert.ToDateTime(dr["ngayphathanh1"]).ToString("yyyyMMdd"), tuatruyen = dr["tuatruyen"].ToString(), giabia = Convert.ToDecimal(dr["giabia"]), nguoitd2 = ComicPro.StrTenDangNhap, id = Convert.ToInt32(dr["id"]) });
                }
            }
            GetChiTietLichPhatHanh();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = grvViewLichPhatHanh.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa lịch phát hành ({grvViewLichPhatHanh.GetRowCellValue(i, "malich")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecProcedureNonData("pro_delete_lichphathanh", new { malich = grvViewLichPhatHanh.GetRowCellValue(i, "malich") });
            GetLichPhatHanh();
        }

        private void FrmLichPhatHanh_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetLichPhatHanh();
        }

        private void FrmLichPhatHanh_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe<MessageBroker>();
        }

        private void lbl_malich_TextChanged(object sender, EventArgs e)
        {
            GetChiTietLichPhatHanh();
        }
    }
}