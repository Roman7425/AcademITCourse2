using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 1
            List<Person> people = new List<Person>()
            {
                new Person("Andry", 19),
                new Person("Roman", 24),
                new Person("Klim", 14),
                new Person("Paha", 22),
                new Person("Egor",17),
                new Person("Vasya",49),
                new Person("Andry",19),
                new Person("Andry",23),
                new Person("Inna",24),
                new Person("Dayana",24),
                new Person("Dayana",19),
                new Person("Olesya",16)
            };

            List<string> uniqueName = people.Select(x => x.GetName()).Distinct().ToList();

            string stringUniqueName = "Names: " + string.Join(", ", people.Select(x => x.GetName()));
            Console.WriteLine(stringUniqueName);

            List<Person> youngest18 = people.Where(x => x.GetAge() < 18).ToList();
            int averageAge = (int)youngest18.Average(x => x.GetAge());
            Console.WriteLine(averageAge);

            var group = people.GroupBy(x => x.GetAge(), x => x.GetName());

            var oldest20Youngest45 = people.Where(x => x.GetAge() > 20 && x.GetAge() < 45);
            string namesOldest20Youngest45 = string.Join(", ", oldest20Youngest45.OrderByDescending(x => x.GetAge()).Select(x => x.GetName()));
            Console.WriteLine(namesOldest20Youngest45);

            //Задача 2
            Console.WriteLine("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            foreach (double sqrt in GetSqrt(number))
            {
                Console.WriteLine(sqrt);
            }

            Console.WriteLine("Введите число: ");
            int numberFibonacci = Convert.ToInt32(Console.ReadLine());
            foreach (double sqrt in GetFibonacciNumber(numberFibonacci))
            {
                Console.WriteLine(sqrt);
            }

            Console.ReadKey();
        }

        public static IEnumerable<double> GetSqrt(int a)
        {
            int i = 1;
            while (i <= a)
            {
                yield return Math.Sqrt(i);
                i++;
            }
        }

        public static IEnumerable<int> GetFibonacciNumber(int a)
        {
            int i = 0;
            int j = 1;
            int temp;
            while (j < a)
            {
                temp = j;
                j = j + i;
                i = temp;
                yield return j;
            }
        }
    }
}
