using System.Drawing;

namespace Models
{
    public class Book : IndexList
    {
        public Book() : base()
        {

        }
        public Book(string path) : base()
        {
            var files = Storage.GetEntriesFromDir(path);

            AddRange(files);
            MoveFirst();
        }
        public virtual System.Drawing.Bitmap Page
        {
            get
            {
                if (!Any()) return null;

                return Storage.LoadBitmapFromDir(Value);
            }
        }
    }
}