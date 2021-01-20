using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
namespace Models
{
    public class SquareViewMode : IBook
    {
        int _y = 0;
        private Book _book;

        public SquareViewMode(Book book)
        {
            _book = book;
        }
        public bool IsFirst
        {
            get
            {
                return _book.IsFirst && _y == 0;
            }
        }
        public bool IsLast
        {
            get
            {
                var bmp = _book.Page;
                return _book.IsLast && Graphic.IsTailSquareBitmap(bmp, _y);
            }
        }

        public bool MoveNext()
        {
            var bmp = _book.Page;

            if (Graphic.IsTailSquareBitmap(bmp, _y))
            {
                _y = 0;
                return _book.MoveNext();
            }

            _y = Graphic.NextSquareBitmap(bmp, _y);
            return true;
        }

        public bool MovePrevious()
        {
            var bmp = _book.Page;

            if (_book.MovePrevious())
            {
                _y = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public System.Drawing.Bitmap Page
        {
            get
            {
                return Graphic.GetSquareBitmap(_book.Page, _y);
            }
        }

        public bool MoveFirst()
        {
            _y = 0;
            return _book.MoveFirst();
        }
        public bool MoveLast()
        {
            _y = 0;
            return _book.MoveLast();
        }
    }
}