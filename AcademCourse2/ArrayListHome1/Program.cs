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
            List<string> list = InputList("file1.txt");

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            // Задание 2
            Console.WriteLine();
            Console.WriteLine("Задание 2");
            List<int> list1 = new List<int> { 1, 2, 2, 4, 6, 3, 2, 8, 3, 5, 10, 9, 7, 6, 4 };

            DeleteEvenNumbers(list1);

            foreach (int number in list1)
            {
                Console.WriteLine(number);
            }

            // Задание 3
            Console.WriteLine();
            Console.WriteLine("Задание 3");

            List<int> list2 = new List<int> { 10, 2, 3, 4, 3, 2, 5, 6, 7, 10, 2, 3, 3, 8, 9, 12 };

            List<int> list3 = DeleteRepeat(list2);

            foreach (int number in list3)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }

        static List<string> InputList(string file)
        {
            List<string> result = new List<string>();

            try
            {
                using (StreamReader streamReader = new StreamReader(file))
                {
                    string s = streamReader.ReadLine();
                    while (s != null)
                    {
                        result.Add(s);
                        s = streamReader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }

            return result;
        }

        static void DeleteEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static List<int> DeleteRepeat(List<int> list)
        {
            List<int> result = new List<int>();

            foreach (int number in list)
            {
                if (!result.Contains(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
