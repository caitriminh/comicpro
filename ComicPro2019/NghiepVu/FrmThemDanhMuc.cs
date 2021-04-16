using ComicPro2019.Models.DanhMuc;
using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmThemDanhMuc : XtraForm
    {
        public FrmThemDanhMuc()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tentruyen.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên truyện.");
                txt_tentruyen.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_tuatruyen.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên tựa truyện.");
                cbo_tuatruyen.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_loaibia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên loại bìa.");
                cbo_loaibia.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_donvitinh.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải chọn đơn vị tính.");
                cbo_donvitinh.Focus(); return;
            }

            if (Convert.ToInt32(ExecSQL.ExecQuerySacalar($"SELECT COUNT(*) FROM dbo.tbl_tentruyen WHERE matruyen='{txt_matruyen.Text}'")) > 0)
            {
                Form1.Default.ShowMessageWarning("Tập này của Tựa truyện này đã tồn tại.");
                return;
            }

            var tentruyen = new TenTruyen { matruyen = txt_matruyen.Text, tentruyen = txt_tentruyen.Text, matua = cbo_tuatruyen.EditValue.ToString(), tap = Convert.ToInt32(txt_tap.Text), maloaibia = Convert.ToInt32(cbo_loaibia.EditValue), madvt = Convert.ToInt32(cbo_donvitinh.EditValue), ngayxuatban = DateTimeExtensions.TryParseNullable(txt_ngayxuatban.Text), giabia = txt_giabia.Text == string.Empty ? 0 : Convert.ToDecimal(txt_giabia.Text), sotrang = Convert.ToInt32(txt_sotrang.Text), ghichu = txt_ghichu.Text, filetruyen = false, nguoitd = ComicPro.StrTenDangNhap.ToUpper(), maquatang = cboQuaTang.EditValue == null ? "00" : cboQuaTang.EditValue.ToString() };
            ExecSQL.Insert(tentruyen);
            // Form1.Default.ShowMessageSuccess($"Đã thêm tên truyện ({txt_tentruyen.Text}) của tựa truyện ({cbo_tuatruyen.Text}) thành công.");
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "danhmuc"
            };
            message.Publish();
        }

        public async void GetLoaiBia()
        {
            var listLoaiBia = await ExecSQL.ExecQueryDataAsync<LoaiBia>("SELECT id, loaibia FROM dbo.tbl_loaibia");
            cbo_loaibia.Properties.DataSource = listLoaiBia;
            cbo_loaibia.Properties.DisplayMember = "loaibia";
            cbo_loaibia.Properties.ValueMember = "id";

        }

        public async void GetDonViTinh()
        {
            var listDonViTinh = await ExecSQL.ExecQueryDataAsync<DonViTinh>("SELECT id, donvitinh FROM dbo.tbl_donvitinh");
            cbo_donvitinh.Properties.DataSource = listDonViTinh;
            cbo_donvitinh.Properties.DisplayMember = "donvitinh";
            cbo_donvitinh.Properties.ValueMember = "id";
            cbo_donvitinh.EditValue = 2;
        }

        public async void GetTuaTruyen()
        {
            var listTuaTruyen = await ExecSQL.ExecQueryDataAsync<TuaTruyen>("SELECT matua, tuatruyen FROM dbo.tbl_tuatruyen WHERE theodoi=1 ORDER BY tuatruyen");
            cbo_tuatruyen.Properties.DataSource = listTuaTruyen;
            cbo_tuatruyen.Properties.DisplayMember = "tuatruyen";
            cbo_tuatruyen.Properties.ValueMember = "matua";
            cbo_tuatruyen.EditValue = ComicPro.StrMaTua;
        }
        public void XoaText()
        {
            txt_ghichu.Text = "";
            txt_tentruyen.Text = "";
            txt_tentruyen.Focus();
            if (string.IsNullOrEmpty(cbo_tuatruyen.Text)) { return; }
            txt_tap.Text = ExecSQL.ExecQuerySacalar($"SELECT ISNULL(MAX(tap),0)+1 FROM dbo.tbl_tentruyen WHERE matua='{cbo_tuatruyen.EditValue}'").ToString();
        }

        public async void GetQuaTang()
        {
            var lstQuaTang = await ExecSQL.ExecQueryDataAsync<QuaTang>("SELECT maquatang, quatang FROM dbo.tbl_quatang ORDER BY quatang");
            cboQuaTang.Properties.DataSource = lstQuaTang;
            cboQuaTang.Properties.DisplayMember = "quatang";
            cboQuaTang.Properties.ValueMember = "maquatang";
        }

        private void FrmThemDanhMuc_Load(object sender, EventArgs e)
        {
            GetQuaTang();
            GetLoaiBia();
            GetDonViTinh();
            GetTuaTruyen();
        }

        private void FrmThemDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Enter:
            //        btn_Luu_Click(sender, e);
            //        break;
            //    case Keys.Escape:
            //        Application.Exit();
            //        break;
            //}
        }

        private void txt_tentruyen_Leave(object sender, EventArgs e)
        {
            txt_tentruyen.Text = txt_tentruyen.Text.ToUpper();
        }

        private void cbo_tuatruyen_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_tuatruyen.Text)) { return; }
            txt_tap.Text = ExecSQL.ExecQuerySacalar($"SELECT ISNULL(MAX(tap),0)+1 FROM dbo.tbl_tentruyen WHERE matua='{cbo_tuatruyen.EditValue}'").ToString();

            txt_matruyen.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('{cbo_tuatruyen.EditValue}.',FORMAT({Convert.ToInt32(txt_tap.Text)},'000'))").ToString();
        }

        private void txt_tap_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_tuatruyen.Text) || string.IsNullOrEmpty(txt_tap.Text)) { return; }
            txt_matruyen.Text = ExecSQL.ExecQuerySacalar($"SELECT CONCAT('{cbo_tuatruyen.EditValue}.',FORMAT({Convert.ToInt32(txt_tap.Text)},'000'))").ToString();
        }
    }
}