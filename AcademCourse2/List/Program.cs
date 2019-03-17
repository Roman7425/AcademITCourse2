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



            //Console.WriteLine(number);
            //number.AddOnIndex(9, 4);
            //number.Add(10);
            //Console.WriteLine(number);
            //Console.WriteLine(number.NodesCount);

            //Console.WriteLine(number.DeleteNote(1));
            //Console.WriteLine(number);
            //Console.WriteLine(number.NodesCount);

            SinglyList<string> name = new SinglyList<string>("Roma");
            //Console.WriteLine(name);
            name.Add(null);
            //Console.WriteLine(name);
            name.Add("Stas");
            name.AddTop(null);
            //Console.WriteLine(name);
            //Console.WriteLine(name.DeleteFirstNote());
            Console.WriteLine(name);

            SinglyList<string> nameClone = new SinglyList<string>(name);
            nameClone.Add("Andry");
            Console.WriteLine(nameClone);
            Console.WriteLine(nameClone.NodesCount);
            Console.WriteLine(nameClone.DeleteNote(0));

            Console.ReadLine();
        }
    }
}
