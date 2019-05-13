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
            HashTable<string> words = new HashTable<string>();

            words.Add("Roma");
            words.Add("Stas");
            words.Add("Alena");
            words.Add(null);
            words.Add("Katya");

            string[] array = new string[5];


            Console.WriteLine(words.Remove("Jorsh"));

            Console.WriteLine(words);
            Console.ReadKey();
        }
    }
}
