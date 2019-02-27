using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Note<T>
    {
        public T Data { get; set; }
        public Note<T> Next { get; set; }

        public Note(T data)
        {
            Data = data;
        }

        public Note (T data, Note<T> next)
        {
            Data = data;
            Next = next;
        }            
    }
}
