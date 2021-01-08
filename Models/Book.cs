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

        protected Book()
        {
            _parent = "";
            _files = new List<string>();
            _index = -1;
        }
        public Book(string path)
        {
            _parent = path;

            string dir = "";
            if (File.Exists(path))
            {
                dir = Path.GetDirectoryName(path);
                _files = Strage.GetEntriesFromDir(dir);
                if (MoveAt(path) == false)
                {
                    if (Any()) _index = 0;    
                }
            }
            else
            {
                dir = path;
                _files = Strage.GetEntriesFromDir(dir);
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
        public Bitmap GetPage()
        {
            if (Any() == false) return null;

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

        public bool MoveFirst()
        {
            if (Any() == false) return false;

            _index = 0;
            return true;
        }

        public bool MoveLast()
        {
            if (Any() == false) return false;

            _index = Count() - 1;
            return true;
        }

        public bool MoveNext()
        {
            if (Any() == false) return false;
            if (IsLast()) return false;

            _index++;
            return true;
        }

        public bool MovePrevious()
        {
            if (Any() == false) return false;
            if (IsFirst()) return false;

            _index--;
            return true;
        }
        public bool MoveLast()
        {
            if (Any() == false) return false;
            if (IsLast()) return true;

            Index = Count - 1;

            return true;
        }
        public bool MoveFirst()
        {
            if (Any() == false) return false;
            if (IsFirst()) return true;

            Index = 0;

            return true;
        }
    }
}