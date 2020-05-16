namespace ComicPro2019.NghiepVu.BanLamViec
{
    partial class UserTuaTruyen
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
            DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTuaTruyen));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.col_hinhanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tentruyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tuatruyen = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.winExplorerView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(926, 614);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView1});
            // 
            // winExplorerView1
            // 
            this.winExplorerView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_hinhanh,
            this.col_tentruyen,
            this.col_tuatruyen});
            this.winExplorerView1.ColumnSet.ExtraLargeImageColumn = this.col_hinhanh;
            this.winExplorerView1.ColumnSet.GroupColumn = this.col_tuatruyen;
            this.winExplorerView1.ColumnSet.LargeImageColumn = this.col_hinhanh;
            this.winExplorerView1.ColumnSet.MediumImageColumn = this.col_hinhanh;
            this.winExplorerView1.ColumnSet.SmallImageColumn = this.col_hinhanh;
            this.winExplorerView1.ColumnSet.TextColumn = this.col_tentruyen;
            this.winExplorerView1.ContextButtonOptions.AnimationTime = 300;
            this.winExplorerView1.ContextButtonOptions.AnimationType = DevExpress.Utils.ContextAnimationType.OpacityAnimation;
            this.winExplorerView1.ContextButtonOptions.BottomPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.winExplorerView1.ContextButtonOptions.CenterPanelColor = System.Drawing.SystemColors.ControlDark;
            this.winExplorerView1.ContextButtonOptions.NearPanelColor = System.Drawing.SystemColors.ControlDark;
            this.winExplorerView1.ContextButtonOptions.NormalStateOpacity = 1F;
            contextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Bottom;
            contextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Center;
            contextButton1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            contextButton1.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Left;
            contextButton1.Id = new System.Guid("edc3f0e9-d813-436f-a636-398fe34a7868");
            contextButton1.ImageOptionsCollection.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            contextButton1.Name = "btn_open";
            this.winExplorerView1.ContextButtons.Add(contextButton1);
            this.winExplorerView1.GridControl = this.gridControl1;
            this.winExplorerView1.GroupCount = 1;
            this.winExplorerView1.Name = "winExplorerView1";
            this.winExplorerView1.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.winExplorerView1.OptionsImageLoad.AsyncLoad = true;
            this.winExplorerView1.OptionsView.ShowExpandCollapseButtons = true;
            this.winExplorerView1.OptionsView.ShowViewCaption = true;
            this.winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.ExtraLarge;
            this.winExplorerView1.OptionsViewStyles.ExtraLarge.GroupCheckBoxIndent = 1;
            this.winExplorerView1.OptionsViewStyles.Medium.ItemWidth = 333;
            this.winExplorerView1.OptionsViewStyles.Medium.SelectionDrawMode = DevExpress.XtraGrid.Views.WinExplorer.SelectionDrawMode.AroundItem;
            this.winExplorerView1.OptionsViewStyles.Medium.ShowDescription = DevExpress.Utils.DefaultBoolean.True;
            this.winExplorerView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_tuatruyen, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_tentruyen, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.winExplorerView1.ContextButtonCustomize += new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewContextButtonCustomizeEventHandler(this.winExplorerView1_ContextButtonCustomize);
            this.winExplorerView1.ContextButtonClick += new DevExpress.Utils.ContextItemClickEventHandler(this.winExplorerView1_ContextButtonClick);
            this.winExplorerView1.Click += new System.EventHandler(this.winExplorerView1_Click);
            // 
            // col_hinhanh
            // 
            this.col_hinhanh.Caption = "gridColumn1";
            this.col_hinhanh.FieldName = "Image";
            this.col_hinhanh.MinWidth = 27;
            this.col_hinhanh.Name = "col_hinhanh";
            this.col_hinhanh.Visible = true;
            this.col_hinhanh.VisibleIndex = 0;
            this.col_hinhanh.Width = 100;
            // 
            // col_tentruyen
            // 
            this.col_tentruyen.Caption = "gridColumn1";
            this.col_tentruyen.FieldName = "Tentruyen";
            this.col_tentruyen.MinWidth = 25;
            this.col_tentruyen.Name = "col_tentruyen";
            this.col_tentruyen.Visible = true;
            this.col_tentruyen.VisibleIndex = 0;
            this.col_tentruyen.Width = 94;
            // 
            // col_tuatruyen
            // 
            this.col_tuatruyen.Caption = "gridColumn1";
            this.col_tuatruyen.FieldName = "Tuatruyen";
            this.col_tuatruyen.MinWidth = 25;
            this.col_tuatruyen.Name = "col_tuatruyen";
            this.col_tuatruyen.Visible = true;
            this.col_tuatruyen.VisibleIndex = 1;
            this.col_tuatruyen.Width = 94;
            // 
            // UserTuaTruyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "UserTuaTruyen";
            this.Size = new System.Drawing.Size(926, 614);
            this.Load += new System.EventHandler(this.UserTuaTruyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_hinhanh;
        private DevExpress.XtraGrid.Columns.GridColumn col_tentruyen;
        private DevExpress.XtraGrid.Columns.GridColumn col_tuatruyen;
    }
}
