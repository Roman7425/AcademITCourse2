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
            Tree<int> tree = new Tree<int>(20);
            tree.Add(16);
            tree.Add(31);
            tree.Add(46);
            tree.Add(19);
            tree.Add(43);
            tree.Add(29);
            tree.Add(44);
            tree.Add(15);

            Console.WriteLine(tree.WideBypass());

            tree.VisitR(tree.Top);
            Console.WriteLine();
            Console.WriteLine(tree.Visit());

            Tree<string> treeStr = new Tree<string>("Roman");
            treeStr.Add("Stas");
            treeStr.Add("Stasik");
            treeStr.Add("Andry");
            treeStr.Add("Alena");
            treeStr.Add("Nuts");
            treeStr.Add("dayana");
            treeStr.Add(null);
            treeStr.Add("Bob");

            Console.WriteLine(treeStr.WideBypass());

            treeStr.VisitR(treeStr.Top);
            Console.WriteLine();
            Console.WriteLine(treeStr.Visit());


            Console.ReadLine();
        }
    }
}
