
using System.Collections.Generic;

namespace ImgViewer.Models
{
    public class ViewModeSwitcher
    {
        IBookShelf _bookShelf = new BookShelf();

        Dictionary<string, IBookShelf> _viewModes = new Dictionary<string, IBookShelf>();
        IBookShelf _current;

        ViewModeSwitcher(string path)
        {
            _bookShelf.SetPath(path);

            _viewModes[nameof(SingleView)] = new SingleView(_bookShelf);
            _viewModes[nameof(DualView)] = new DualView(_bookShelf);

            _current = _viewModes[nameof(SingleView)];
        }
        public static ViewModeSwitcher Create(string path)
        {
            return new ViewModeSwitcher(path);
        }
        public IBookShelf ChangeMode(string className)
        {
            _current = _viewModes[className];
            return CurrentMode();
        }
        public IBookShelf CurrentMode()
        {
            return _current;
        }
        public IEnumerable<string> GetClassName()
        {
            foreach (var (key, val) in _viewModes)
            {
                yield return key;
            }
        }
        public string GetLabel(string className)
        {
            return _viewModes[className].GetLabel();
        }
    }
}