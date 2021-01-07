namespace Models
{
    public interface IBookShelf
    {
        string GetClassName();
        void SetPath(string path);
        string GetPath();
        string GetLabel();
    }
}