using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;

            X2 = x2;
            Y2 = y2;

            X3 = x3;
            Y3 = y3;
        }

        private static double GetMax(double x1, double x2, double x3)
        {
            return Math.Max(x1, Math.Max(x2, x3));
        }

        private static double GetMin(double x1, double x2, double x3)
        {
            return Math.Min(x1, Math.Min(x2, x3));
        }

        public double GetWidth()
        {
            return GetMax(X1, X2, X3) - GetMin(X1, X2, X3);
        }

        public double GetHeight()
        {
            return GetMax(Y1, Y2, Y3) - GetMin(Y1, Y2, Y3);
        }

        private static double GetSizeLength(double X1, double Y1, double X2, double Y2)
        {
            return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        }

        public double GetArea()
        {
            double lengthAB = GetSizeLength(X1, Y1, X2, Y2);
            double lengthAC = GetSizeLength(X1, Y1, X3, Y3);
            double lengthBC = GetSizeLength(X2, Y2, X3, Y3);
            double halfPerimeter = (lengthAB + lengthAC + lengthBC) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - lengthAB) * (halfPerimeter - lengthAC) * (halfPerimeter - lengthBC));
        }

        public double GetPerimeter()
        {
            double lengthAB = GetSizeLength(X1, Y1, X2, Y2);
            double lengthAC = GetSizeLength(X1, Y1, X3, Y3);
            double lengthBC = GetSizeLength(X2, Y2, X3, Y3);

            return lengthAB + lengthAC + lengthBC;
        }

        public override string ToString()
        {
            return $"Тип - треугольник, Координаты точек - т1 ={X1},{Y1} , т2 ={X2},{Y2} , т3 ={X3},{Y3} ," +
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

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3
                && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();
            return hash;
        }
    }
}
