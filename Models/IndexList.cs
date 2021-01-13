using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace Models
{
    public class IndexList
    {
        public IndexList() {}
        protected const int _outrange = -1;
        public int Index {get; protected set;} = _outrange;
        protected List<string> _list = new List<string>();

        public bool Any() => _list.Any();

        public int Count { get => _list.Count; }

        public int First { get => Any() ? 0 : _outrange; }
        public int Last { get => Any() ? Count - 1 : _outrange; }

        public bool IsFirst { get => Index == First; }
        public bool IsLast { get => Index == Last; }

        public void Add(string str)
        {
            _list.Add(str);
            
            if (Index == _outrange && Any()) Index = First;
        }
        
        public void AddRange(IEnumerable<string> list)
        {
            _list.AddRange(list);

            if (Index == _outrange && Any()) Index = First;
        }

        public IEnumerable<string> Entries
        {
            get
            {
                foreach(var entry in _list)
                {
                    yield return entry;       
                }
            }
        }
        public bool MoveNext()
        {
            if (!Any()) return Any();
            if (IsLast) return !IsLast;

            Index++;
            return true;
        }
        public bool MovePrevious()
        {
            if (!Any()) return Any();
            if (IsFirst) return !IsFirst;

            Index--;
            return true;
        }
        public bool MoveFirst()
        {
            if (!Any()) return Any();
            if (IsFirst) return !IsFirst;

            Index = First;
            return IsFirst;
        }
        public bool MoveLast()
        {
            if (!Any()) return Any();
            if (IsLast) return !IsLast;

            Index = Last;
            return IsLast;
        }
        public string Value
        {
            get
            {
                if (!Any()) return null;
                if (Index == _outrange) return null;

                return _list[Index];
            }
        }
    }
}