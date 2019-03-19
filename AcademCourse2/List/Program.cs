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

            //number.AddOnIndex(0,1);
            //Console.WriteLine(number);
            //Console.WriteLine(number.Count);


            SinglyList<string> name = new SinglyList<string>();
            name.Add("Roma");
            name.Add(null);
            name.Add("Roma");
            name.AddTop(null);

            SinglyList<string> nameClone = new SinglyList<string>(name);

            Console.WriteLine(name);
            Console.WriteLine(nameClone);

            nameClone.DeleteFirstNode();
            Console.WriteLine(nameClone);
            Console.WriteLine(name);
            Console.ReadLine();
        }
    }
}
