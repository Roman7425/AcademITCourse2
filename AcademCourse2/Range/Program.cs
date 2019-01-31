using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range firstRange = new Range(2, 9);
            Range secondRange = new Range(4, 8);

            double result1 = firstRange.GetLength();
            bool result2 = firstRange.IsInside(6);
            Console.WriteLine($"Length firstRange = {result1}");
            Console.WriteLine($"6 IsInside firstRange ?  -  {result2}");

            Range result = secondRange.GetIntersection(firstRange);
            Console.WriteLine($"Пересечение - {result.From} , {result.To}");

            Range[] array = firstRange.GetUnion(secondRange);
            Console.WriteLine($"Union - {array[0].From} , {array[0].To}");

            Range[] array1 = firstRange.GetExcept(secondRange);
            Console.WriteLine($"Except - {array1[0].From} , {array1[0].To}");
            Console.WriteLine($"Except - {array1[1].From} , {array1[1].To}");

            Console.ReadKey();
        }
    }
}
