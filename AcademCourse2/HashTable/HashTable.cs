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
            if (value == null)
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

            if (items[index] == null)
            {
                return false;
            }

            return items[index].Contains(value);
        }

        public bool Remove(T value)
        {
            if (Contains(value))
            {
                int index = GetIndex(value);
                modCount++;
                Count--;
                return items[index].Remove(value);
            }

            return false;
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

            int i = 0;
            foreach (T value in this)
            {
                array[i] = value;
                i++;
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

                foreach (T data in list)
                {
                    if (modCount != temp)
                    {
                        throw new InvalidOperationException("Список менялся за время обхода");
                    }

                    yield return data;
                }
            }
        }

        public override string ToString()
        {
            int i = 0;
            IEnumerator<T> enumerator1 = GetEnumerator();
            while (i < Count)
            {
                enumerator1.MoveNext();
                Console.WriteLine(enumerator1.Current);
                i++;
            }
            return null;
        }

        public bool IsReadOnly => false;
    }
}
