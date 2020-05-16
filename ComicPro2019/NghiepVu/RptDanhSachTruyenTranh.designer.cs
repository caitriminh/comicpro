// VBConversions Note: VB project level imports

// End of VB project level imports


namespace ComicPro2019.NghiepVu
{
   partial class RptDanhSachTruyenTranh : DevExpress.XtraReports.UI.XtraReport
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
            this.XrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_matruyen = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_tentruyen = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_tacgia = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_giabia = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_tap = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.XrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lbl_tuatruyen = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_DiaChi = new DevExpress.XtraReports.UI.XRLabel();
            this.tel = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPictureBox1,
            this.XrTable1});
            this.Detail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 167.9167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrPictureBox1
            // 
            this.XrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(631.8334F, 0F);
            this.XrPictureBox1.Name = "XrPictureBox1";
            this.XrPictureBox1.SizeF = new System.Drawing.SizeF(139.1667F, 167.9167F);
            this.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.XrPictureBox1.StylePriority.UseBorders = false;
            // 
            // XrTable1
            // 
            this.XrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrTable1.Name = "XrTable1";
            this.XrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow1});
            this.XrTable1.SizeF = new System.Drawing.SizeF(631.8334F, 167.9167F);
            this.XrTable1.StylePriority.UseBorders = false;
            // 
            // XrTableRow1
            // 
            this.XrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.stt,
            this.lbl_matruyen,
            this.lbl_tentruyen,
            this.lbl_tacgia,
            this.lbl_giabia,
            this.lbl_tap});
            this.XrTableRow1.Name = "XrTableRow1";
            this.XrTableRow1.Weight = 1D;
            // 
            // stt
            // 
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.stt.Name = "stt";
            this.stt.StylePriority.UseFont = false;
            this.stt.StylePriority.UseTextAlignment = false;
            this.stt.Text = "1000";
            this.stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.stt.Weight = 0.24257424800212D;
            // 
            // lbl_matruyen
            // 
            this.lbl_matruyen.Name = "lbl_matruyen";
            this.lbl_matruyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 0, 0, 100F);
            this.lbl_matruyen.StylePriority.UsePadding = false;
            this.lbl_matruyen.StylePriority.UseTextAlignment = false;
            this.lbl_matruyen.Text = "002597";
            this.lbl_matruyen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbl_matruyen.Weight = 0.570792020986461D;
            // 
            // lbl_tentruyen
            // 
            this.lbl_tentruyen.Name = "lbl_tentruyen";
            this.lbl_tentruyen.Weight = 1.7606927153109073D;
            // 
            // lbl_tacgia
            // 
            this.lbl_tacgia.Name = "lbl_tacgia";
            this.lbl_tacgia.Weight = 1.1762377193932572D;
            // 
            // lbl_giabia
            // 
            this.lbl_giabia.Multiline = true;
            this.lbl_giabia.Name = "lbl_giabia";
            this.lbl_giabia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 4, 0, 0, 100F);
            this.lbl_giabia.StylePriority.UsePadding = false;
            this.lbl_giabia.StylePriority.UseTextAlignment = false;
            this.lbl_giabia.Text = "3.300";
            this.lbl_giabia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_giabia.Weight = 0.45148549528182219D;
            // 
            // lbl_tap
            // 
            this.lbl_tap.Name = "lbl_tap";
            this.lbl_tap.StylePriority.UseTextAlignment = false;
            this.lbl_tap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbl_tap.Weight = 0.30237689977784166D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 28F;
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
            // PageHeaderBand1
            // 
            this.PageHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrTable2});
            this.PageHeaderBand1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageHeaderBand1.HeightF = 36.25003F;
            this.PageHeaderBand1.Name = "PageHeaderBand1";
            this.PageHeaderBand1.StylePriority.UseFont = false;
            this.PageHeaderBand1.StylePriority.UseTextAlignment = false;
            this.PageHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrTable2
            // 
            this.XrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrTable2.Name = "XrTable2";
            this.XrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow2});
            this.XrTable2.SizeF = new System.Drawing.SizeF(771F, 36.25003F);
            this.XrTable2.StylePriority.UseBorders = false;
            this.XrTable2.StylePriority.UseFont = false;
            // 
            // XrTableRow2
            // 
            this.XrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell1,
            this.XrTableCell2,
            this.XrTableCell3,
            this.XrTableCell6,
            this.XrTableCell7,
            this.XrTableCell8,
            this.XrTableCell10});
            this.XrTableRow2.Name = "XrTableRow2";
            this.XrTableRow2.Weight = 1D;
            // 
            // XrTableCell1
            // 
            this.XrTableCell1.Name = "XrTableCell1";
            this.XrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.XrTableCell1.StylePriority.UsePadding = false;
            this.XrTableCell1.Text = "STT";
            this.XrTableCell1.Weight = 0.24257424800212D;
            // 
            // XrTableCell2
            // 
            this.XrTableCell2.Name = "XrTableCell2";
            this.XrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.XrTableCell2.StylePriority.UsePadding = false;
            this.XrTableCell2.StylePriority.UseTextAlignment = false;
            this.XrTableCell2.Text = "Mã truyện";
            this.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrTableCell2.Weight = 0.57079187123512465D;
            // 
            // XrTableCell3
            // 
            this.XrTableCell3.Name = "XrTableCell3";
            this.XrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.XrTableCell3.StylePriority.UsePadding = false;
            this.XrTableCell3.Text = "Tên truyện";
            this.XrTableCell3.Weight = 1.7606932472863111D;
            // 
            // XrTableCell6
            // 
            this.XrTableCell6.Name = "XrTableCell6";
            this.XrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.XrTableCell6.StylePriority.UsePadding = false;
            this.XrTableCell6.Text = "Tác giả";
            this.XrTableCell6.Weight = 1.1762372361863589D;
            // 
            // XrTableCell7
            // 
            this.XrTableCell7.Multiline = true;
            this.XrTableCell7.Name = "XrTableCell7";
            this.XrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 4, 0, 0, 100F);
            this.XrTableCell7.StylePriority.UsePadding = false;
            this.XrTableCell7.StylePriority.UseTextAlignment = false;
            this.XrTableCell7.Text = "Giá bìa";
            this.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.XrTableCell7.Weight = 0.45148588596787154D;
            // 
            // XrTableCell8
            // 
            this.XrTableCell8.Name = "XrTableCell8";
            this.XrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.XrTableCell8.StylePriority.UsePadding = false;
            this.XrTableCell8.StylePriority.UseTextAlignment = false;
            this.XrTableCell8.Text = "Tập";
            this.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrTableCell8.Weight = 0.30237640671083166D;
            // 
            // XrTableCell10
            // 
            this.XrTableCell10.Name = "XrTableCell10";
            this.XrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.XrTableCell10.StylePriority.UsePadding = false;
            this.XrTableCell10.StylePriority.UseTextAlignment = false;
            this.XrTableCell10.Text = "Hình ảnh";
            this.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrTableCell10.Weight = 0.992078832712893D;
            // 
            // GroupHeaderBand1
            // 
            this.GroupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_tuatruyen});
            this.GroupHeaderBand1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("mapx", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderBand1.HeightF = 23F;
            this.GroupHeaderBand1.Name = "GroupHeaderBand1";
            this.GroupHeaderBand1.StyleName = "DataField";
            this.GroupHeaderBand1.StylePriority.UseFont = false;
            this.GroupHeaderBand1.StylePriority.UseTextAlignment = false;
            this.GroupHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbl_tuatruyen
            // 
            this.lbl_tuatruyen.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_tuatruyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tuatruyen.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_tuatruyen.Name = "lbl_tuatruyen";
            this.lbl_tuatruyen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_tuatruyen.SizeF = new System.Drawing.SizeF(771.0001F, 23F);
            this.lbl_tuatruyen.StylePriority.UseBorders = false;
            this.lbl_tuatruyen.StylePriority.UseFont = false;
            this.lbl_tuatruyen.Text = "lbl_tuatruyen";
            // 
            // PageFooterBand1
            // 
            this.PageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo1});
            this.PageFooterBand1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageFooterBand1.HeightF = 19.41665F;
            this.PageFooterBand1.Name = "PageFooterBand1";
            this.PageFooterBand1.StylePriority.UseFont = false;
            this.PageFooterBand1.StylePriority.UseTextAlignment = false;
            this.PageFooterBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrPageInfo1
            // 
            this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrPageInfo1.Name = "XrPageInfo1";
            this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo1.SizeF = new System.Drawing.SizeF(771.0001F, 19.41665F);
            this.XrPageInfo1.StylePriority.UseTextAlignment = false;
            this.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeaderBand1
            // 
            this.ReportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.lbl_DiaChi,
            this.tel,
            this.XrLabel3});
            this.ReportHeaderBand1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportHeaderBand1.HeightF = 103.7083F;
            this.ReportHeaderBand1.Name = "ReportHeaderBand1";
            this.ReportHeaderBand1.StylePriority.UseFont = false;
            this.ReportHeaderBand1.StylePriority.UseTextAlignment = false;
            this.ReportHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel1
            // 
            this.XrLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.00001F);
            this.XrLabel1.Multiline = true;
            this.XrLabel1.Name = "XrLabel1";
            this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel1.SizeF = new System.Drawing.SizeF(348.2467F, 22F);
            this.XrLabel1.StylePriority.UseFont = false;
            this.XrLabel1.StylePriority.UseTextAlignment = false;
            this.XrLabel1.Text = "CỬA HÀNG CHO THUÊ TRUYỆN TRANH ABC";
            this.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_DiaChi.LocationFloat = new DevExpress.Utils.PointFloat(0.001729329F, 23.00001F);
            this.lbl_DiaChi.Multiline = true;
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_DiaChi.SizeF = new System.Drawing.SizeF(414.9134F, 20F);
            this.lbl_DiaChi.StylePriority.UseFont = false;
            this.lbl_DiaChi.StylePriority.UseTextAlignment = false;
            this.lbl_DiaChi.Text = "Đ/c: 153/3 KP. Trần Hưng Đạo, TT. Dầu Giây, Thống Nhất, Đồng Nai";
            this.lbl_DiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tel.LocationFloat = new DevExpress.Utils.PointFloat(0.003522237F, 43F);
            this.tel.Multiline = true;
            this.tel.Name = "tel";
            this.tel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tel.SizeF = new System.Drawing.SizeF(348.2449F, 20F);
            this.tel.StylePriority.UseFont = false;
            this.tel.StylePriority.UseTextAlignment = false;
            this.tel.Text = "ĐT: 0937 903300";
            this.tel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel3
            // 
            this.XrLabel3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65.08334F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(771.0001F, 38.62494F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.Text = "DANH SÁCH TRUYỆN TRANH";
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // RptDanhSachTruyenTranh
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeaderBand1,
            this.GroupHeaderBand1,
            this.PageFooterBand1,
            this.ReportHeaderBand1});
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(28, 28, 28, 28);
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
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
      internal DevExpress.XtraReports.UI.PageHeaderBand PageHeaderBand1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderBand1;
        internal DevExpress.XtraReports.UI.PageFooterBand PageFooterBand1;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderBand1;
        internal DevExpress.XtraReports.UI.XRTable XrTable1;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow1;
        internal DevExpress.XtraReports.UI.XRTableCell stt;
        internal DevExpress.XtraReports.UI.XRTableCell lbl_matruyen;
        internal DevExpress.XtraReports.UI.XRTableCell lbl_tentruyen;
        internal DevExpress.XtraReports.UI.XRTableCell lbl_tacgia;
        internal DevExpress.XtraReports.UI.XRTableCell lbl_giabia;
        internal DevExpress.XtraReports.UI.XRTableCell lbl_tap;
        internal DevExpress.XtraReports.UI.XRPictureBox XrPictureBox1;
        internal DevExpress.XtraReports.UI.XRTable XrTable2;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell1;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell3;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell6;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell7;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell8;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell10;
        internal DevExpress.XtraReports.UI.XRLabel lbl_tuatruyen;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel lbl_DiaChi;
        internal DevExpress.XtraReports.UI.XRLabel tel;
    }

}

