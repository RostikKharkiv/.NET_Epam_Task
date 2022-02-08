using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._2._1
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    { 
        protected long _capacity;

        protected T[] _data;

        public long Length { get; private set; }

        public long Capacity
        {
            get 
            { 
                return _capacity; 
            }
            set 
            {
                if (value >= Length)
                {
                    _capacity = value;
                }
                else if (value < Length && value > 0)
                {
                    RemoveRange(value, Length);

                    Length = value;

                    _capacity = value;
                }
            }
        }

        protected DynamicArray(IEnumerable<T> collection, long capacity)
        {
            Capacity = capacity;

            _data = new T[Capacity];

            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public DynamicArray(IEnumerable<T> collection) : this(collection, collection.Count())
        {

        }

        public DynamicArray(long capacity)
        {
            Capacity = capacity;

            _data = new T[Capacity];
        }

        public DynamicArray() : this(8)
        {

        }

        public bool Equals(DynamicArray<T> obj)
        {
            if (this == null || obj == null)
            {
                return false;
            }
            if (this.GetType() != typeof(DynamicArray<T>) ||
                obj.GetType() != typeof(DynamicArray<T>))
            {
                return false;
            }
            if (this.Length != obj.Length)
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                if (!this[i].Equals(obj[i]))
                {
                    return false;
                }
            }

            return true;
        }

        protected bool IsValidIndex(ref long index)
        {
            if (index >= Length)
            {
                index %= Length;
                return true;
            }
            else if (index < 0 && Math.Abs(index) < Length)
            {
                index = Length - Math.Abs(index);
                return true;
            }
            else if (index < 0 && Math.Abs(index) >= Length)
            {
                index = Length - Math.Abs(index) % Length;
                return true;
            }

            return false;

            //if (index >= Length || index < 0)
            //{
            //    throw new IndexOutOfRangeException("Index should be lower than length of array and greater or equals than zero");
            //}
        }

        protected void Resize()
        {
            if (Capacity <= Length)
            {
                DynamicArray<T> temp = new DynamicArray<T>(_data, Capacity * 2);

                this.Capacity = temp.Capacity;
                this._data = temp._data;
            }
        }

        protected void Resize(long lengthCollection)
        {
            if (Capacity <= Length + lengthCollection)
            {
                DynamicArray<T> temp = new DynamicArray<T>(_data, Length + lengthCollection);

                this.Capacity = temp.Capacity;
                this._data = temp._data;
            }
        }

        public bool Remove(T obj) => RemoveAt(IndexOf(obj));

        public bool RemoveFirst(T obj) => RemoveAt(0);

        public bool RemoveLast(T obj) => RemoveAt(Length - 1);

        public bool AddFirst(T obj) => InsertAt(obj, 0);

        public bool AddLast(T obj)
        {
            Resize();

            try
            {
                _data[Length] = obj;
                Length++;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public long IndexOf(T obj)
        {
            for (long i = 0; i < Length; i++)
            {
                if (_data[i].Equals(obj))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool AddRange(T[] collection)
        {
            Resize(collection.Length);

            try
            {
                foreach (var item in collection)
                {
                    _data[Length] = item;
                    Length++;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertAt(T obj, long index)
        {
            IsValidIndex(ref index);
            Resize();

            try
            {
                Length++;

                for (long i = Length - 1; i > index; i--)
                {
                    _data[i] = _data[i - 1];
                }

                _data[index] = obj;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveAt(long index)
        {
            IsValidIndex(ref index);

            try
            {
                for (long i = index; i < Length - 1; i++)
                {
                    _data[i] = _data[i + 1];
                }

                _data[Length - 1] = default(T);
                Length--;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveRange(long index1, long index2)
        {
            if (!(IsValidIndex(ref index1) && IsValidIndex(ref index2)))
            {
                return false;
            }

            long temp;

            if (index2 < index1)
            {
                temp = index1;
                index1 = index2;
                index2 = index1;
            }

            try
            {
                for (long i = index1; i < index2; i++)
                {
                    RemoveAt(i);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public T this[long index]
        {
            get
            {
                IsValidIndex(ref index);

                return _data[index];
            }
            set
            {
                IsValidIndex(ref index);

                _data[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        public class DynamicArrayEnumerator : IEnumerator<T>
        {
            protected DynamicArray<T> _array;
            protected T _current;
            protected int index = -1;

            public DynamicArrayEnumerator(DynamicArray<T> array)
            {
                _array = array;
            }

            public T Current
            {
                get
                {
                    if (index != -1 && index < _array.Length)
                    {
                        _current = _array[index];
                        return _current;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index != -1)
                    {
                        _current = _array[index];
                        return _current;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }

            public void Dispose()
            {
                _current = default(T);
            }

            public bool MoveNext()
            {
                if (index < _array.Length - 1) 
                { 
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator(this);
        }

        public class CycledDynamicArrayEnumerator : DynamicArrayEnumerator
        {
            public CycledDynamicArrayEnumerator(CycledDynamicArray<T> array) : base(array)
            {
            }

            public new bool MoveNext()
            {
                if (index < _array.Length - 1)
                {
                    index++;
                    return true;
                }

                if (index <= _array.Length - 1)
                {
                    index = 0;
                    return true;
                }

                return false;
            }
        }
    }
}
