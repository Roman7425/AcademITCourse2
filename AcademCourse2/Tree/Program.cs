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
            Node<int> node = new Node<int>(15);
            Node<int> node1 = new Node<int>(100);

            Console.WriteLine(node.CompareTo(node1));

            Console.ReadLine();
        }
    }
}
