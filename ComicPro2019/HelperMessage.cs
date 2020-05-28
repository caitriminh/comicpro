using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComicPro2019
{
    internal class HelperMessage
    {

        private static readonly Lazy<HelperMessage> lazy = new Lazy<HelperMessage>(() => new HelperMessage());
        public static HelperMessage Instance => lazy.Value;


        public DialogResult ShowMessageYesNo(string text, string caption, Bitmap bitmap)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = caption;
            IntPtr icH = bitmap.GetHicon();
            Icon ico = Icon.FromHandle(icH);
            args.Icon = ico;
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.Text = text;
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            args.Showing += (s, e) =>
            {
                foreach (var control in e.Form.Controls)
                {
                    SimpleButton button = control as SimpleButton;
                    if (button != null)
                    {
                        button.ImageOptions.SvgImageSize = new Size(16, 16);
                        switch (button.DialogResult.ToString())
                        {
                            case ("Yes"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[0];
                                button.Text = "Đồng ý";
                                // button.ForeColor = Color.Green;
                                // button.Font = new Font(button.Font, FontStyle.Bold);
                                button.AllowFocus = true;
                                button.Width = 90;
                                break;
                            case ("No"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[1];
                                button.Text = "Đóng";
                                break;

                        }
                    }
                }
            };
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            return XtraMessageBox.Show(args);

        }

        public DialogResult ShowMessageYesNoCancel(string text, string caption, Bitmap bitmap)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = caption;
            IntPtr icH = bitmap.GetHicon();
            Icon ico = Icon.FromHandle(icH);
            args.Icon = ico;
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.Text = text;
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel };
            args.Showing += (s, e) =>
            {
                foreach (var control in e.Form.Controls)
                {
                    SimpleButton button = control as SimpleButton;
                    if (button != null)
                    {
                        button.ImageOptions.SvgImageSize = new Size(16, 16);
                        switch (button.DialogResult.ToString())
                        {
                            case ("Yes"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[0];
                                button.Text = "Duyệt";
                                // button.ForeColor = Color.Green;
                                // button.Font = new Font(button.Font, FontStyle.Bold);
                                button.AllowFocus = true;
                                button.Width = 90;
                                break;
                            case ("No"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[2];
                                button.Text = "Hủy";
                                break;
                            case ("Cancel"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[1];
                                button.Text = "Thoát";
                                break;

                        }
                    }
                }
            };
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            return XtraMessageBox.Show(args);

        }

        public DialogResult ShowMessageOK(string text, string caption, Bitmap bitmap)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = caption;
            IntPtr icH = bitmap.GetHicon();
            Icon ico = Icon.FromHandle(icH);
            args.Icon = ico;
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.Text = text;
            args.Buttons = new DialogResult[] { DialogResult.OK };
            args.Showing += (s, e) =>
            {
                foreach (var control in e.Form.Controls)
                {
                    SimpleButton button = control as SimpleButton;
                    if (button != null)
                    {
                        button.ImageOptions.SvgImageSize = new Size(16, 16);
                        switch (button.DialogResult.ToString())
                        {

                            case ("OK"):
                                button.ImageOptions.Image = Form1.Default.imageCollectionSmall.Images[1];
                                button.Text = "Đóng";
                                button.AllowFocus = true;
                                break;

                        }
                    }
                }
            };
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            return XtraMessageBox.Show(args);

        }
    }
}
