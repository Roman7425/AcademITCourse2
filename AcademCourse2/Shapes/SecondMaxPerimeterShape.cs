using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class SecondMaxPerimeterShape<T> : IComparer<T>
        where T : IShapes
    {
        public int Compare(T x, T y)
        {
            if (x.GetPerimeter() < y.GetPerimeter())
            {
                return 1;
            }
            if (x.GetPerimeter() > y.GetPerimeter())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
