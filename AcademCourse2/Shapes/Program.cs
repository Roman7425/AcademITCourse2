using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Comparables;
using Shapes.Shapes;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Square(5));
            shapes.Add(new Rectangle(5, 10));
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(1, 1, 11, 1, 11, 11));
            shapes.Add(new Square(6));
            shapes.Add(new Rectangle(7, 4));
            shapes.Add(new Circle(9));
            shapes.Add(new Triangle(2, 6, 0, 0, 5, 11));

            Console.WriteLine(GetMaxArrayShapes(shapes));
            Console.WriteLine(GetSecondMaxPerimeterShapes(shapes));
            Console.ReadKey();
        }

        public static IShape GetMaxArrayShapes(List<IShape> shapes)
        {
            AreaComparer<IShape> maxAreaShape = new AreaComparer<IShape>();
            shapes.Sort(maxAreaShape);
            return shapes[shapes.Count - 1];
        }

        public static IShape GetSecondMaxPerimeterShapes(List<IShape> shapes)
        {
            PerimeterComparer<IShape> secondMaxPerimeterShape = new PerimeterComparer<IShape>();
            shapes.Sort(secondMaxPerimeterShape);
            return shapes[shapes.Count - 2];
        }
    }
}
