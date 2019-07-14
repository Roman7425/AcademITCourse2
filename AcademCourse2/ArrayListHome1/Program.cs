using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArrayListHome1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Задание 1");
            List<string> list = InputList("file.txt");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            // Задание 2
            Console.WriteLine();
            Console.WriteLine("Задание 2");
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);
            list1.Add(7);
            list1.Add(8);
            list1.Add(9);
            list1.Add(10);

            DeleteEvenNumbers(list1);

            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine(list1[i]);
            }

            // Задание 3
            Console.WriteLine();
            Console.WriteLine("Задание 3");

            List<int> list2 = new List<int>();
            list2.Add(10);
            list2.Add(2);
            list2.Add(1);
            list2.Add(3);
            list2.Add(3);
            list2.Add(2);
            list2.Add(5);
            list2.Add(6);
            list2.Add(5);
            list2.Add(10);

            List<int> list3 = NoRepeat(list2);

            for (int i = 0; i < list3.Count; i++)
            {
                Console.WriteLine(list3[i]);
            }

            Console.ReadLine();
        }

        static List<string> InputList(string file)
        {
            List<string> result = new List<string> ();
            using (StreamReader sr = new StreamReader(file))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    result.Add(s);
                    s = sr.ReadLine();
                }
            }

            return result;
        }

        static void DeleteEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                }
            }
        }

        static List<int> NoRepeat(List<int> list)
        {
            List<int> result = new List<int>();
            result.Add(list[0]);

            bool hasValue = false;
            for (int i = 1; i < list.Count; i++)
            {
                for(int j = 0; j < result.Count; j++)
                {
                    if(list[i] == result[j])
                    {
                        hasValue = true;
                        break;
                    }
                }

                if (!hasValue)
                {
                    result.Add(list[i]);
                }
                else
                {
                    hasValue = false;
                }
            }

            return result;
        }
    }
}
