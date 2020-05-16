namespace ComicPro2019.NghiepVu
{
    partial class RptMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.tel = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_DiaChi = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20.50001F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // xrSubreport2
            // 
            this.xrSubreport2.LocationFloat = new DevExpress.Utils.PointFloat(394.1667F, 97.6666F);
            this.xrSubreport2.Name = "xrSubreport2";
            this.xrSubreport2.SizeF = new System.Drawing.SizeF(370.8333F, 97.16667F);
            this.xrSubreport2.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport2_BeforePrint);
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 97.6666F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(370.8333F, 97.16667F);
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport1_BeforePrint);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport2,
            this.xrSubreport1,
            this.xrLine1,
            this.XrLabel3,
            this.tel,
            this.lbl_DiaChi,
            this.XrLabel1});
            this.ReportHeader.HeightF = 202.6666F;
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            // 
            // xrLine1
            // 
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.003509521F, 85F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(768.9965F, 6.666664F);
            // 
            // XrLabel3
            // 
            this.XrLabel3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.08333F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(769F, 38.62494F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.Text = "DANH SÁCH TRUYỆN TRANH";
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tel.LocationFloat = new DevExpress.Utils.PointFloat(0.003509521F, 42F);
            this.tel.Multiline = true;
            this.tel.Name = "tel";
            this.tel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tel.SizeF = new System.Drawing.SizeF(348.2449F, 20F);
            this.tel.StylePriority.UseFont = false;
            this.tel.StylePriority.UseTextAlignment = false;
            this.tel.Text = "ĐT: 0937 903300";
            this.tel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_DiaChi.LocationFloat = new DevExpress.Utils.PointFloat(0.001729329F, 21.99999F);
            this.lbl_DiaChi.Multiline = true;
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_DiaChi.SizeF = new System.Drawing.SizeF(414.9134F, 20F);
            this.lbl_DiaChi.StylePriority.UseFont = false;
            this.lbl_DiaChi.StylePriority.UseTextAlignment = false;
            this.lbl_DiaChi.Text = "Đ/c: 153/3 KP. Trần Hưng Đạo, TT. Dầu Giây, Thống Nhất, Đồng Nai";
            this.lbl_DiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel1
            // 
            this.XrLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrLabel1.Multiline = true;
            this.XrLabel1.Name = "XrLabel1";
            this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel1.SizeF = new System.Drawing.SizeF(348.2467F, 22F);
            this.XrLabel1.StylePriority.UseFont = false;
            this.XrLabel1.StylePriority.UseTextAlignment = false;
            this.XrLabel1.Text = "CỬA HÀNG CHO THUÊ TRUYỆN TRANH ABC";
            this.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo1});
            this.PageFooter.HeightF = 19.41665F;
            this.PageFooter.Name = "PageFooter";
            // 
            // XrPageInfo1
            // 
            this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrPageInfo1.Name = "XrPageInfo1";
            this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo1.SizeF = new System.Drawing.SizeF(769F, 19.41665F);
            this.XrPageInfo1.StylePriority.UseTextAlignment = false;
            this.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // RptMaster
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(26, 32, 21, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel tel;
        internal DevExpress.XtraReports.UI.XRLabel lbl_DiaChi;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport2;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
    }
}
