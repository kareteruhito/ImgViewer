using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
namespace Models
{
    public class SingleViewMode : IBook
    {
        private Book _book;

        public SingleViewMode(Book book)
        {
            _book = book;
        }
        public bool IsFirst { get => _book.IsFirst; }
        public bool IsLast { get => _book.IsLast; }

        public bool MoveNext() => _book.MoveNext();

        public bool MovePrevious() => _book.MovePrevious();

        public System.Drawing.Bitmap Page { get => _book.Page; }

        public bool MoveFirst() => _book.MoveFirst();
        public bool MoveLast() => _book.MoveLast();
        public string Parent { get => _book.Parent; }
    }
}