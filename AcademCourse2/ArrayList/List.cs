using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class List<T> : IList<T>
    {
        private T[] items;
        public int Count { get; private set; }
        private int modCount = 0;

        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Переданно значение меньше элементов списка");
                }

                if (value != Count)
                {
                    Array.Resize(ref items, value);
                }
            }
        }

        public List()
        {
            items = new T[4];
        }

        public List(int capacity)
        {
            items = new T[capacity];
        }

        public void Add(T value)
        {
            if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            items[Count] = value;
            Count++;
            modCount++;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) == -1 ? false : true;
        }

        public int IndexOf(T value)
        {

            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
            }

            if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            Array.Copy(items, index, items, index + 1, Count - index + 1);
            items[index] = value;

            Count++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            Count--;
            modCount++;
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
                }

                return items[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс должен быть > 0 и меньше Count");
                }

                items[index] = value;
            }
        }

        public void TrimToSize()
        {
            Capacity = Count;
        }

        public void Clear()
        {
            items = new T[4];
            Count = 0;
            modCount++;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Аргумент не должет быть null");
            }

            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Индекс находится вне границ массива");
            }

            if (items.Length > array.Length - index)
            {
                throw new ArgumentException("Недостаточно места в массиве");
            }

            int j = index;
            for (int i = 0; i < Count; i++)
            {
                array[j] = items[i];
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int temp = modCount;
            for (int i = 0; i < Count; i++)
            {
                if (modCount != temp)
                {
                    throw new InvalidOperationException("Список менялся за время обхода");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly => false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i]);
                if (i == Count - 1)
                {
                    break;
                }
                sb.Append(", ");
            }

            return sb.ToString();
        }

    }
}
