using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{

    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (range.To <= From || To <= range.From)
            {
                return null;
            }
            else
            {
                return new Range(Math.Max(range.From, From), Math.Min(range.To, To));
            }
        }

        public Range[] GetUnion(Range range)
        {
            if (range.To < From || To < range.From)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }
            else
            {
                return new Range[] { new Range(Math.Min(range.From, From), Math.Max(range.To, To)) };
            }
        }

        public Range[] GetExcept(Range range)
        {
            if (To < range.From || range.To < From)
            {
                return new Range[] { new Range(From, To) };
            }
            else if (From >= range.From && To <= range.To)
            {
                return new Range[0];
            }
            else
            {
                if (To <= range.To)
                {
                    return new Range[] { new Range(From, range.From) };
                }
                else if (From >= range.From)
                {
                    return new Range[] { new Range(range.To, To) };
                }
                else
                {
                    return new Range[] { new Range(From, range.From), new Range(range.To, To) };
                }
            }
        }
    }
}
