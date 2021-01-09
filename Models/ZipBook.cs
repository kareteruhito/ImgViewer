using System.Linq;

namespace ImgViewer.Models
{
    public class ZipBook : Book
    {
        public ZipBook()
        {
        }
        public ZipBook(string path) : base()
        {
            _parent = path;

            _files = Strage.GetEntriesFromZip(path);

            if (_files.Any())  _index = 0;
        }
        public override System.Drawing.Bitmap GetPage()
        {
            if (Any() == false) return new System.Drawing.Bitmap(1, 1);

            return Strage.LoadBitmapFromZip(_parent, _files[_index]);
        }
        
    }
}