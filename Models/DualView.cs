using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks.Dataflow;
namespace ImgViewer.Models
{
    public class DualView : IBook
    {
        IBook _bookShelf;

        protected DualView() {}

        public DualView(IBook bookShelf)
        {
            _bookShelf = bookShelf;
        }

        public bool Any() => _bookShelf.Any();

        public int Count() => _bookShelf.Count();

        public string GetParent() => _bookShelf.GetParent();

        public Bitmap GetPage()
        {
            var r = _bookShelf.GetPage();

            if (MoveNext() == false) return r;

            var l = _bookShelf.GetPage();

            var bmp = Graphic.JoinBitmap(l, r);

            r.Dispose();
            l.Dispose();

            return bmp; 
            
        }

        public bool IsFirst() => _bookShelf.IsFirst();

        public bool IsLast() => _bookShelf.IsLast();

        public bool MoveNext() => _bookShelf.MoveNext();

        public bool MovePrevious()
        {
            if (_bookShelf.MovePrevious())
            {
                if (_bookShelf.MovePrevious())
                {
                    return _bookShelf.MovePrevious();
                }
            }

            return false;
        }

        public bool MoveFirst() => _bookShelf.MoveFirst();

        public bool MoveLast() => _bookShelf.MoveLast();

        public bool MoveAt(string path) => _bookShelf.MoveAt(path);

        public IEnumerable<string> GetEntries() => _bookShelf.GetEntries();

        public string GetName() => _bookShelf.GetName();

    }
}