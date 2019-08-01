using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree1 = new Tree<int>();
            tree1.Add(10);
            tree1.Add(0);
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

            Console.WriteLine(tree1.WideBypass());

            Console.ReadLine();
        }
    }
}
