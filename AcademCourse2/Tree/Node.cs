using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tree
{
    class Node<T> : IComparable<Node<T>>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        public int CompareTo(Node<T> node)
        {
            //Реализовать сравнение по полю Data
        }
    }
}
