using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree1
{
    class Tree<T>
    {
        private Node<T> Root;
        public int Count { get; private set; }
        private IComparer<T> comparer;

        public Tree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public Tree()
        {

        }

        public Tree(T value)
        {
            Root = new Node<T>(value);
            Count++;
        }

        private int CompareNodes(T x, T y)
        {
            if (comparer == null)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                else if (x == null)
                {
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
                else
                {
                    IComparable<T> x1 = (IComparable<T>)x;

                    return x1.CompareTo(y);
                }
            }
            return comparer.Compare(x, y);
        }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                Count++;
                return;
            }

            Node<T> current = Root;
            bool hasAdd = false;

            while (!hasAdd)
            {
                if (CompareNodes(current.Data, value) <= 0)
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
            Count++;
        }

        public bool Contains(T value)
        {
            if (Root == null)
            {
                return false;
            }

            Node<T> current = Root;

            while (current != null)
            {
                int compare = CompareNodes(current.Data, value);

                if (compare < 0)
                {
                    current = current.Right;
                }
                else if (compare > 0)
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

        private Node<T> FindParent(T value)
        {
            Node<T> current = Root;
            Node<T> parent = null;
            Node<T> childNode = new Node<T>(value);

            if (CompareNodes(Root.Data, childNode.Data) == 0)
            {
                current = Root.Right;
                parent = Root;
            }

            while (current != null)
            {
                int result = CompareNodes(current.Data, childNode.Data);

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
            if (Root == null)
            {
                return false;
            }
            else if (CompareNodes(Root.Data, value) == 0)
            {
                if (Root.Left == null && Root.Right == null)
                {
                    Root = null;
                }
                else if (Root.Left != null && Root.Right == null)
                {
                    Root = Root.Left;
                }
                else if (Root.Left == null && Root.Right != null)
                {
                    Root = Root.Right;
                }
                else
                {
                    Node<T> minLeft = Root.Right;

                    while (minLeft.Left != null)
                    {
                        minLeft = minLeft.Left;
                    }

                    Node<T> newNode = new Node<T>(minLeft.Data, Root.Left, Root.Right);
                    Root = newNode;
                    if (Root.Right == minLeft)
                    {
                        Root.Right = Root.Right.Right;
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

                Node<T> parent = FindParent(value);
                Node<T> deleteNode = null;

                int leftOrRight = CompareNodes(parent.Data, value);
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

        public void WideBypass(Action<T> action)
        {
            if (Count == 0)
            {
                return;
            }

            Queue<Node<T>> q = new Queue<Node<T>>();

            q.Enqueue(Root);
            while (q.Count != 0)
            {
                Node<T> current = q.Dequeue();

                action(current.Data);

                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
        }

        public void Visit(Action<T> action)
        {
            if (Count == 0)
            {
                return;
            }

            Stack<Node<T>> s = new Stack<Node<T>>();

            s.Push(Root);

            while (s.Count != 0)
            {
                Node<T> current = s.Pop();

                action(current.Data);

                if (current.Right != null)
                {
                    s.Push(current.Right);
                }
                if (current.Left != null)
                {
                    s.Push(current.Left);
                }
            }
        }

        public void VisitRecursion(Action<T> action)
        {
            if (Count == 0)
            {
                return;
            }

            VisitRecursionHelp(Root, action);
        }

        static private void VisitRecursionHelp(Node<T> node, Action<T> action)
        {
            action(node.Data);

            if (node.Left != null)
            {
                VisitRecursionHelp(node.Left, action);
            }
            if (node.Right != null)
            {
                VisitRecursionHelp(node.Right, action);
            }
        }
    }
}
