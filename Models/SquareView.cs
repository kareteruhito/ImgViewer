using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks.Dataflow;
namespace ImgViewer.Models
{
    public class SquareView : IBook
    {
        IBook _bookShelf;

        Bitmap _bmp = null;

        int _y = 0;

        protected SquareView() {}

        public SquareView(IBook bookShelf)
        {
            _bookShelf = bookShelf;
        }

        public bool Any() => _bookShelf.Any();

        public int Count() => _bookShelf.Count();

        public string GetParent() => _bookShelf.GetParent();

        public Bitmap GetPage()
        {
            if (_bmp == null)
            {
                _bmp = _bookShelf.GetPage();
                _y = 0;
            }
            else
            {
                _y = Graphic.NextSquareBitmap(_bmp, _y);
            }

            if (_bmp.Width >= _bmp.Height)
            {
                return _bmp.Clone() as Bitmap;
            }
            else
            {
                return Graphic.GetSquareBitmap(_bmp, _y);
            }
        }

        public bool IsFirst() => _bookShelf.IsFirst();

        public bool IsLast() => _bookShelf.IsLast();

        public bool MoveNext()
        {
            if (Graphic.IsTailSquareBitmap(_bmp, _y))
            {
                if (_bookShelf.MoveNext())
                {
                    _bmp.Dispose();
                    _bmp = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool MovePrevious()
        {
            if (_bookShelf.MovePrevious())
            {
                _bmp.Dispose();
                _bmp = null;
                _y = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveFirst() => _bookShelf.MoveFirst();

        public bool MoveLast() => _bookShelf.MoveLast();

        public bool MoveAt(string path) => _bookShelf.MoveAt(path);

        public IEnumerable<string> GetEntries() => _bookShelf.GetEntries();

        public string GetName() => _bookShelf.GetName();

    }
}