using System.IO;
using System.Drawing;

namespace Models
{
    public class BookShelf : IndexList<Book>
    {
        string _viewMode = "SingleViewMode";
        IBook _book;
        public string Parent { get; private set;}

        public BookShelf() : base()
        {

        }
        public BookShelf(string path) : base()
        {
            if (File.Exists(path))
            {
                Parent = Path.GetDirectoryName(path);
            }
            else
            {
                Parent = path;
            }

            int counter = 0;
            var entries = Storage.GetBookEntries(Parent);
            if (Any()) Index = 0;
            foreach(var entry in entries)
            {
                Add(BookMaker.Create(entry));
                if (entry == Parent) Index = counter;
                if (entry == path) Index = counter;
                
                counter++;
            }

            if (Storage.IsPictureFile(path))
            {
                Value.MoveAt(path);
            }

            _book = ViewModeSelector.Create(Value, ViewMode);
        }
        public bool MoveAt(string path)
        {
            if (Any() == false) return false;

            int counter = 0;
            foreach(var entry in Entries)
            {
                if (entry.Parent == path) Index = counter;
                counter++;
            }

            _book = ViewModeSelector.Create(Value, ViewMode);
            return true;
        }
        public override bool MoveNext()
        {
            if (Any() == false) return false;
            
            if (_book.IsLast)
            {
                if (base.MoveNext())
                {
                    _book = ViewModeSelector.Create(Value, ViewMode);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _book.MoveNext();
            }
        }
        public override bool MovePrevious()
        {
            if (Any() == false) return false;
            
            if (_book.IsFirst)
            {
                if (base.MovePrevious())
                {
                    _book = ViewModeSelector.Create(Value, ViewMode);
                    _book.MoveLast();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _book.MovePrevious();
            }
        }
        public virtual System.Drawing.Bitmap Page
        {
            get
            {
                return _book.Page;
            }
        }
        public string ViewMode
        {
            set
            {
                _viewMode = value;
                if (Any())
                {
                    _book = ViewModeSelector.Create(Value, ViewMode);
                }
            }
            get
            {
                return _viewMode;
            }
        }
    } // class
} // namespace
