using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShapes> shapes = new List<IShapes>();
            shapes.Add(new Square(5));
            shapes.Add(new Rectangle(5, 10));
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(1, 1, 11, 1, 11, 11));
            shapes.Add(new Square(6));
            shapes.Add(new Rectangle(7, 4));
            shapes.Add(new Circle(9));
            shapes.Add(new Triangle(2, 6, 0, 0, 5, 11));
            Console.ReadKey();
        }

        public static IShapes GetMaxArrayShapes(List<IShapes> shapes)
        {
            MaxAreaShape<IShapes> maxAreaShape = new MaxAreaShape<IShapes>();
            shapes.Sort(maxAreaShape);
            return shapes[shapes.Count() - 1];
        }

        public static IShapes GetSecondMaxPerimeterShapes(List<IShapes> shapes)
        {
            SecondMaxPerimeterShape<IShapes> secondMaxPerimeterShape = new SecondMaxPerimeterShape<IShapes>();
            shapes.Sort(secondMaxPerimeterShape);
            return shapes[shapes.Count() - 2];
        }
    }
}
