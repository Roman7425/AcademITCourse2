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

        public Range GetIntersection(Range Range)
        {
            if (Range.To < From || To < Range.From)
            {
                return null;
            }
            else
            {
                return new Range(Math.Max(Range.From, From), Math.Min(Range.To, To));
            }
        }

        public Range[] GetUnion(Range Range)
        {
            if (Range.To < From || To < Range.From)
            {
                return new Range[] { new Range(Range.From, Range.To), new Range(From, To) };
            }
            else
            {
                return new Range[] { new Range(Math.Min(Range.From, From), Math.Max(Range.To, To)) };
            }
        }

        public Range[] GetExcept(Range Range)
        {
            if (To <= Range.From || Range.To <= From)
            {
                return new Range[] { new Range(From, To) };
            }
            else if (From < Range.From && To > Range.From && To <= Range.To)
            {
                return new Range[] { new Range(From, Range.From) };
            }
            else if (Range.From <= From && Range.To > From && Range.To < To)
            {
                return new Range[] { new Range(Range.To, To) };
            }
            else if (From < Range.From && To > Range.To)
            {
                return new Range[] { new Range(From, Range.From), new Range(Range.To, To) };
            }
            else
            {
                return new Range[0];
            }
        }
    }
}
