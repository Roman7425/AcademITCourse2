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
            number.Add(5);
            number.Add(6);

            Console.WriteLine(number.DeleteNote(3));
            Console.WriteLine(number);
            Console.WriteLine(number.GetCount());
            Console.ReadLine();
        }
    }
}
