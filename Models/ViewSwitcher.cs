using System;
using System.Collections.Generic;

namespace ImgViewer.Models
{
    public class ViewSwitcher : IBook
    {
        IBook _core;
        IBook _bookShelf;
        Dictionary<string, IBook> _views = new Dictionary<string, IBook>();

        string _viewName;

        public ViewSwitcher()
        {
            _core = new BookShelf();

            _views.Add(nameof(SingleView), new SingleView(_core));
            _views.Add(nameof(DualView), new DualView(_core));
            _views.Add(nameof(SquareView), new SquareView(_core));

            ChangeMode(nameof(SquareView));
        }

        public ViewSwitcher(string path)
        {
            _core = new BookShelf(path);

            _views.Add(nameof(SingleView), new SingleView(_core));
            _views.Add(nameof(DualView), new DualView(_core));
            _views.Add(nameof(SquareView), new SquareView(_core));

            ChangeMode(nameof(SquareView));
        }
        public bool ChangeMode(string viewName)
        {
            if (_views.ContainsKey(viewName) == false) return false;

            _viewName = viewName;

            _bookShelf = _views[_viewName];

            return true;
        }

        public bool Any() => _bookShelf.Any();

        public int Count() => _bookShelf.Count();

        public string GetParent() => _bookShelf.GetParent();

        public System.Drawing.Bitmap GetPage() => _bookShelf.GetPage();

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