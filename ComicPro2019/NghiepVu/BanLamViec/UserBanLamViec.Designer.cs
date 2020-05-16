namespace ComicPro2019.NghiepVu.BanLamViec
{
    partial class UserBanLamViec
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserBanLamViec));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions2 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.loaitruyen = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.giatri = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.tuatruyen = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.widgetView1 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            this.columnDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition3 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.rowDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.rowDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.mnu_loaitruyen = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_tuatruyen = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_giatri = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_nhaxuatban = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.mnu_quocgia = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.loaitruyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giatri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuatruyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // loaitruyen
            // 
            this.loaitruyen.Caption = "Loại Truyện";
            this.loaitruyen.ControlName = "loaitruyen";
            this.loaitruyen.ControlTypeName = "ComicPro2019.NghiepVu.BanLamViec.UserLoaiTruyen";
            customHeaderButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions1.Image")));
            this.loaitruyen.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("", true, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject1, null, -1)});
            this.loaitruyen.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.loaitruyen_CustomButtonClick);
            // 
            // giatri
            // 
            this.giatri.Caption = "Giá Trị";
            this.giatri.ControlName = "giatri";
            this.giatri.ControlTypeName = "ComicPro2019.NghiepVu.BanLamViec.UserGiaTri";
            customHeaderButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions2.Image")));
            this.giatri.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("", true, customHeaderButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject2, null, -1)});
            this.giatri.RowIndex = 1;
            this.giatri.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.giatri_CustomButtonClick);
            // 
            // tuatruyen
            // 
            this.tuatruyen.Caption = "Tựa Truyện";
            this.tuatruyen.ColumnIndex = 1;
            this.tuatruyen.ColumnSpan = 2;
            this.tuatruyen.ControlName = "tuatruyen";
            this.tuatruyen.ControlTypeName = "ComicPro2019.NghiepVu.BanLamViec.UserTuaTruyen";
            this.tuatruyen.Height = 674;
            this.tuatruyen.RowSpan = 2;
            this.tuatruyen.Width = 652;
            this.tuatruyen.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.tuatruyen_CustomButtonClick);
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.widgetView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetView1});
            // 
            // widgetView1
            // 
            this.widgetView1.Columns.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition[] {
            this.columnDefinition1,
            this.columnDefinition2,
            this.columnDefinition3});
            this.widgetView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.loaitruyen,
            this.giatri,
            this.tuatruyen});
            this.widgetView1.LayoutMode = DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.TableLayout;
            this.widgetView1.RootContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.widgetView1.Rows.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition[] {
            this.rowDefinition1,
            this.rowDefinition2});
            this.widgetView1.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.widgetView1_QueryControl);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_loaitruyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_tuatruyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_giatri),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_nhaxuatban),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_quocgia)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // mnu_loaitruyen
            // 
            this.mnu_loaitruyen.Caption = "Loại truyện";
            this.mnu_loaitruyen.Id = 3;
            this.mnu_loaitruyen.Name = "mnu_loaitruyen";
            this.mnu_loaitruyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_loaitruyen_ItemClick);
            // 
            // mnu_tuatruyen
            // 
            this.mnu_tuatruyen.Caption = "Tựa truyện";
            this.mnu_tuatruyen.Id = 6;
            this.mnu_tuatruyen.Name = "mnu_tuatruyen";
            this.mnu_tuatruyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_tuatruyen_ItemClick);
            // 
            // mnu_giatri
            // 
            this.mnu_giatri.Caption = "Giá trị";
            this.mnu_giatri.Id = 5;
            this.mnu_giatri.Name = "mnu_giatri";
            this.mnu_giatri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_giatri_ItemClick);
            // 
            // mnu_nhaxuatban
            // 
            this.mnu_nhaxuatban.Caption = "Nhà xuất bản";
            this.mnu_nhaxuatban.Id = 7;
            this.mnu_nhaxuatban.Name = "mnu_nhaxuatban";
            this.mnu_nhaxuatban.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_nhaxuatban_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnu_loaitruyen,
            this.mnu_giatri,
            this.mnu_tuatruyen,
            this.mnu_nhaxuatban,
            this.mnu_quocgia});
            this.barManager1.MaxItemId = 9;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1019, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 583);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1019, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 583);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1019, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 583);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.Text = "Custom 2";
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 1;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.Text = "Custom 3";
            // 
            // mnu_quocgia
            // 
            this.mnu_quocgia.Caption = "Quốc gia";
            this.mnu_quocgia.Id = 8;
            this.mnu_quocgia.Name = "mnu_quocgia";
            this.mnu_quocgia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_quocgia_ItemClick);
            // 
            // UserBanLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UserBanLamViec";
            this.Size = new System.Drawing.Size(1019, 583);
            ((System.ComponentModel.ISupportInitialize)(this.loaitruyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giatri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuatruyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document loaitruyen;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document giatri;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document tuatruyen;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem mnu_loaitruyen;
        private DevExpress.XtraBars.BarButtonItem mnu_giatri;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem mnu_tuatruyen;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition2;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition3;
        private DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition rowDefinition1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition rowDefinition2;
        private DevExpress.XtraBars.BarButtonItem mnu_nhaxuatban;
        private DevExpress.XtraBars.BarButtonItem mnu_quocgia;
    }
}
