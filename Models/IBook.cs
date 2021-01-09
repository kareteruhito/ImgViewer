using System.Collections.Generic;
using System.Drawing;

namespace ImgViewer.Models
{
    public interface IBook
    {
        bool Any();
        int Count();
        string GetParent();
        Bitmap GetPage();

        bool IsFirst();
        bool IsLast();
        bool MoveNext();
        bool MovePrevious();
        bool MoveFirst();
        bool MoveLast();
        bool MoveAt(string path);
        IEnumerable<string> GetEntries();
        string GetName();
    }
}