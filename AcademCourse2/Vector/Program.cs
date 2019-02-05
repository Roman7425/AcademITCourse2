using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int [ ] {1,2,3,4,5 };

            int [] arrayCopy = new int[] { };
            array[0] = 5;
            Console.WriteLine(arrayCopy[0]);
            Console.ReadKey();
        }
    }
}
