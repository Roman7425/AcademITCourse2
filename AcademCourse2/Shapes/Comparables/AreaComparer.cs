using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Shapes;

namespace Shapes.Comparables
{
    class AreaComparer<T> : IComparer<T> where T : IShape
    {
        public int Compare(T x, T y)
        {
            return x.GetArea().CompareTo(y.GetArea());
        }
    }
}
