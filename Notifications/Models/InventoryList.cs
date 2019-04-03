using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    class InventoryList : IList<Inventory>, INotifyCollectionChanged
    {
        private readonly IList<Inventory> _books;

        public InventoryList(IList<Inventory> books)
        {
            _books = books;
        }

        public IEnumerator<Inventory> GetEnumerator() => _books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(Inventory item)
        {
            _books.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            _books.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(Inventory item) => _books.Contains(item);

        public void CopyTo(Inventory[] array, int arrayIndex)
        {
            _books.CopyTo(array, arrayIndex);
        }

        public int Count => _books.Count;

        public bool IsReadOnly => _books.IsReadOnly;

        public int IndexOf(Inventory item) => _books.IndexOf(item);

        public void Insert(int index, Inventory item)
        {
            _books.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add, item, index));
        }

        public bool Remove(Inventory item)
        {
            var removed = _books.Remove(item);
            if (removed)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Remove, item));
            }
            return removed;
        }

        public void RemoveAt(int index)
        {
            var item = _books[index];
            _books.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Remove, item, index));
        }

        public Inventory this[int index]
        {
            get { return _books?[index]; }
            set
            {
                _books[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Replace, _books[index]));
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
}
