using ComicPro2019.DanhMuc;
using DevExpress.XtraEditors;
using SimpleBroker;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComicPro2019.NghiepVu
{
    public partial class FrmThemTuaTruyen : XtraForm
    {
        public FrmThemTuaTruyen()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tuatruyen.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập vào tên tựa truyện.");
                txt_tuatruyen.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_nhaxuatban.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên nhà xuất bản.");
                cbo_nhaxuatban.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_loaitruyen.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên loại truyện.");
                cbo_loaitruyen.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_quocgia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên nước phát hành.");
                cbo_quocgia.Focus(); return;
            }
            if (string.IsNullOrEmpty(cbo_tacgia.Text))
            {
                Form1.Default.ShowMessageWarning("Bạn phải nhập tên tác giả tựa truyện.");
                cbo_tacgia.Focus(); return;
            }
            var tuatruyen = new TuaTruyen { matua = txt_matua.Text, tuatruyen = txt_tuatruyen.Text, maloai = cbo_loaitruyen.EditValue.ToString(), manxb = cbo_nhaxuatban.EditValue.ToString(), matacgia = cbo_tacgia.EditValue.ToString(), maquocgia = Convert.ToInt32(cbo_quocgia.EditValue), sotap = Convert.ToInt32(txt_sotap.Text), taiban = Convert.ToInt32(txt_taiban.Text), theodoi = true, ghichu = txt_ghichu.Text, namxuatban = Convert.ToInt32(txt_namxuatban.Text), nguoitd = ComicPro.StrTenDangNhap.ToUpper() };
            ExecSQL.Insert(tuatruyen);
            XoaText();
            //Gửi dữ liệu
            var message = new MessageBroker
            {
                data = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                task = "tuatruyen"
            };
            message.Publish();
        }


        public async void GetLoaiTruyen()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<LoaiTruyen>("SELECT maloai, loaitruyen FROM dbo.tbl_loaitruyen ORDER BY loaitruyen");
            cbo_loaitruyen.Properties.DataSource = dt;
            cbo_loaitruyen.Properties.DisplayMember = "loaitruyen";
            cbo_loaitruyen.Properties.ValueMember = "maloai";
        }

        public async void GetQuocGia()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<QuocGia>("SELECT id, quocgia FROM dbo.tbl_quocgia ORDER BY quocgia");
            cbo_quocgia.Properties.DataSource = dt;
            cbo_quocgia.Properties.DisplayMember = "quocgia";
            cbo_quocgia.Properties.ValueMember = "id";
        }

        public async void GetTacGia()
        {
            var listTacGia = await ExecSQL.ExecQueryDataAsync<TacGia>("SELECT matacgia, tacgia FROM dbo.tbl_tacgia ORDER BY tacgia");
            cbo_tacgia.Properties.DataSource = listTacGia;
            cbo_tacgia.Properties.DisplayMember = "tacgia";
            cbo_tacgia.Properties.ValueMember = "matacgia";
            cbo_tacgia.EditValue = ComicPro.StrMaTacGia;
        }

        public async void GetNhaXuatBan()
        {
            var dt = await ExecSQL.ExecQueryDataAsync<NXB>("SELECT manxb, nhaxuatban FROM dbo.tbl_nhaxuatban ORDER BY nhaxuatban");
            cbo_nhaxuatban.Properties.DataSource = dt;
            cbo_nhaxuatban.Properties.DisplayMember = "nhaxuatban";
            cbo_nhaxuatban.Properties.ValueMember = "manxb";
        }

        private void cbo_loaitruyen_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_loaitruyen.Text)) { return; }
            txt_matua.Text = ExecSQL.ExecProcedureSacalar("pro_taomatuatruyen", new { maloai = cbo_loaitruyen.EditValue.ToString() }).ToString();
        }

        private void FrmThemTuaTruyen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_Luu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void OnNext(MessageBroker value)
        {
            if (value.task == "tacgia")
            {
                GetTacGia();
            }
        }

        private void FrmThemTuaTruyen_Load(object sender, EventArgs e)
        {
            this.Subscribe<MessageBroker>(OnNext);
            GetLoaiTruyen();
            GetQuocGia();
            GetTacGia();
            GetNhaXuatBan();
        }

        public void XoaText()
        {
            cbo_loaitruyen.EditValue = DBNull.Value;
            cbo_nhaxuatban.EditValue = DBNull.Value;
            cbo_quocgia.EditValue = DBNull.Value;
            cbo_tacgia.EditValue = DBNull.Value;
            txt_ghichu.Text = "";
            txt_sotap.Text = @"0";
            txt_taiban.Text = @"1";
            txt_tuatruyen.Text = "";
            txt_tuatruyen.Focus();
        }

        private void cbo_tacgia_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                FrmThemTacGia frm = new FrmThemTacGia();
                frm.Show(this);
            }
        }
    }
}