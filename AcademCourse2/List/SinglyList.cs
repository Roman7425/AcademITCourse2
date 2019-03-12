using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyList<T>
    {
        private Note<T> Head { get; set; }
        private int notesCount = 0;

        public SinglyList()
        {
            
        }

        public SinglyList(Note<T> head)
        {
            Head = head;
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                notesCount++;
            }
        }

        public int GetCount()
        {
            return notesCount;
        }

        public T GetFirstElement()
        {
            return Head.Data;
        }

        public T GetElement(int index)
        {
            T result = Head.Data;
            int i = 0;
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                if (i == index)
                {
                    result = p.Data;
                }
                i++;
            }
            return result;
        }

        public T SetElement(T element, int index)
        {
            T temp = Head.Data;
            int i = 0;
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                if (i == index)
                {
                    temp = p.Data;
                    p.Data = element;
                }
                i++;
            }
            return temp;
        }

        public T DeleteNote(int index)
        {
            T temp = Head.Data;
            int i = 0;
            if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                for (Note<T> p = Head; p != null; p = p.Next)
                {
                    if (i == index - 1)
                    {
                        if (p.Next.Next == null)
                        {
                            temp = p.Next.Data;
                            p.Next = null;
                        }
                        else
                        {
                            temp = p.Next.Data;
                            p.Next = p.Next.Next;
                        }
                    }
                    i++;
                }
            }
            notesCount--;
            return temp;
        }

        public void Add(T element)
        {
            for (Note<T> p = Head; ; p = p.Next)
            {
                if (Head == null)
                {
                    Note<T> newHead = new Note<T>(element);
                    Head = newHead;
                    break;
                }
                else if (p.Next == null)
                {
                    p.Next = new Note<T>(element);
                    break;
                }
            }
            notesCount++;
        }

        public void AddToTheTop(T element)
        {
            Note<T> newNote = new Note<T>(element);
            newNote.Next = Head;
            Head = newNote;
            notesCount++;
        }

        public void AddToIndex(T element, int index)
        {

        }

        public override string ToString()
        {
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                Console.Write(p.Data + "  ");
            }
            return null;
        }
    }
}
