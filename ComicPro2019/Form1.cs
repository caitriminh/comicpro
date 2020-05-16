using ComicPro2019.DanhMuc;
using ComicPro2019.HeThong;
using ComicPro2019.NghiepVu;
using ComicPro2019.NghiepVu.BanLamViec;
using ComicPro2019.Properties;
using ComicPro2019.TroGiup;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ComicPro2019
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();
            var skin = CommonSkins.GetSkin(UserLookAndFeel.Default);
            DevExpress.Utils.Svg.SvgPalette fireBall = skin.CustomSvgPalettes[Settings.Default["ApplicationPalletName"].ToString()];
            skin.SvgPalettes[Skin.DefaultSkinPaletteName].SetCustomPalette(fireBall);
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            FormClosing += (s, e) =>
            {
                Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
                Settings.Default["ApplicationPalletName"] = UserLookAndFeel.Default.ActiveSvgPaletteName;
                Settings.Default.Save();
            };
        }

        public void OpenForm(Type typeform)
        {
            foreach (var frm in MdiChildren.Where(frm => frm.GetType() == typeform))
            {
                frm.Activate();
                return;
            }

            BeginInvoke(new Action(() =>
            {
                var form = (Form)(Activator.CreateInstance(typeform));
                form.MdiParent = this;
                form.Show();
            }));
        }

        private static Form1 _defaultInstance;
        public static Form1 Default
        {
            get => _defaultInstance ?? (_defaultInstance = new Form1());
            set => _defaultInstance = value;
        }

        #region "Thông báo"
        public void CountDownloadHidePopup()
        {
            timer1.Enabled = true;
        }

        private int _timeoutMessage = 2; //default 2s

        public int i;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == _timeoutMessage)
            {
                flyoutPanel_internet.HidePopup();
                i = 0;
                timer1.Enabled = false;
                _timeoutMessage = 2;
            }
        }

        public void ShowMessageError(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#D9534F");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
                CountDownloadHidePopup();
            }));
        }

        public void ShowMessageDefault(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#A5A5A5");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
                CountDownloadHidePopup();
            }));
        }

        public void ShowMessageDefaultInternet(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#A5A5A5");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
            }));
        }

        public void ShowMessageWarning(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#F0AD4E");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
                CountDownloadHidePopup();
            }));
        }

        public void ShowMessageInfo(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#5BC0DE");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
                CountDownloadHidePopup();
            }));
        }

        public void ShowMessageSuccess(string text)
        {
            BeginInvoke(new Action(() =>
            {
                lbl_message_internet.Text = text.ToUpper();
                lbl_message_internet.BackColor = ColorTranslator.FromHtml("#5CB85C");
                lbl_message_internet.Width = Width;
                flyoutPanel_internet.ShowPopup();
                CountDownloadHidePopup();
            }));
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            //Kiểm tra key
            if (Config.Decrypt(Config.Encrypt(Config.CreateMd5(Config.GetSerialHdd().Trim()))).Equals(Settings.Default.key))
            {
                Text = @"COMIC PRO " + DateTime.Now.Year + @" (LICENSED)";
                using (FrmDangnhap frm = new FrmDangnhap())
                {
                    if (MaskedDialog.ShowDialog(this, frm) == DialogResult.OK)
                    {
                        lbl_nguoidung.Caption = ComicPro.StrTenDangNhap.ToUpper();
                        lbl_thoigian.Caption = DateTime.Now.Date.ToString("dd/MM/yyyy");
                        bar_gio.Caption = DateTime.Now.Date.ToString("HH:mm");
                        lbl_maychu.Caption = Dns.GetHostName();
                        OpenForm(typeof(FrmBanLamViec));
                    }
                }
            }
            else
            {
                Text = @"COMIC PRO " + DateTime.Now.Year + @" (UNLICENSED)";
                var frm1 = new FrmDangKy();
                MaskedDialog.ShowDialog(this, frm1);
            }
        }

        private void btn_donvitinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmDonViTinh));
        }

        private void btn_thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_quocgia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmNuoc));
        }
        private void btn_loaitruyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmLoaiTruyen));
        }

        private void btn_kho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmKho));
        }

        private void btn_tacgia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmTacGia));
        }

        private void btn_nxb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmNxb));
        }

        private void btn_tuatruyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmTuaTruyen));
        }

        private void btn_loaibia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmLoaiBia));
        }

        private void btn_danhmuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmDanhMuc));
        }

        private void btn_phieunhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmPhieuNhap));
        }

        private void btn_donvi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmDonVi));
        }

        private void btn_phieuxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmPhieuXuat));
        }
        private void btn_tonkho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmTonKho));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var strSkin = defaultLookAndFeel1.LookAndFeel.SkinName;
            Settings.Default.skin = strSkin;
            Settings.Default.Save();
        }

        private void btn_nguoidung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmNguoidung));
        }

        private void btn_khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDangnhap frm = new FrmDangnhap();
            MaskedDialog.ShowDialog(this, frm);
        }

        private void label1a_TextChanged(object sender, EventArgs e)
        {
            lbl_maychu.Caption = @"User: " + ComicPro.StrTenDangNhap.ToUpper() + @" | Ngày đăng nhập: " + DateTime.Now;
        }

        private void btn_doimatkhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btn_backupdata_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmBackupData));
        }

        private void btnBanLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmBanLamViec));
        }

        private void btn_gioithieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmGioiThieu();
            MaskedDialog.ShowDialog(this, frm);
        }

        private void btn_thongtin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmThongTin();
            MaskedDialog.ShowDialog(this, frm);
        }

        private void btn_dangky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmDangKy();
            MaskedDialog.ShowDialog(this, frm);
        }

        private RibbonPage pageSelected;
        private RibbonPage pageParentSelected;
        private void ribbonControl1_Merge(object sender, RibbonMergeEventArgs e)
        {
            pageParentSelected = ribbonControl1.SelectedPage;
            e.MergeOwner.SelectedPage = e.MergeOwner.MergedPages["Print Preview"];
            e.MergeOwner.SelectedPage = e.MergeOwner.MergedPages["ĐỌC TRUYỆN"];
            e.MergeOwner.SelectedPage = e.MergeOwner.MergedPages["HOME"];

            RibbonControl parentRRibbon = sender as RibbonControl;

            var parentPages = e.MergeOwner.Pages;
            ShowOrHidePageRibbon(parentPages, pageSelected, false);
            RibbonControl childRibbon = e.MergedChild;

            parentRRibbon?.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void ribbonControl1_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            RibbonControl parentRRibbon = sender as RibbonControl;
            parentRRibbon?.StatusBar.UnMergeStatusBar();
            var parentPages = e.MergeOwner.Pages;
            ShowOrHidePageRibbon(parentPages, pageSelected, true);
            ribbonControl1.SelectedPage = pageParentSelected;
        }

        private void btn_doctruyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmReadComic));
        }

        public void ShowTaskBar(BarItemVisibility barStatus)
        {
            lbl_maychu.Visibility = barStatus;
            barButtonItem2.Visibility = barStatus;
            lbl_nguoidung.Visibility = barStatus;
            bar_gio.Visibility = barStatus;
            lbl_thoigian.Visibility = barStatus;

            bar_scrollLock.Visibility = barStatus;
            bar_insert.Visibility = barStatus;
            bar_numLock.Visibility = barStatus;
            bar_capLocks.Visibility = barStatus;
        }

        public void ShowOrHidePageRibbon(RibbonPageCollection parentPages, RibbonPage pageSelected, bool isShow)
        {
            if (isShow)
            {
                ShowTaskBar(BarItemVisibility.Always);
            }
            else
            {
                ShowTaskBar(BarItemVisibility.Never);
            }
            //   if (pageSelected.Text != "DESIGN") { return; } // design ở đây là tab page Excel Viewer
            foreach (RibbonPage pageItem in parentPages)
            {
                pageItem.Visible = isShow;
            }

        }

    }
}
