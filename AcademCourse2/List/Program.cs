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


            
            Console.WriteLine(number);
            number.Turn();
            SinglyList<int> numberClone = new SinglyList<int>(number);
            Console.WriteLine(numberClone);
            Console.WriteLine(numberClone.GetFirstValue());
            Console.WriteLine(numberClone.GetCount());
            Console.ReadLine();
        }
    }
}
