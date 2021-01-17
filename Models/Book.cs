using System.Drawing;

namespace Models
{
    public class Book : IndexList<string>, IBook
    {
        public string Parent {get; protected set;}

        public Book() : base()
        {

        }
        public Book(string path) : base()
        {
            Parent = path;

            var files = Storage.GetEntriesFromDir(path);

            AddRange(files);
            MoveFirst();
        }
        public virtual System.Drawing.Bitmap Page
        {
            get
            {
                if (!Any()) return null;

                //return Storage.LoadBitmapFromDir(Value);
                return Storage.LoadBitmap(Value);
            }
        }
    }
}