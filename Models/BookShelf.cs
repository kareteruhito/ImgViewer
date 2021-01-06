namespace Models
{
    public class BookShelf : IBookShelf
    {
        string _path;
        public BookShelf(){}
        public string GetClassName()
        {
            return nameof(BookShelf);
        }
        public void SetPath(string path)
        {
            _path = path;
        }
        public string GetPath()
        {
            return _path;
        }
    }
}