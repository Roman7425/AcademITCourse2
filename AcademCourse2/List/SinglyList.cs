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
        public int NodesCount { private set; get; }

        public SinglyList()
        { }

        public SinglyList(T value)
        {
            Head = new Node<T>(value);
            NodesCount++;
        }

        public SinglyList(SinglyList<T> list)
        {
            Head = list.Head;
            for (Node<T> p = list.Head.Next, d = Head.Next; p != null; p = p.Next, d = d.Next)
            {
                d = new Node<T>(p.Data);
            }
            NodesCount = list.NodesCount;
        }

        public T GetFirstValue()
        {
            if (NodesCount == 0)
            {
                throw new Exception("Список пустой.");
            }
            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= NodesCount)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            return GetNode(index).Data;
        }

        public T SetValue(T value, int index)
        {
            if (index < 0 || index >= NodesCount)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            T temp = GetNode(index).Data;
            GetNode(index).Data = value;
            return temp;
        }

        public T DeleteNote(int index)
        {
            if (index < 0 || index >= NodesCount)
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            T temp = GetNode(index).Data;
            if (index == 0)
            {
                Head = Head.Next;
            }
            else if (index == NodesCount - 1)
            {
                GetNode(index - 1).Next = null;
            }
            else
            {
                GetNode(index - 1).Next = GetNode(index).Next;
            }
            NodesCount--;
            return temp;
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
                GetNode(NodesCount - 1).Next = new Node<T>(value);
            }
            NodesCount++;
        }

        public void AddTop(T value)
        {
            Node<T> newNote = new Node<T>(value);
            newNote.Next = Head;
            Head = newNote;
            NodesCount++;
        }

        public void AddOnIndex(T value, int index)
        {
            if (index < 0 || index > NodesCount)
            {
                throw new IndexOutOfRangeException("Индекс не должен превышать количество элементов или быть < 0");
            }

            if (index == 0)
            {
                AddTop(value);
            }
            else if (index == NodesCount)
            {
                Add(value);
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Next = GetNode(index - 1).Next;
                GetNode(index - 1).Next = newNode;
                NodesCount++;
            }
        }

        public bool IndexOf(T value)
        {
            if (value == null && Head.Data == null)
            {
                Head = Head.Next;
                NodesCount--;
                return true;
            }
            if (Head.Data.Equals(value))
            {
                Head = Head.Next;
                NodesCount--;
                return true;
            }

            int i = 0;
            for (Node<T> p = Head; ; p = p.Next)
            {
                if (value == null && p.Next.Data == null)
                {
                    p.Next = p.Next.Next;
                    NodesCount--;
                    return true;
                }
                if (p.Next.Data.Equals(value))
                {
                    p.Next = p.Next.Next;
                    NodesCount--;
                    return true;
                }
                if (i == NodesCount - 1)
                {
                    break;
                }
                i++;
            }
            return false;
        }

        public T DeleteFirstNote()
        {
            if (Head == null)
            {
                throw new Exception("Нет первого элемнта");
            }

            T term = Head.Data;
            Head = Head.Next;
            NodesCount--;
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

                if (i != NodesCount - 1)
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
