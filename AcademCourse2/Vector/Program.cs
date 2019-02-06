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
            double[] array = new double[] { 1, 2, 3, 4, 5 };

            Vector vector1 = new Vector(5);
            Vector vector2 = new Vector(array);
            Vector vector3 = new Vector(7, array);
            Vector vector4 = new Vector(vector2);

            Console.WriteLine($"Размерность вектора2 = {vector2.GetSize()}");
            Console.WriteLine($"Прибавление вектора1 к вектору3 = {vector1.AddVector(vector3).ToString()}");
            Console.WriteLine($"Вычитание вектора3 из вектора1 = {vector1.ExceptVector(vector3).ToString()}");
            Console.WriteLine($"Умножение вектора4 на скаляр = {vector4.MultipliedByNumber(5).ToString()}");
            Console.WriteLine($"Разворот вектора = {vector2.TurnVector().ToString()}");
            Console.WriteLine($"Модуль вектора3 = {vector3.GetVectorsLength()}");
            Console.WriteLine($"Компонент вектора4 под индексом - 3 = {vector4.GetElement(3)}");
            Console.WriteLine($"Сложение вектора1 и вектора3 = {Vector.AdditionTwoVectors(vector1, vector3).ToString()}");
            Console.WriteLine($"Вычитание из вектора1 вектора3 = {Vector.SubtractionTwoVectors(vector1, vector3).ToString()}");
            Console.WriteLine($"Скалярное произведение вектора3 и вектора4 = {Vector.ScalarMultiplicationTwoVectors(vector3, vector4).ToString()}");
            Console.WriteLine($"Сравнивание вектора4 с вектором2 - {vector4.Equals(vector2)}");

            Console.ReadKey();
        }
    }
}
