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
        private List<T>[] items;
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

        private int GetIndex(T value)
        {
            if(value == null)
            {
                return 0;
            }

            return Math.Abs(value.GetHashCode() % items.Length);
        }

        public void Add(T value)
        {
            int index = GetIndex(value);

            if (items[index] == null)
            {
                items[index] = new List<T>();
            }

            items[index].Add(value);

            Count++;
            modCount++;
        }

        public void Clear()
        {
            items = new List<T>[8];
            Count = 0;
            modCount++;
        }

        public bool Contains(T value)
        {
            int index = GetIndex(value);

            return items[index].Contains(value);
        }

        public bool Remove(T value)
        {
            int index = Math.Abs(value.GetHashCode() % items.Length);
            modCount++;
            Count--;
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

            foreach (List<T> list in items)
            {
                if(list == null)
                {
                    continue;
                }

                list.CopyTo(array, index);
                index += list.Count;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int temp = modCount;
            foreach (List<T> list in items)
            {
                if (list == null)
                {
                    continue;
                }

                for (int j = 0; j < list.Count; j++)
                {
                    if (modCount != temp)
                    {
                        throw new InvalidOperationException("Список менялся за время обхода");
                    }

                    yield return list.ElementAt(j);
                }
            }
        }

        public bool IsReadOnly => false;
    }
}
