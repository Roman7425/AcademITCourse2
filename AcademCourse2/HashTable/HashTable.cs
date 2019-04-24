using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        List<T>[] items;
        public int Count { get; private set; }
        private int modCount = 0;

        public HashTable(int capacity)
        {
            items = new List<T>[capacity];
        }

        public HashTable()
        {
            items = new List<T>[8];
        }

        public void Add(T value)
        {
            int index = Math.Abs(value.GetHashCode() % items.Length);

            if (items[index] == null)
            {
                items[index] = new List<T>();
                items[index].Add(value);
            }
            else
            {
                items[index].Add(value);
            }

            Count++;
            modCount++;
        }

        public void Clear()
        {
            items = new List<T>[8];
            Count = 0;
        }

        public bool Contains(T value)
        {
            int index = Math.Abs(value.GetHashCode() % items.Length);

            return items[index].IndexOf(value) != -1;
        }

        public bool Remove(T value)
        {
            int index = Math.Abs(value.GetHashCode() % items.Length);
            modCount++;
            return items[index].Remove(value);
        }

        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Индекс находится вне границ массива");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException("Недостаточно места в массиве");
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    continue;
                }

                items[i].CopyTo(array, index);
                index += items[i].Count;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int temp = modCount;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < items[i].Count; j++)
                {

                    if (modCount != temp)
                    {
                        throw new InvalidOperationException("Список менялся за время обхода");
                    }

                    yield return items[i].ElementAt(j);
                }
            }
        }

        public bool IsReadOnly => false;
    }
}
