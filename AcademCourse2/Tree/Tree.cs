using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Top { get; set; }
        public int Count { get; private set; }

        public Tree()
        {
        }

        public Tree(T value)
        {
            Top = new Node<T>(value);
            Count++;
        }

        public void Add(T value)
        {
            if (Top == null)
            {
                Top = new Node<T>(value);
            }
            else
            {
                Node<T> current = Top;
                bool hasAdd = false;

                while (!hasAdd)
                {
                    if (current.CompareTo(value) < 1)
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node<T>(value);
                            hasAdd = true;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                    else
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node<T>(value);
                            hasAdd = true;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                }
            }
            Count++;
        }

        public bool HasValue(T value)
        {
            if (Top == null)
            {
                return false;
            }
            else
            {
                Node<T> current = Top;

                while (current != null)
                {
                    if (current.CompareTo(value) == -1)
                    {
                        current = current.Right;
                    }
                    else if (current.CompareTo(value) == 1)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private Node<T> FindParent(T value)
        {
            Node<T> current = Top;
            Node<T> parent = null;

            if (Top.CompareTo(value) == 0)
            {
                current = Top.Right;
                parent = Top;
            }

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    return parent;
                }
            }
            return null;
        }


        public bool Remove(T value)
        {
            if (Top == null)
            {
                return false;
            }
            else if (Top.CompareTo(value) == 0)
            {
                if (Top.Left == null && Top.Right == null)
                {
                    Top = null;
                }
                else if (Top.Left != null && Top.Right == null)
                {
                    Top = Top.Left;
                }
                else if (Top.Left == null && Top.Right != null)
                {
                    Top = Top.Right;
                }
                else
                {
                    Node<T> minLeft = Top.Right;

                    while (minLeft.Left != null)
                    {
                        minLeft = minLeft.Left;
                    }

                    Node<T> newNode = new Node<T>(minLeft.Data, Top.Left, Top.Right);
                    Top = newNode;
                    if (Top.Right == minLeft)
                    {
                        Top.Right = Top.Right.Right;
                    }
                    else if (minLeft.Right == null)
                    {
                        FindParent(minLeft.Data).Left = null;
                    }
                    else
                    {
                        FindParent(minLeft.Data).Left = FindParent(minLeft.Data).Left.Right;
                    }
                }
                Count--;
                return true;
            }
            else
            {
                if (FindParent(value) == null)
                {
                    return false;
                }
                else
                {
                    Node<T> parent = FindParent(value);
                    Node<T> deleteNode = null;

                    int leftOrRight = parent.CompareTo(value);
                    if (leftOrRight > 0)
                    {
                        deleteNode = parent.Left;
                    }
                    else
                    {
                        deleteNode = parent.Right;
                    }

                    if (deleteNode.Right == null && deleteNode.Left == null)
                    {
                        if (leftOrRight > 0)
                        {
                            parent.Left = null;
                        }
                        else
                        {
                            parent.Right = null;
                        }
                    }
                    else if (deleteNode.Right == null && deleteNode.Left != null)
                    {
                        if (leftOrRight > 0)
                        {
                            parent.Left = parent.Left.Left;
                        }
                        else
                        {
                            parent.Right = parent.Right.Left;
                        }
                    }
                    else if (deleteNode.Right != null && deleteNode.Left == null)
                    {
                        if (leftOrRight > 0)
                        {
                            parent.Left = parent.Left.Right;
                        }
                        else
                        {
                            parent.Right = parent.Right.Right;
                        }
                    }
                    else
                    {
                        Node<T> minLeft = deleteNode.Right;

                        while (minLeft.Left != null)
                        {
                            minLeft = minLeft.Left;
                        }

                        if (deleteNode.Right == minLeft)
                        {
                            deleteNode.Right = deleteNode.Right.Right;
                        }
                        else if (minLeft.Right == null)
                        {
                            Node<T> parentMinLeft = FindParent(minLeft.Data);
                            parentMinLeft.Left = null;
                        }
                        else
                        {
                            Node<T> parentMinLeft = FindParent(minLeft.Data);
                            parentMinLeft.Left = parentMinLeft.Left.Right;
                        }

                        Node<T> newNode = new Node<T>(minLeft.Data, deleteNode.Left, deleteNode.Right);

                        if (leftOrRight > 0)
                        {
                            parent.Left = newNode;
                        }
                        else
                        {
                            parent.Right = newNode;
                        }
                    }
                    Count--;
                    return true;
                }
            }
        }

        public string WideBypass()
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            StringBuilder sb = new StringBuilder();

            q.Enqueue(Top);
            while (q.Count != 0)
            {
                Node<T> current = q.Dequeue();
                if (current.Data == null)
                {
                    sb.Append("Null");
                }
                else
                {
                    sb.Append(current.Data);
                }
                sb.Append(" ");

                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
            return sb.ToString();
        }

        public void VisitR(Node<T> node)
        {
            if (node.Data == null)
            {
                Console.Write("Null ");
            }
            else
            {
                Console.Write(node.Data + " ");
            }

            if (node.Left != null)
            {
                VisitR(node.Left);
            }
            if (node.Right != null)
            {
                VisitR(node.Right);
            }
        }

        public string Visit()
        {
            Stack<Node<T>> s = new Stack<Node<T>>();
            StringBuilder sb = new StringBuilder();

            s.Push(Top);

            while (s.Count != 0)
            {
                Node<T> current = s.Pop();
                if (current.Data == null)
                {
                    sb.Append("Null");
                }
                else
                {
                    sb.Append(current.Data);
                }
                sb.Append(" ");

                if (current.Right != null)
                {
                    s.Push(current.Right);
                }
                if (current.Left != null)
                {
                    s.Push(current.Left);
                }
            }
            return sb.ToString();
        }
    }
}
