namespace Models
{
    public class BookShelf : IBookShelf
    {
        const string _label = "本棚";
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
        public string GetLabel()
        {
            return _label;
        }
    }
}