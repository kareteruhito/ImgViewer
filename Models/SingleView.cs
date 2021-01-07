namespace Models
{
    public class SingleView : IBookShelf
    {
        const string _label = "単ページ";
        IBookShelf _bookShelf;
        public SingleView(IBookShelf bookShelf)
        {
            _bookShelf = bookShelf;
        }
        public string GetClassName()
        {
            return nameof(SingleView);
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