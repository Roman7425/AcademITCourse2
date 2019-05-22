using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree<T>
    {
        private Node<T> Top { get; set; }
        public int Count { get; private set; }

        public Tree()
        {
        }

        public Tree(T value)
        {
            Top = new Node<T>(value);
        }

        //public void Add (T value)
        //{
        //    if(Top == null)
        //    {
        //        Top = new Node<T>(value);
        //    }
        //    else
        //    {
        //        Node<T> current = Top;
        //        bool hasAdd = false;

        //        while (!hasAdd)
        //        {
        //            if ()
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
