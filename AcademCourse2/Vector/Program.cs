using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[] { 1, 2, 3, 4, 5, 6, 7 };
            double[] array1 = new double[] { 6, 9, 11, 13, 15, 17, 19, 20, 2 };

            Vector vector1 = new Vector(5);
            Vector vector2 = new Vector(array1);
            Vector vector3 = new Vector(7, array);
            Vector vector4 = new Vector(vector2);

            Console.WriteLine($"Размерность вектора2 = {vector2.GetSize()}");

            vector1.AddVector(vector3);
            Console.WriteLine($"Прибавление вектора1 к вектору3 = {vector1.ToString()}");

            vector1.SubtractVector(vector3);
            Console.WriteLine($"Вычитание вектора3 из измененного вектора1 = {vector1.ToString()}");

            vector4.MultiplyByNumber(5);
            Console.WriteLine($"Умножение вектора4 на скаляр 5 = {vector4.ToString()}");

            vector2.Turn();
            Console.WriteLine($"Разворот вектора = {vector2.ToString()}");

            Console.WriteLine($"Модуль измененного вектора3 = {vector3.GetLength()}");

            Console.WriteLine($"Компонент вектора4 под индексом - 3 = {vector4.GetComponent(3)}");

            Console.WriteLine($"Сложение вектора1 и вектора3 = {Vector.AddTwoVectors(vector1, vector3).ToString()}");

            Console.WriteLine($"Вычитание из вектора1 вектора3 = {Vector.SubtractTwoVectors(vector1, vector3).ToString()}");

            Console.WriteLine($"Скалярное произведение вектора3 и вектора4 = {Vector.GetScalarMultiplicationTwoVectors(vector3, vector4).ToString()}");

            Console.WriteLine($"Сравнивание вектора4 с вектором2 - {vector4.Equals(vector2)}");

            Console.ReadKey();
        }
    }
}
