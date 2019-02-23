using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGubkin;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] array = new double[,] { {1,2 },{1,2 },{1,2 },{1,2 } };
            double[] array1 = new double [] {1, 2, 3 ,4};
            double[] array2 = new double[] { 12, 22, 33, 2 };
            double[] array3 = new double[] { -5,72, 43, 4 };
            double[] array4 = new double[] { 12, 2, 33, 4, };
            //double[] array5 = new double[] { 1, 21, 3, 42, 5, 1 };
            //double[] array6 = new double[] { 12, 2, 34, 4, 51, 5 };
            //double[] array2 = new double[] { 1, 2, 3 };
            Vector[] vectors = new Vector[] { new Vector(array1),new Vector(array2), new Vector(array3),
                new Vector(array4) };

            vectors[0].SetComponent(0,5);
            Console.WriteLine(vectors[0]);
            Matrix matrix = new Matrix(vectors);
            //Console.WriteLine(matrix.GetCountString());
            //Console.WriteLine(matrix.GetCountColumn());
            Console.WriteLine(matrix.GetDeterminator());

            //Console.WriteLine(matrix.GetColumn(5));
            //matrix.Transpose();
            //Console.WriteLine(matrix);
            //matrix.MultiplyByNumber(2);
            //Console.WriteLine(matrix);
            //Console.WriteLine(matrix.GetCountString());
            //Console.WriteLine(matrix.GetCountColumn());
            //Matrix matrix = new Matrix(vectors);
            //Console.WriteLine(matrix);
            //Matrix matrix1 = new Matrix(matrix);
            //Console.WriteLine(matrix1);
            //Matrix matrix0 = new Matrix(3,3);
            //Console.WriteLine(matrix0);


            //Console.WriteLine(array.Length / (array.GetUpperBound(0) + 1));
            //Console.WriteLine(array.Length);
            //Console.WriteLine(array.GetUpperBound(0) + 1);
            Console.ReadKey();
        }
    }
}
