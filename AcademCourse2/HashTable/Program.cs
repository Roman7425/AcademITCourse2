using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> numbers = new HashTable<int>(4);

            numbers.Add(10);
            numbers.Add(9);
            numbers.Add(4);
            numbers.Add(0);
            numbers.Add(36);

            IEnumerator<int> enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext() != false)
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.ReadKey();

        }
    }
}
