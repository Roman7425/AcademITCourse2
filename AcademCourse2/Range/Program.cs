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
            Range firstRange = new Range(2, 8);
            Range secondRange = new Range(5, 9);

            double result1 = firstRange.GetLength();
            bool result2 = firstRange.IsInside(6);
            Console.WriteLine($"Length firstRange = {result1}");
            Console.WriteLine($"6 IsInside firstRange ?  -  {result2}");

            Range result = Range.GetIntersection(firstRange, secondRange);
            Console.WriteLine($"Пересечение - {result.from} , {result.to}");

            Range[] array = Range.GetUnion(firstRange,secondRange);
            Console.WriteLine($"Union - {array[0].from} , {array[0].to}");

            Range[] array1 = Range.GetExcept(firstRange, secondRange);
            Console.WriteLine($"Except - {array1[0].from} , {array1[0].to}");

            Console.ReadKey();
        }
    }

    class Range
    {
        public double from { get; set; }
        public double to { get; set; }

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double GetLength()
        {
            return to - from;
        }

        public bool IsInside(double number)
        {
            return number >= from && number <= to;
        }

        public static Range GetIntersection(Range firstRange, Range secondRange)
        {
            if (firstRange.from <= secondRange.from && secondRange.to <= firstRange.to)
            {
                return new Range(secondRange.from, secondRange.to);
            }
            else if (secondRange.from <= firstRange.from && firstRange.to <= secondRange.to)
            {
                return new Range(firstRange.from, secondRange.to);
            }
            else if (firstRange.from <= secondRange.from && secondRange.from <= firstRange.to && firstRange.to <= secondRange.to)
            {
                return new Range(secondRange.from, firstRange.to);
            }
            else if (secondRange.from < firstRange.from && secondRange.to > firstRange.from && firstRange.to >= secondRange.to)
            {
                return new Range(firstRange.from, secondRange.to);
            }
            else
            {
                return null;
            }
        }

        public static Range [] GetUnion(Range firstRange, Range secondRange)
        {
            if (firstRange.from <= secondRange.from && firstRange.to >= secondRange.to)
            {
                return new Range[1] { firstRange };
            }
            else if (secondRange.from < firstRange.from && secondRange.to > firstRange.to)
            {
                return new Range[1] { secondRange };
            }
            else if (firstRange.from < secondRange.from && firstRange.to >= secondRange.from)
            {
                return new Range[1] { new Range(firstRange.from, secondRange.to) };
            }
            else if (secondRange.from < firstRange.from && secondRange.to >= firstRange.from)
            {
                return new Range[1] { new Range(secondRange.from, firstRange.to) };
            }
            else
            {
                return new Range[2] { firstRange, secondRange };
            }
        }

        public static Range[] GetExcept(Range firstRange, Range secondRange)
        {
            if (firstRange.to <= secondRange.from || secondRange.to <= firstRange.from)
            {
                return new Range[1] { firstRange };
            }
            else if (firstRange.from < secondRange.from && firstRange.to > secondRange.from && firstRange.to <= secondRange.to)
            {
                return new Range[1] { new Range(firstRange.from, secondRange.from) };
            }
            else if (secondRange.from <= firstRange.from && secondRange.to > firstRange.from && secondRange.to < firstRange.to)
            {
                return new Range[1] { new Range(secondRange.to, firstRange.to) };
            }
            else if (firstRange.from < secondRange.from && firstRange.to > secondRange.to)
            {
                return new Range[2] { new Range(firstRange.from, secondRange.from), new Range(secondRange.to, firstRange.to) };
            }
            else
            {
                return null;
            }
        }
    }
}
