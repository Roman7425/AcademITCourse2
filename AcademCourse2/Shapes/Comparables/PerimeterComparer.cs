using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Shapes;

namespace Shapes.Comparables
{
    class PerimeterComparer<T> : IComparer<T> where T : IShape
    {
        public int Compare(T x, T y)
        {
            return x.GetPerimeter().CompareTo(y.GetPerimeter());
        }
    }
}
