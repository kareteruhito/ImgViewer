using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
namespace Models
{
    public class DualViewMode : IBook
    {
        private Book _book;

        public DualViewMode(Book book)
        {
            _book = book;
        }
        public bool IsFirst
        {
            get
            {
                return _book.IsFirst;
            }
        }
        public bool IsLast
        {
            get
            {
                return _book.IsLast;
            }
        }

        public bool MoveNext()
        {
            if (_book.MoveNext() == false) return false;

            _book.MoveNext();

            return true;
        }

        public bool MovePrevious()
        {
            if (_book.MovePrevious() == false) return false;

            _book.MovePrevious();

            return true;
        }

        public System.Drawing.Bitmap Page
        {
            get
            {
                var bmp1 = _book.Page;

                if (_book.MoveNext())
                {
                    var bmp2 = _book.Page;
                    var bmp3 = Graphic.JoinBitmap(bmp2, bmp1);

                    //bmp1.Dispose();
                    //bmp2.Dispose();

                    _book.MovePrevious();

                    return bmp3;
                }
                else
                {
                    return bmp1;
                }
            }
        }
        public bool MoveFirst() => _book.MoveFirst();
        public bool MoveLast()
        {
            bool r = _book.MoveLast();

            if (_book.Count % 2 == 0)
            {
                _book.MovePrevious();
            }

            return r;
        }
        public string Parent { get => _book.Parent; }
    } // class
} // namespace