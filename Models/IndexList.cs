using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace Models
{
    public class IndexList<T>
    {
        public IndexList() {}
        protected const int _outrange = -1;
        public int Index {get; protected set;} = _outrange;
        protected List<T> _list = new();

        public bool Any() => _list.Any();

        public int Count { get => _list.Count; }

        public int First { get => Any() ? 0 : _outrange; }
        public int Last { get => Any() ? Count - 1 : _outrange; }

        public bool IsFirst { get => Index == First; }
        public bool IsLast { get => Index == Last; }

        public void Add(T param)
        {
            _list.Add(param);
            
            if (Index == _outrange && Any()) Index = First;
        }
        
        public void AddRange(IEnumerable<T> param)
        {
            _list.AddRange(param);

            if (Index == _outrange && Any()) Index = First;
        }

        public IEnumerable<T> Entries
        {
            get
            {
                foreach(var entry in _list)
                {
                    yield return entry;       
                }
            }
        }
        public virtual bool MoveNext()
        {
            if (!Any()) return Any();
            if (IsLast) return !IsLast;

            Index++;
            return true;
        }
        public virtual bool MovePrevious()
        {
            if (!Any()) return Any();
            if (IsFirst) return !IsFirst;

            Index--;
            return true;
        }
        public virtual bool MoveFirst()
        {
            if (!Any()) return Any();
            if (IsFirst) return !IsFirst;

            Index = First;
            return IsFirst;
        }
        public virtual bool MoveLast()
        {
            if (!Any()) return Any();
            if (IsLast) return !IsLast;

            Index = Last;
            return IsLast;
        }
        public T Value
        {
            get
            {
                if (!Any()) return default;
                if (Index == _outrange) return default;

                return _list[Index];
            }
        }
        public virtual bool MoveAt(T param)
        {
            var i = _list.IndexOf(param);

            if (i == _outrange)
            {
                return false;
            }
            Index = i;
            return true;
        }
    }
}