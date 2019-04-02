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
        private T[] items = new T[4];
        public int Count { get; private set; }

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

                T[] old = items;
                items = new T[value];
                Array.Copy(old, 0, items, 0, Count);
            }
        }

        public List()
        {
        }

        public List(int itemsLength)
        {
            items = new T[itemsLength];
        }

        public void Add(T value)
        {
            if (Count < Capacity)
            {
                items[Count] = value;
                Count++;
            }
            else
            {
                Capacity *= 2;
                items[Count] = value;
                Count++;
            }
        }

        public bool Contains(T value)
        {
            bool hasValue = false;
            for (int i = 0; i < Capacity; i++)
            {
                if (items[i].Equals(value))
                {
                    hasValue = true;
                }
            }
            return hasValue;
        }

        public int IndexOf(T value)
        {
            int index = -1;
            for (int i = 0; i < Capacity; i++)
            {
                if (items[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
            }

            if (Count < Capacity)
            {
                Count++;
                for (int i = Count - 1; i > index; i--)
                {
                    items[i] = items[i - 1];
                }

                items[index] = value;
            }
            else
            {
                Capacity *= 2;

                Count++;
                for (int i = Count - 1; i > index; i--)
                {
                    items[i] = items[i - 1];
                }

                items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
            }
            else
            {
                for (int i = index; i < Count; i++)
                {
                    items[i] = items[i + 1];
                }

                Count--;
            }
        }

        public bool Remove(T value)
        {
            bool wasRemove = false;
            int index = IndexOf(value);
            if (index != -1)
            {
                RemoveAt(index);
                wasRemove = true;
            }

            return wasRemove;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Индекс должен соответствовать индексам существующих элементов");
                }

                return items[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Индекс должен быть > 0 и меньше Count");
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
        }

        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Индекс находится вне границ массива");
            }

            int j = index;
            for (int i = 0; i < Count; i++)
            {
                if (j == array.Length)
                {
                    break;
                }
                array.SetValue(items[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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

        public bool IsReadOnly => throw new NotImplementedException();
    }
}
