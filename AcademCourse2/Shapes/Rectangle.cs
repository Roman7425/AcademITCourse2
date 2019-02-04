using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : IShapes
    {
        public double FirstSideLength { get; set; }
        public double SecondSideLength { get; set; }

        public Rectangle(double firstSideLength, double secondSideLength)
        {
            FirstSideLength = firstSideLength;
            SecondSideLength = secondSideLength;
        }

        public double GetWidth()
        {
            return FirstSideLength;
        }

        public double GetHeight()
        {
            return SecondSideLength;
        }

        public double GetArea()
        {
            return FirstSideLength * SecondSideLength;
        }

        public double GetPerimeter()
        {
            return (FirstSideLength + SecondSideLength) * 2;
        }

        public override string ToString()
        {
            return $"Тип - прямоугольник, Длинна первой стороны = {FirstSideLength}, Длинна второй стороны = {SecondSideLength}," +
                $" Периметр = {GetPerimeter()}, Площадь = {GetArea()}";
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

            Rectangle rectangle = (Rectangle)obj;
            return FirstSideLength == rectangle.FirstSideLength && SecondSideLength == rectangle.SecondSideLength;
        }

        public override int GetHashCode()
        {
            int prime = 36;
            int hash = 1;
            hash = prime * hash + FirstSideLength.GetHashCode();
            hash = prime * hash + SecondSideLength.GetHashCode();
            return hash;
        }
    }
}
