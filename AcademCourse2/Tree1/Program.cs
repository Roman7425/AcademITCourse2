using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tree<int> tree = new Tree<int>();
            //tree.Add(5);
            //tree.Add(1);
            //tree.Add(9);
            //tree.Add(2);
            //tree.Add(6);
            //tree.Add(10);
            //tree.Add(-6);
            //tree.Add(16);
            //tree.Add(0);
            //tree.Add(-1);
            //tree.Add(15);

            //Tree<int> tree1 = new Tree<int>();
            //tree1.Add(10);
            //tree1.Add(0);
            //tree1.Add(20);
            //tree1.Add(-5);
            //tree1.Add(9);
            //tree1.Add(15);
            //tree1.Add(25);
            //tree1.Add(-3);
            //tree1.Add(-1);
            //tree1.Add(7);
            //tree1.Add(13);
            //tree1.Add(17);
            //tree1.Add(22);
            //tree1.Add(30);

            //Action<int> a;
            //a = ToString;

            //tree1.WideBypass(a);

            //Console.WriteLine();

            //tree1.Visit(a);

            //Console.WriteLine(tree.Contains(0));
            //tree1.VisitRecursion(a);

            Tree<string> str = new Tree<string>();
            str.Add("Roma");
            str.Add("Romanus");
            str.Add(null);
            str.Add("nic");
            str.Add("stas");
            str.Add(null);

            Tree<int> tree1 = new Tree<int>();
            tree1.Add(10);
            tree1.Add(10);
            tree1.Add(20);
            tree1.Add(-5);
            tree1.Add(9);
            tree1.Add(15);
            tree1.Add(25);
            tree1.Add(-3);
            tree1.Add(-1);
            tree1.Add(7);
            tree1.Add(13);
            tree1.Add(17);
            tree1.Add(22);
            tree1.Add(30);

            Action<string> a;
            a = ToStrings;


            Console.ReadKey();
        }

        static public void ToString(int a)
        {
            Console.WriteLine(a);
        }

        static public void ToStrings(string a)
        {
            Console.WriteLine(a);
        }
    }
}
