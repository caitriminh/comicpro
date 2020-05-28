using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmChuyenSoDu : XtraForm
    {
        public FrmChuyenSoDu()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            var dgr = HelperMessage.Instance.ShowMessageYesNo($"Bạn có muốn chuyển số dư sang tháng {Convert.ToDateTime(txt_ngaychuyen.EditValue).ToString("MM/yyyy")} này không?", "Xác Nhận", SystemIcons.Question.ToBitmap());
            if (dgr != DialogResult.Yes) { return; }
            ExecSQL.ExecProcedureNonData("pro_chuyensodu", new { ky = Convert.ToDateTime(txt_ngaychuyen.EditValue).ToString("yyyyMM01") });
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "tonkho"
            };
            message.Publish();
        }

        private void FrmChuyenSoDu_Load(object sender, EventArgs e)
        {
            txt_ngaychuyen.EditValue = DateTime.Now.ToString("MM/yyyy");
        }
    }
}