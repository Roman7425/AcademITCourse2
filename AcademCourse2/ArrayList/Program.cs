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
            try
            {
                int? value = null;
                object reference = value;
                int? twin = (int?)reference;

                value.GetHashCode();
                System.Console.Write("step 1");

                twin.GetHashCode();
                System.Console.Write("; step 2");

                reference.GetHashCode();
                System.Console.Write("; step 3");
            }
            catch (System.Exception)
            {
                System.Console.Write("; exception");
            }


            Console.ReadKey();
        }
    }
}
