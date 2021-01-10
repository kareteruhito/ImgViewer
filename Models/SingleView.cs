using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks.Dataflow;
namespace ImgViewer.Models
{
    public class SingleView : IBook
    {
        IBook _bookShelf;

        protected SingleView() {}

        public SingleView(IBook bookShelf)
        {
            _bookShelf = bookShelf;
        }

        public bool Any() => _bookShelf.Any();

        public int Count() => _bookShelf.Count();

        public string GetParent() => _bookShelf.GetParent();

        public Bitmap GetPage() => _bookShelf.GetPage();

        public bool IsFirst() => _bookShelf.IsFirst();

        public bool IsLast() => _bookShelf.IsLast();

        public bool MoveNext() => _bookShelf.MoveNext();

        public bool MovePrevious() => _bookShelf.MovePrevious();

        public bool MoveFirst() => _bookShelf.MoveFirst();

        public bool MoveLast() => _bookShelf.MoveLast();

        public bool MoveAt(string path) => _bookShelf.MoveAt(path);

        public IEnumerable<string> GetEntries() => _bookShelf.GetEntries();

        public string GetName() => _bookShelf.GetName();

    }
}