namespace ComicPro2019.TroGiup
{
    partial class FrmDangKy
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangKy));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txt_serial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_key = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_dangky = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_serial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_key.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(542, 130);
            this.pictureEdit1.TabIndex = 1;
            // 
            // txt_serial
            // 
            this.txt_serial.Location = new System.Drawing.Point(54, 39);
            this.txt_serial.Name = "txt_serial";
            this.txt_serial.Properties.ReadOnly = true;
            this.txt_serial.Size = new System.Drawing.Size(472, 22);
            this.txt_serial.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Serial:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Key:";
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(54, 67);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(472, 103);
            this.txt_key.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txt_serial);
            this.groupControl1.Controls.Add(this.txt_key);
            this.groupControl1.Location = new System.Drawing.Point(4, 134);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(537, 179);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Đăng ký phần mềm";
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(436, 319);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(94, 29);
            this.btn_thoat.TabIndex = 2;
            this.btn_thoat.Text = "&Thoát";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_dangky
            // 
            this.btn_dangky.Location = new System.Drawing.Point(336, 319);
            this.btn_dangky.Name = "btn_dangky";
            this.btn_dangky.Size = new System.Drawing.Size(94, 29);
            this.btn_dangky.TabIndex = 1;
            this.btn_dangky.Text = "&Đăng ký";
            this.btn_dangky.Click += new System.EventHandler(this.btn_dangky_Click);
            // 
            // FrmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 387);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dangky);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "FrmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Phần Mềm";
            this.Load += new System.EventHandler(this.FrmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_serial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_key.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit txt_serial;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txt_key;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_thoat;
        private DevExpress.XtraEditors.SimpleButton btn_dangky;
    }
}