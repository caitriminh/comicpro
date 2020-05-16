using System.ComponentModel;
using DevExpress.XtraEditors;

namespace ComicPro2019.GraphicsEdit
{
    class GraphicsEdit : PictureEdit
    {
        static GraphicsEdit() { RepositoryItemGraphicsEdit.RegisterGraphicsEditor(); }

        public override string EditorTypeName { get { return RepositoryItemGraphicsEdit.GraphicsEditorName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemGraphicsEdit Properties
        { get { return base.Properties as RepositoryItemGraphicsEdit; } }

        protected override DevExpress.XtraEditors.Controls.PictureMenu Menu { get { return null; } }
    }
}
