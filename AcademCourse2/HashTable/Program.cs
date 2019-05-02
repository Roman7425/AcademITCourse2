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
            //HashTable<int> numbers = new HashTable<int>(4);

            //numbers.Add(10);
            //numbers.Add(9);
            //numbers.Add(4);
            //numbers.Add(0);
            //numbers.Add(36);

            //IEnumerator<int> enumerator = numbers.GetEnumerator();
            //while (enumerator.MoveNext() != false)
            //{
            //    Console.WriteLine(enumerator.Current);
            //}

            //Console.WriteLine();

            HashTable<string> words = new HashTable<string>();

            words.Add("Roma");
            words.Add("Stas");
            words.Add("Alena");
            words.Add(null);
            words.Add("Katya");


            int i = 0;
            IEnumerator<string> enumerator1 = words.GetEnumerator();
            while (i < words.Count)
            {
                enumerator1.MoveNext();
                Console.WriteLine(enumerator1.Current);
                i++;
            }

            Console.ReadKey();
        }
    }
}
