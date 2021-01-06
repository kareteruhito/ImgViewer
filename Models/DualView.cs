namespace Models
{
    public class DualView : IBookShelf
    {
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
    }
}