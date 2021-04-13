using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019.DanhMuc
{
    public partial class FrmQuaTang : XtraForm
    {
        public FrmQuaTang()
        {
            InitializeComponent();
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "quatang")
            {
                GetQuaTang();
            }
        }

        public void GetQuaTang()
        {
            var x = grvViewQuaTang.FocusedRowHandle;
            var y = grvViewQuaTang.TopRowIndex;
            var dt = ExecSQL.ExecProcedureDataAsDataTable("prottQuaTang", new { action = "GET_DATA" });
            grcQuaTang.DataSource = dt;
            grvViewQuaTang.FocusedRowHandle = x;
            grvViewQuaTang.TopRowIndex = y;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThemQuaTang frm = new FrmThemQuaTang();
            frm.Show(this);
        }

        private void btn_naplai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetQuaTang();
        }

        private void LuuQuaTang()
        {
            for (var index = 0; index <= grvViewQuaTang.RowCount - 1; index++)
            {
                var dr = grvViewQuaTang.GetDataRow(Convert.ToInt32(index));
                if (dr is null)
                {
                    break;
                }
                if (dr.RowState == DataRowState.Modified)
                {
                    ExecSQL.ExecProcedureNonData("prottQuaTang", new { action = "UPDATE", quatang = dr["quatang"].ToString(), maquatang = dr["maquatang"].ToString(), nguoisua = ComicPro.StrTenDangNhap.ToUpper() });
                }
            }
            GetQuaTang();
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvViewQuaTang.PostEditor();
            var dgr = HelperMessage.Instance.ShowMessageYesNo("Bạn có muốn lưu lại những thông tin thay đổi này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            LuuQuaTang();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = grvViewQuaTang.FocusedRowHandle;
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn xóa tên quà tặng ({grvViewQuaTang.GetRowCellValue(i, "quatang")}) này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            var dt = ExecSQL.ExecProcedureDataAsDataTable("prottQuaTang", new { action = "DELETE", maquatang = grvViewQuaTang.GetRowCellValue(i, "maquatang") });
            if (dt.Rows[0]["status"].ToString() == "NO")
            {
                XtraMessageBox.Show($"Tên quà tặng ({grvViewQuaTang.GetRowCellValue(i, "quatang")}) đã được sử dụng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GetQuaTang();
            }
        }

        private void FrmQuaTang_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetQuaTang();
        }
    }
}