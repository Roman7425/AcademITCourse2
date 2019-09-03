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
            var people = new List<Person>()
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

            // Пункт а
            var uniqueNames = people
                .Select(x => x.Name)
                .Distinct()
                .ToList();

            // Пункт б
            var stringUniqueName = "Names: " + string.Join(", ", uniqueNames);
            Console.WriteLine(stringUniqueName);

            // Пункт в
            var youngest18 = people
                .Where(x => x.Age < 18)
                .ToList();
            var averageAge = youngest18
                .Average(x => x.Age);
            Console.WriteLine(averageAge);

            // Пункт г
            var group = people
                .GroupBy(x => x.Name)
                .ToDictionary(z => z.Key, z => z.Average(a => a.Age));

            foreach (var pair in group)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }

            // Пункт д
            var oldest20Youngest45 = people
                .Where(x => x.Age >= 20 && x.Age <= 45);
            var namesOldest20Youngest45 = string.Join(", ", oldest20Youngest45
                .OrderByDescending(x => x.Age)
                .Select(x => x.Name));
            Console.WriteLine(namesOldest20Youngest45);

            //Задача 2
            Console.WriteLine("Введите нужное количество числел: ");
            var countSqrt = Convert.ToInt32(Console.ReadLine());
            foreach (var sqrt in GetSqrt().Take(countSqrt))
            {
                Console.WriteLine(sqrt);
            }

            Console.WriteLine("Введите нужное количество числел: ");
            var countFibonacci = Convert.ToInt32(Console.ReadLine());
            foreach (var sqrt in GetFibonacciNumber().Take(countFibonacci))
            {
                Console.WriteLine(sqrt);
            }

            Console.ReadKey();
        }

        public static IEnumerable<double> GetSqrt()
        {
            var i = 1;
            while (true)
            {
                yield return Math.Sqrt(i);
                i++;
            }
        }

        public static IEnumerable<int> GetFibonacciNumber()
        {
            var i = 0;
            var j = 1;
            yield return 0;
            yield return 1;
            while (true)
            {
                var temp = j;
                j += i;
                i = temp;
                yield return j;
            }
        }
    }
}
