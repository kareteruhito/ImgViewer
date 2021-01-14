using System.IO;
using System.Drawing;

namespace Models
{
    public class BookShelf : IndexList
    {
        public string Parent { get; private set;}

        Book _book;

        public BookShelf() : base()
        {

        }
        public BookShelf(string path) : base()
        {
            _book = BookMaker.Create(path);

            if (File.Exists(path))
            {
                Parent = Path.GetDirectoryName(path);
            }
            else
            {
                Parent = path;
            }

            var bookFiles = Storage.GetBookEntries(Parent);
            AddRange(bookFiles);

            if (Any())
            {
                if (MoveAt(path) == false)
                {
                    MoveAt(Parent);
                }
            }
        }
        public override bool MoveNext()
        {
            if (base.MoveNext() == false) return false;

            _book = BookMaker.Create(Value);
            return true;
        }
        public override bool MovePrevious()
        {
            if (base.MovePrevious() == false) return false;

            _book = BookMaker.Create(Value);
            return true;
        }
        public override bool MoveFirst()
        {
            if (base.MoveFirst() == false) return false;

            _book = BookMaker.Create(Value);
            return true;
        }
        public override bool MoveLast()
        {
            if (base.MoveLast() == false) return false;

            _book = BookMaker.Create(Value);
            return true;
        }
        public override bool MoveAt(string key)
        {
            if (base.MoveAt(key) == false) return false;

            _book = BookMaker.Create(Value);
            return true;
        }
        public Book GetBook()
        {
            return _book;
        }
    }
}
