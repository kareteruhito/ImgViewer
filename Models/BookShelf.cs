using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImgViewer.Models
{
    public class BookShelf : Book
    {
        Book _book;

        public BookShelf()
        {

        }

        public BookShelf(string path) : base()
        {
            _parent = File.Exists(path) ? Path.GetDirectoryName(path) : path;
            _files = Strage.GetBookEntries(_parent);
            if (_files.Any() == false)
            {
                _index = -1;
                return;
            }
            _index = _files.IndexOf(_parent);
            if (_index > -1)
            {
                _book = BookMaker.Create(path);
            }
            else
            {
                _index = 0;
                _book = BookMaker.Create(_files[_index]);
            }
        }
        public override System.Drawing.Bitmap GetPage()
        {
            if (Any() == false) return new System.Drawing.Bitmap(1, 1);

            return _book.GetPage();
        }
        public override bool MoveFirst()
        {
            if (Any() == false) return false;

            _index = 0;
            var bookPath = GetName();
            _book = BookMaker.Create(bookPath);
            
            return true;
        }
        public override bool MoveLast()
        {
            if (Any() == false) return false;

            _index = Count() - 1;
            var bookPath = GetName();
            _book = BookMaker.Create(bookPath);

            return true;
        }
        public override bool MoveNext()
        {
            if (Any() == false) return false;
            if (_book.Any() == false) return false;

            if (_book.IsLast() == false)
            {
                return _book.MoveNext();
            }

            if (IsLast()) return false;

            _index++;
             var bookPath = GetName();
            _book = BookMaker.Create(bookPath);

           return true;
        }
        public override bool MovePrevious()
        {
            if (Any() == false) return false;

            if (_book.IsFirst() == false)
            {
                return _book.MovePrevious();
            }


            if (IsFirst()) return false;

            _index--;
             var bookPath = GetName();
            _book = BookMaker.Create(bookPath);
            _book.MoveLast();

            return true;
        }

    }
}