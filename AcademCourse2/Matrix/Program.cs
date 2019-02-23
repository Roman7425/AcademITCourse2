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
            double[] array1 = new double[] { 1, 2, 1 };
            Vector vector1 = new Vector(array1);

            double[] array2 = new double[] { 0, 1, 2 };
            Vector vector2 = new Vector(array2);

            double[] array6 = new double[] { 0, 1, 23 };
            Vector vector6 = new Vector(array6);

            Vector[] vectors1 = new Vector[] { vector1, vector2 };

            double[] array3 = new double[] { 1, 0 };
            Vector vector3 = new Vector(array3);

            double[] array4 = new double[] { 0, 1 };
            Vector vector4 = new Vector(array4);

            double[] array5 = new double[] { 1, 1 };
            Vector vector5 = new Vector(array5);

            Vector[] vectors2 = new Vector[] { vector3, vector4, vector5 };

            Matrix matrix1 = new Matrix(vectors1);
            Matrix matrix2 = new Matrix(vectors2);

            Console.WriteLine(Matrix.Multiply(matrix2, matrix1));



            Vector[] vectors3 = new Vector[] { vector1, vector2, vector6 };
            Matrix matrix = new Matrix(vectors3);
            Console.WriteLine(matrix.GetDeterminator());
            Console.ReadKey();
        }
    }
}
