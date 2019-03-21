using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {

            SinglyList<int> number = new SinglyList<int>();
            number.Add(5);
            number.Add(6);
            number.Add(3);
            number.Add(1);

            SinglyList<int> number1 = new SinglyList<int>(number);

            //Console.WriteLine(number.DeleteNode(3));
            //Console.WriteLine(number);
            //Console.WriteLine(number.Count);
            //Console.WriteLine(number.DeleteNode(2));
            //Console.WriteLine(number);
            //Console.WriteLine(number.Count);


            SinglyList<string> name = new SinglyList<string>();
            name.Add("Roma");
            name.Add(null);
            name.Add("Roma");
            name.Add("Stat");

            Console.WriteLine(name.DeleteNode(0));
            Console.WriteLine(name);
            Console.WriteLine(name.Count);
            Console.WriteLine(name.GetFirstValue());
            //Console.WriteLine(name.DeleteNode(2));
            //Console.WriteLine(name);
            //Console.WriteLine(name.Count);
            Console.ReadLine();
        }
    }
}
