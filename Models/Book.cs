using System;
using System.Collections.Generic;
using System.Linq;

namespace ImgViewer.Models
{
    public class Book
    {
        string _path = "";
        List<string> _files = new List<string>();
        public int Index {get; set;} = -1;

        public Book()
        {

        }
        public virtual string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _files.Clear();
                Index = -1;
                _path = value;
            }
        }
        public int Count
        {
            get
            {
                return _files.Count;
            }
        }
        public bool Any()
        {
            return _files.Any();
        }
        
        public bool IsFirst()
        {
            if (Any() == false) return false;
            return Index == 0;
        }
        public bool IsLast()
        {
            if (Any() == false) return false;
            return Index == Count - 1;
        }
        public bool MoveNext()
        {
            if (Any() == false) return false;
            if (IsLast()) return false;

            Index++;

            return true;
        }
        public bool MovePrevious()
        {
            if (Any() == false) return false;
            if (IsFirst()) return false;

            Index--;

            return true;
        }

        public string FileName
        {
            get
            {
                if (Any() == false) return "";
                return _files[Index];
            }
        }
    }
}