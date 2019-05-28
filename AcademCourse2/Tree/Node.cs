using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tree
{
    class Node<T> : IComparable<T> where T : IComparable<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(T value)
        {
            if (Data == null && value == null)
            {
                return 0;
            }
            if (Data == null)
            {
                return -1;
            }
            if(value == null)
            {
                return 1;
            }
            return Data.CompareTo(value);
        }
    }
}
