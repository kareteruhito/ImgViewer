namespace Models
{
    public interface IBook
    {
        bool IsFirst { get; }
        bool IsLast { get; }

        bool MoveNext();
        bool MovePrevious();
        bool MoveFirst();
        bool MoveLast();

        System.Drawing.Bitmap Page { get; }

        string Parent { get; }
    }
}