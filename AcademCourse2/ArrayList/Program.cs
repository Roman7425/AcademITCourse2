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

            int[] array = new int[8];

            number.CopyTo(array,0);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.ReadKey();
        }
    }
}
