namespace ImgViewer.Models
{
    public class ZipBook : Book
    {
        protected ZipBook()
        {
            _parent = _parent + "ZipBook()";
        }
        public ZipBook(string path) : base()
        {
            _parent = _parent + "ZipBook(" + path + ")";
        }
        
    }
}