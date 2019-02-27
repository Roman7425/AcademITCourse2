using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyList<T>
    {
        public Note<T> Head { get; set; }
        private int count;

        public SinglyList(Note<T> head)
        {
            Head = head;
        }

        public int GetCount()
        {
            for (Note<T> p = Head; p != null; p = p.Next)
            {
                count++;
            }
            return count;
        }    
    }
}
