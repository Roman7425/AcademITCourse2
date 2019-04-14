using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = new List<int>();

            number.Add(5);
            number.Add(6);
            number.Add(7);
            number.Add(8);

            Console.WriteLine(number);
            Console.WriteLine(number.Count);
            Console.WriteLine(number.Capacity);

            Console.WriteLine(number.Contains(5));
            Console.ReadKey();
        }
    }
}
