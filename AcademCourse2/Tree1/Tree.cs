using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// комментарий1
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

            if (CompareNodes(Root.Data, value) == 0)
            {
                return null;
            }

            while (current != null)
            {
                int result = CompareNodes(current.Data, value);

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

            if (!Contains(value))
            {
                return false;
            }

            Node<T> parent = FindParent(value);
            Node<T> deleteNode = null;

            bool isRoot = parent == null ? true : false;
            bool isLeft = true;

            if (!isRoot)
            {
                isLeft = CompareNodes(parent.Data, value) > 0 ? true : false;

                if (isLeft)
                {
                    deleteNode = parent.Left;
                }
                else
                {
                    deleteNode = parent.Right;
                }
            }
            else
            {
                deleteNode = Root;
            }


            if (deleteNode.Right == null && deleteNode.Left == null)
            {
                if (isRoot)
                {
                    Root = null;
                }
                else
                {
                    if (isLeft)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
            }
            else if (deleteNode.Right == null && deleteNode.Left != null)
            {
                if (isRoot)
                {
                    Root = Root.Left;
                }
                else
                {
                    if (isLeft)
                    {
                        parent.Left = parent.Left.Left;
                    }
                    else
                    {
                        parent.Right = parent.Right.Left;
                    }
                }
            }
            else if (deleteNode.Right != null && deleteNode.Left == null)
            {
                if (isRoot)
                {
                    Root = Root.Right;
                }
                else
                {
                    if (isLeft)
                    {
                        parent.Left = parent.Left.Right;
                    }
                    else
                    {
                        parent.Right = parent.Right.Right;
                    }
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

                if (isRoot)
                {
                    Root = newNode;
                }
                else
                {
                    if (isLeft)
                    {
                        parent.Left = newNode;
                    }
                    else
                    {
                        parent.Right = newNode;
                    }
                }
            }
            Count--;
            return true;
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

        private static void VisitRecursionHelp(Node<T> node, Action<T> action)
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
