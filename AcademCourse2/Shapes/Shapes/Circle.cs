using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Тип - окружность, Радиус = {Radius} Периметр = {GetPerimeter()}, Площадь = {GetArea()}";
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

            Circle circle = (Circle)obj;
            return Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}
