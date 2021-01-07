using System.Reflection.Metadata;

namespace ImgViewer.Models
{
    public class DualView : IBookShelf
    {
        const string _label = "見開き表示";
        IBookShelf _bookShelf;
        public DualView(IBookShelf bookShelf)
        {
            _bookShelf = bookShelf;
        }
        public string GetClassName()
        {
            return nameof(DualView);
        }
        public void SetPath(string path)
        {
            _bookShelf.SetPath(path);
        }
        public string GetPath()
        {
            return _bookShelf.GetPath();
        }
        public string GetLabel()
        {
            return _label;
        }
    }
}