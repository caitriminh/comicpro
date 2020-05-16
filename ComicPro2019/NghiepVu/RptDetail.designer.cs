namespace ComicPro2019.NghiepVu
{
    partial class RptDetail : DevExpress.XtraReports.UI.XtraReport
    {

        //XtraReport overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //NOTE: The following procedure is required by the Designer
        //It can be modified using the Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lbl_ngayxuatban = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_nxb = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_tap = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_giabia2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_tacgia = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_tentruyen = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_sotrang = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_sotrang,
            this.lbl_ngayxuatban,
            this.lbl_nxb,
            this.lbl_tap,
            this.lbl_giabia2,
            this.lbl_tacgia,
            this.lbl_tentruyen,
            this.XrPictureBox1});
            this.Detail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 199.3333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbl_ngayxuatban
            // 
            this.lbl_ngayxuatban.LocationFloat = new DevExpress.Utils.PointFloat(135.3334F, 143F);
            this.lbl_ngayxuatban.Multiline = true;
            this.lbl_ngayxuatban.Name = "lbl_ngayxuatban";
            this.lbl_ngayxuatban.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_ngayxuatban.SizeF = new System.Drawing.SizeF(231.6666F, 23.00002F);
            this.lbl_ngayxuatban.Text = "12/12/2012";
            // 
            // lbl_nxb
            // 
            this.lbl_nxb.LocationFloat = new DevExpress.Utils.PointFloat(135.3334F, 115F);
            this.lbl_nxb.Multiline = true;
            this.lbl_nxb.Name = "lbl_nxb";
            this.lbl_nxb.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_nxb.SizeF = new System.Drawing.SizeF(231.6666F, 23F);
            this.lbl_nxb.Text = "KIM ĐỒNG";
            // 
            // lbl_tap
            // 
            this.lbl_tap.LocationFloat = new DevExpress.Utils.PointFloat(135.3334F, 86.99998F);
            this.lbl_tap.Multiline = true;
            this.lbl_tap.Name = "lbl_tap";
            this.lbl_tap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_tap.SizeF = new System.Drawing.SizeF(231.6666F, 23.00001F);
            this.lbl_tap.Text = "01";
            // 
            // lbl_giabia2
            // 
            this.lbl_giabia2.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 58.99998F);
            this.lbl_giabia2.Multiline = true;
            this.lbl_giabia2.Name = "lbl_giabia2";
            this.lbl_giabia2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_giabia2.SizeF = new System.Drawing.SizeF(231.6666F, 22.99999F);
            this.lbl_giabia2.Text = "20.000";
            // 
            // lbl_tacgia
            // 
            this.lbl_tacgia.LocationFloat = new DevExpress.Utils.PointFloat(135.3334F, 31.99999F);
            this.lbl_tacgia.Multiline = true;
            this.lbl_tacgia.Name = "lbl_tacgia";
            this.lbl_tacgia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_tacgia.SizeF = new System.Drawing.SizeF(231.6666F, 22.99999F);
            this.lbl_tacgia.Text = "Tác Giả";
            // 
            // lbl_tentruyen
            // 
            this.lbl_tentruyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_tentruyen.LocationFloat = new DevExpress.Utils.PointFloat(135.3334F, 4.999985F);
            this.lbl_tentruyen.Multiline = true;
            this.lbl_tentruyen.Name = "lbl_tentruyen";
            this.lbl_tentruyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_tentruyen.SizeF = new System.Drawing.SizeF(231.6666F, 23F);
            this.lbl_tentruyen.StylePriority.UseFont = false;
            this.lbl_tentruyen.Text = "TẬP 01";
            this.lbl_tentruyen.WordWrap = false;
            // 
            // XrPictureBox1
            // 
            this.XrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 4.999985F);
            this.XrPictureBox1.Name = "XrPictureBox1";
            this.XrPictureBox1.SizeF = new System.Drawing.SizeF(131.6667F, 189.3333F);
            this.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.XrPictureBox1.StylePriority.UseBorders = false;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 28F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.GroupHeader1.HeightF = 26.99999F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeader1_BeforePrint);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(359F, 24.99999F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "SIÊU QUẬY TEPPEI";
            // 
            // lbl_sotrang
            // 
            this.lbl_sotrang.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 171.3333F);
            this.lbl_sotrang.Multiline = true;
            this.lbl_sotrang.Name = "lbl_sotrang";
            this.lbl_sotrang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_sotrang.SizeF = new System.Drawing.SizeF(231.6666F, 23.00002F);
            this.lbl_sotrang.Text = "12/12/2012";
            // 
            // RptDetail
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1});
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(22, 436, 0, 28);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal DevExpress.XtraReports.UI.XRPictureBox XrPictureBox1;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.UI.XRLabel lbl_nxb;
        private DevExpress.XtraReports.UI.XRLabel lbl_tap;
        private DevExpress.XtraReports.UI.XRLabel lbl_giabia2;
        private DevExpress.XtraReports.UI.XRLabel lbl_tacgia;
        private DevExpress.XtraReports.UI.XRLabel lbl_tentruyen;
        private DevExpress.XtraReports.UI.XRLabel lbl_ngayxuatban;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lbl_sotrang;
    }

}

