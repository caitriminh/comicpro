using System;

namespace ComicPro2019.HeThong
{
    public partial class FrmViewExcel : DevExpress.XtraEditors.XtraForm
    {
        public FrmViewExcel()
        {
            InitializeComponent();
            try
            {
                MdiParent = Form1.Default;
            }
            catch (Exception)
            {
                // throw;
            }
        }

        private string _url;
        public FrmViewExcel(string url)
        {
            InitializeComponent();
            _url = url;
            try
            {
                MdiParent = Form1.Default;
            }
            catch (Exception)
            {
                // throw;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            spExcel.LoadDocument(_url);
        }
    }
}