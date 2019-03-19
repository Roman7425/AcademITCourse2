using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyList<T>
    {
        private Node<T> Head { get; set; }
        public int Count { private set; get; }

        public SinglyList()
        { }

        public SinglyList(T value)
        {
            Head = new Node<T>(value);
            Count++;
        }

        public SinglyList(SinglyList<T> list)
        {
            Head = new Node<T>(list.Head.Data);
            Node<T> newNode = Head;
            Node<T> listNode = list.Head;
            while (listNode.Next != null)
            {
                listNode = listNode.Next;
                newNode.Next = new Node<T>(listNode.Data);
                newNode = newNode.Next;
            }
            Count = list.Count;
        }

        public T GetFirstValue()
        {
            if (Count == 0)
            {
                throw new Exception("Список пустой.");
            }
            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            return GetNode(index).Data;
        }

        public T SetValue(T value, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            Node<T> temp = GetNode(index);
            T valueTemp = temp.Data;
            temp.Data = value;
            return valueTemp;
        }

        public T DeleteNode(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            Node<T> temp = GetNode(index);
            T valueTemp = temp.Data;
            if (index == 0)
            {
                Head = Head.Next;
            }
            else if (index == Count - 1)
            {
                temp = null;
            }
            else
            {
                temp = temp.Next;
            }
            Count--;
            return valueTemp;
        }

        public void Add(T value)
        {
            if (Head == null)
            {
                Node<T> newHead = new Node<T>(value);
                Head = newHead;
            }
            else
            {
                GetNode(Count - 1).Next = new Node<T>(value);
            }
            Count++;
        }

        public void AddTop(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        public void AddOnIndex(T value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Индекс не должен превышать количество элементов или быть < 0");
            }

            if (index == 0)
            {
                AddTop(value);
            }
            else if (index == Count)
            {
                Add(value);
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                Node<T> previous = GetNode(index - 1);
                newNode.Next = previous.Next;
                previous.Next = newNode;
                Count++;
            }
        }

        public bool Remove(T value)
        {
            if (Count == 0)
            {
                return false;
            }
            if (Equals(value, Head.Data))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            int i = 0;
            for (Node<T> p = Head; ; p = p.Next)
            {
                if (Equals(value, p.Next.Data))
                {
                    p.Next = p.Next.Next;
                    Count--;
                    return true;
                }
                if (i == Count - 1)
                {
                    break;
                }
                i++;
            }
            return false;
        }

        public T DeleteFirstNode()
        {
            if (Head == null)
            {
                throw new Exception("Нет первого элемнта");
            }

            T term = Head.Data;
            Head = Head.Next;
            Count--;
            return term;
        }

        public void Turn()
        {
            Node<T> node = Head;
            Node<T> previous = null;

            while (node != null)
            {
                Node<T> temp = node.Next;
                node.Next = previous;
                previous = node;
                Head = node;
                node = temp;
            }
        }

        private Node<T> GetNode(int index)
        {
            int i = 0;
            for (Node<T> p = Head; ; p = p.Next)
            {
                if (i == index)
                {
                    return p;
                }
                i++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            int i = 0;
            for (Node<T> p = Head; ; p = p.Next)
            {
                if (p.Data == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(p.Data);
                }

                if (i != Count - 1)
                {
                    sb.Append(", ");
                }
                else
                {
                    break;
                }
                i++;
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
