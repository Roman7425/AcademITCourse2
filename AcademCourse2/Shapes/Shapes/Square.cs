using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public override string ToString()
        {
            return $"Тип - квадрат, Длинна стороны = {SideLength}, Периметр = {GetPerimeter()}, Площадь = {GetArea()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square square = (Square)obj;
            return SideLength == square.SideLength;
        }

        public override int GetHashCode()
        {
            return SideLength.GetHashCode();
        }
    }
}
