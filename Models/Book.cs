using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ImgViewer.Models
{
    public class Book : IBook
    {
        protected string _parent;

        protected List<string> _files;

        protected int _index;

        public Book()
        {
            _parent = "";
            _files = new List<string>();
            _index = -1;
        }
        public Book(string path)
        {

            if (File.Exists(path))
            {
                _parent = Path.GetDirectoryName(path);
                _files = Strage.GetEntriesFromDir(_parent);
                if (MoveAt(path) == false)
                {
                    if (Any()) _index = 0;    
                }
            }
            else
            {
                _parent = path;
                _files = Strage.GetEntriesFromDir(_parent);
                if (Any()) _index = 0;
            }


        }
        public bool Any()
        {
            return _files.Any();
        }
        public int Count()
        {
            return _files.Count;
        }

        public string GetParent()
        {
            return _parent;
        }
        public virtual Bitmap GetPage()
        {
            if (Any() == false) return new Bitmap(1, 1);

            return Strage.LoadBitmapFromDir(_files[_index]);
        }

        public bool IsFirst()
        {
            if (Any() == false) return false;

            return _index == 0;
        }

        public bool IsLast()
        {
            if (Any() == false) return false;

            return _index == Count() - 1;
        }

        public bool MoveAt(string path)
        {
            if (Any() == false) return false;

            _index = _files.IndexOf(path);

            return _index > - 1;
        }

        public virtual bool MoveFirst()
        {
            if (Any() == false) return false;

            _index = 0;
            return true;
        }

        public virtual bool MoveLast()
        {
            if (Any() == false) return false;

            _index = Count() - 1;
            return true;
        }

        public virtual bool MoveNext()
        {
            if (Any() == false) return false;
            if (IsLast()) return false;

            _index++;
            return true;
        }

        public virtual bool MovePrevious()
        {
            if (Any() == false) return false;
            if (IsFirst()) return false;

            _index--;
            return true;
        }
        public IEnumerable<string> GetEntries()
        {
            foreach(var x in _files)
            {
                yield return x;
            }
        }
        public string GetName()
        {
            if (Any()==false) return "";
            return _files[_index];
        }

    }
}