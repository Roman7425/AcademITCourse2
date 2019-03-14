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
        { }

        public SinglyList(Note<T> head)
        {
            Head = head;
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                notesCount++;
            }
        }

        public SinglyList(SinglyList<T> list)
        {
            for (Note<T> p = list.Head; p != null; p = p.Next)
            {
                Add(p.Data);
            }
        }

        public int GetCount()
        {
            return notesCount;
        }

        public T GetFirstValue()
        {
            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= GetCount())
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

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

        public T SetValue(T value, int index)
        {
            if (index < 0 || index >= GetCount())
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

            T temp = Head.Data;
            int i = 0;
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                if (i == index)
                {
                    temp = p.Data;
                    p.Data = value;
                }
                i++;
            }
            return temp;
        }

        public T DeleteNote(int index)
        {
            if (index < 0 || index >= GetCount())
            {
                throw new IndexOutOfRangeException("Нет узла под таким индексом!");
            }

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

        public void Add(T value)
        {
            for (Note<T> p = Head; ; p = p.Next)
            {
                if (Head == null)
                {
                    Note<T> newHead = new Note<T>(value);
                    Head = newHead;
                    break;
                }
                else if (p.Next == null)
                {
                    p.Next = new Note<T>(value);
                    break;
                }
            }
            notesCount++;
        }

        public void AddToTheTop(T value)
        {
            Note<T> newNote = new Note<T>(value);
            newNote.Next = Head;
            Head = newNote;
            notesCount++;
        }

        public void AddOnIndex(T value, int index)
        {
            if (index < 0 || index > GetCount())
            {
                throw new IndexOutOfRangeException("Индекс не должен превышать количество элементов или быть < 0");
            }

            if (index == 0)
            {
                AddToTheTop(value);
            }
            else
            {
                int i = 0;
                Note<T> newNote = new Note<T>(value);
                for (Note<T> p = Head; p != null; p = p.Next)
                {
                    if (i == index - 1)
                    {
                        newNote.Next = p.Next;
                        p.Next = newNote;
                        break;
                    }
                    i++;
                }
                notesCount++;
            }
        }

        public bool IndexOf(T value)
        {
            if (Head.Data.Equals(value))
            {
                Head = Head.Next;
                notesCount--;
                return true;
            }
            for (Note<T> p = Head; p.Next != null; p = p.Next)
            {
                if (p.Next.Data.Equals(value))
                {
                    p.Next = p.Next.Next;
                    notesCount--;
                    return true;
                }
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
            notesCount--;
            return term;
        }

        public void Turn()
        {
            Note<T> note = Head;
            Note<T> previous = null;

            while (note != null)
            {
                Note<T> temp = note.Next;
                note.Next = previous;
                previous = note;
                Head = note;
                note = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                sb.Append(p.Data);
                if (p.Next != null)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
