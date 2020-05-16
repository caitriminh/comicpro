using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace ComicPro2019.GraphicsEdit
{
    class GraphicsEditViewInfo : PictureEditViewInfo
    {
        public GraphicsEditViewInfo(RepositoryItem item) : base(item) { }

        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                if (value != null && value.GetType() == typeof(System.String))
                {
                    try { base.EditValue = new Bitmap(value.ToString()); }
                    catch { base.EditValue = Item.ErrorImage; }
                }
                else
                    base.EditValue = value;
            }
        }
    }
}
