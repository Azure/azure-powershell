using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public class PSDataCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IDisposable
    {
        internal PSDataCollection(IList<T> collection)
        {
            _collection = collection;
        }

        public PSDataCollection() : this (new List<T>())
        {
        }

        public PSDataCollection(IEnumerable<T> items) : this (items as IList<T>)
        {
        }

        public T this[int index]
        {
            get
            {
                return _collection[index];
            }

            set
            {
                _collection[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _collection.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _collection.Insert(index, item);
        }

        public Collection<T> ReadAll()
        {
            Collection<T> result = new Collection<T>();
            var count = _collection.Count;
            for (int i = 0; i < count; i++)
            {
                result.Add(_collection[i]);
            }

            return result;
        }

        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _collection.RemoveAt(index);
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_collection != null)
                    {
                        _collection.Clear();
                    }
                }

                this._disposed = true;
            }
        }

        private IList<T> _collection;
        private bool _disposed;
    }
}