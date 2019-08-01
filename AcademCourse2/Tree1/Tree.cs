using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree1
{
    class Tree<T>
    {
        private Node<T> Top;
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
            Top = new Node<T>(value);
            Count++;
        }

        private int CompareNodes(Node<T> x, Node<T> y)
        {
            if (comparer == null)
            {
                IComparable<T> x1 = (IComparable<T>)x.Data;
                //IComparable<T> y1 = (IComparable<T>)y.Data;

                return x1.CompareTo(y.Data);
            }
            else
            {
                return comparer.Compare(x.Data, y.Data);
            }
        }

        public void Add(T value)
        {
            if (Top == null)
            {
                Top = new Node<T>(value);
                Count++;
                return;
            }

            Node<T> current = Top;
            Node<T> newNode = new Node<T>(value);
            bool hasAdd = false;

            while (!hasAdd)
            {
                if (CompareNodes(current, newNode) < 1)
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
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
                        current.Left = newNode;
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

        public bool HasValue(T value)
        {
            if (Top == null)
            {
                return false;
            }

            Node<T> current = Top;

            int compare;
            Node<T> searchNode = new Node<T>(value);
            while (current != null)
            {
                compare = CompareNodes(current, searchNode);

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
            Node<T> current = Top;
            Node<T> parent = null;
            Node<T> childNode = new Node<T>(value);

            if (CompareNodes(Top, childNode) == 0)
            {
                current = Top.Right;
                parent = Top;
            }

            while (current != null)
            {
                int result = CompareNodes(current, childNode);

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
            else if (CompareNodes(Top, new Node<T>(value)) == 0)
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

                    int leftOrRight = CompareNodes(parent, new Node<T>(value));
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

        public void WideBypass(Action<T> action)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();

            q.Enqueue(Top);
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
            Stack<Node<T>> s = new Stack<Node<T>>();

            s.Push(Top);

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
            VisitRecursionHelp(Top, action);
        }

        private void VisitRecursionHelp(Node<T> node, Action<T> action)
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
