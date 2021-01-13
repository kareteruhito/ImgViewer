using System.Drawing;

namespace Models
{
    public class ZipBook : Book
    {
        string _parent = "";
        public ZipBook() : base()
        {

        }
        public ZipBook(string path) : base()
        {
            _parent = path;

            var files = Storage.GetEntriesFromZip(path);

            _list.AddRange(files);
            MoveFirst();
        }
        public override Bitmap Page
        {
            get
            {
                if (!Any()) return null;

                return Storage.LoadBitmapFromZip(_parent, Value);
            }
        }
    }
}