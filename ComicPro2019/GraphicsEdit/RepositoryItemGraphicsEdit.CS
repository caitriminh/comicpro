using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;

namespace ComicPro2019.GraphicsEdit
{
    //The attribute that points to the registration method 
    [UserRepositoryItem("RegisterGraphicsEditor")]
    class RepositoryItemGraphicsEdit : RepositoryItemPictureEdit
    {
        // Static constructor should call registration method
        static RepositoryItemGraphicsEdit() { RegisterGraphicsEditor(); }

        public const string GraphicsEditorName = "GraphicsEdit";
        public override string EditorTypeName { get { return GraphicsEditorName; } }

        public static void RegisterGraphicsEditor()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                GraphicsEditorName, typeof(ComicPro2019.GraphicsEdit.GraphicsEdit), typeof(RepositoryItemGraphicsEdit),
                typeof(GraphicsEditViewInfo), new PictureEditPainter(), true));
        }
    }
}
