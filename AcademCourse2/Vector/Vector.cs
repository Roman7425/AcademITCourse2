using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        public int N { get; set; }
        public double [] Array;

        public Vector(int n)
        {
            double [] Vector = new double [n];
        }

        public Vector( Vector vectorCopy)
        {
            
        }
    }
}
