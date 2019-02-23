using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGubkin;

namespace Matrix
{
    class Matrix
    {
        private Vector[] components;

        public Matrix(int n, int m)
        {
            Vector vector = new Vector(n);
            components = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                components[i] = vector;
            }
        }

        public Matrix(Matrix matrix)
        {
            components = new Vector[matrix.components.Length];

            for (int i = 0; i < matrix.components.Length; i++)
            {
                components[i] = new Vector(matrix.components[i]);
            }
        }

        public Matrix(double[,] newComponents)
        {
            int countComponents = newComponents.Length / (newComponents.GetUpperBound(0) + 1);
            components = new Vector[newComponents.GetUpperBound(0) + 1];

            for (int i = 0; i < newComponents.GetUpperBound(0) + 1; i++)
            {
                double[] array = new double[countComponents];

                for (int j = 0; j < countComponents; j++)
                {
                    array[j] = newComponents[i, j];
                }
                components[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] array)
        {
            int maxLenght = 0;
            for (int i = 0; i < array.Length; i++)
            {
                maxLenght = array[i].GetSize() >= maxLenght ? array[i].GetSize() : maxLenght;
            }

            components = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double[] componentsArray = new double[maxLenght];
                for (int j = 0; j < componentsArray.Length; j++)
                {
                    if (j >= array[i].GetSize())
                    {
                        break;
                    }
                    componentsArray[j] = array[i].GetComponent(j);
                }
                components[i] = new Vector(componentsArray);
            }
        }

        public int GetCountString()
        {
            return components.Length;
        }

        public int GetCountColumn()
        {
            return components[0].GetSize();
        }

        public Vector GetString(int index)
        {
            return components[index];
        }

        public void SetString(int index, Vector vector)
        {
            components[index] = new Vector(vector);
        }

        public Vector GetColumn(int index)
        {
            double[] column = new double[GetCountString()];
            for (int i = 0; i < GetCountString(); i++)
            {
                column[i] = components[i].GetComponent(index);
            }
            return new Vector(column);
        }

        public void Transpose()
        {
            Vector[] array = new Vector[GetCountColumn()];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetColumn(i);
            }

            components = new Vector[GetCountColumn()];

            for (int j = 0; j < array.Length; j++)
            {
                components[j] = array[j];
            }
        }

        public void MultiplyByNumber(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].MultiplyByNumber(number);
            }
        }

        private static Matrix GetMinor(Matrix matrix, int n)
        {
            Matrix minor = new Matrix(matrix.GetCountString() - 1, matrix.GetCountColumn() - 1);
            for (int i = 1; i < matrix.components.GetLength(0); i++)
            {
                minor.components[i - 1] = new Vector(matrix.components[0].GetSize() - 1);
                for (int j = 0, k = 0; j < matrix.components[0].GetSize(); j++)
                {
                    if (j == n)
                    {
                        continue;
                    }
                    minor.components[i - 1].SetComponent(k, matrix.components[i].GetComponent(j));
                    k++;
                }
            }
            return minor;
        }

        public double GetDeterminator()
        {
            if (GetCountColumn() != GetCountString())
            {
                throw new ArgumentException("Матрица должна быть квадратной!");
            }

            if (GetCountColumn() == 2 && GetCountString() == 2)
            {
                return components[0].GetComponent(0) * components[1].GetComponent(1) -
                    components[0].GetComponent(1) * components[1].GetComponent(0);
            }

            if (components.Length - 1 == 0 && components[0].GetSize() == 1)
            {
                return components[0].GetComponent(0);
            }

            double factor = 1;
            double determinator = 0;

            for (int i = 0; i < components[0].GetSize(); i++)
            {
                Matrix minor = GetMinor(this, i);
                determinator += factor * components[0].GetComponent(i) * minor.GetDeterminator();
                factor *= -1;
            }

            return determinator;
        }

        public void MultiplyByVector(Vector vector)
        {
            if (GetCountColumn() != 1)
            {
                throw new ArgumentException("Матрица должна быть матрицей - столбцом!");
            }
            else if (GetCountString() != vector.GetSize())
            {
                throw new ArgumentException("Количество строк матрицы должно совпадать с количеством компонентов вектора!");
            }

            for (int i = 0; i < GetCountString(); i++)
            {
                Vector newVector = new Vector(GetCountString());
                for (int j = 0; j < vector.GetSize(); j++)
                {
                    newVector.SetComponent(j, components[i].GetComponent(0) * vector.GetComponent(j));
                }
                SetString(i, newVector);
            }
        }

        public void AddMatrix(Matrix matrix)
        {
            if (GetCountColumn() != matrix.GetCountColumn() || GetCountString() != matrix.GetCountString())
            {
                throw new ArgumentException("Матрицы должны быть одинакового размера!");
            }

            if (GetCountString() != matrix.GetCountString() || GetCountColumn() != matrix.GetCountColumn())
            {
                throw new ArgumentException("Размерность матриц должна быт одинакова!");
            }

            for (int i = 0; i < GetCountString(); i++)
            {
                for (int j = 0; j < GetCountColumn(); j++)
                {
                    components[i].SetComponent(j, components[i].GetComponent(j) + matrix.components[i].GetComponent(j));
                }
            }
        }

        public void SubtractMatrix(Matrix matrix)
        {
            if (GetCountColumn() != matrix.GetCountColumn() || GetCountString() != matrix.GetCountString())
            {
                throw new ArgumentException("Матрицы должны быть одинакового размера!");
            }

            if (GetCountString() != matrix.GetCountString() || GetCountColumn() != matrix.GetCountColumn())
            {
                throw new ArgumentException("Размерность матриц должна быт одинакова!");
            }

            for (int i = 0; i < GetCountString(); i++)
            {
                for (int j = 0; j < GetCountColumn(); j++)
                {
                    components[i].SetComponent(j, components[i].GetComponent(j) - matrix.components[i].GetComponent(j));
                }
            }
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.AddMatrix(matrix2);
            return newMatrix;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.SubtractMatrix(matrix2);
            return newMatrix;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetCountColumn() != matrix2.GetCountString())
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы!");
            }

            Matrix newMatrix = new Matrix(matrix1.GetCountString(), matrix2.GetCountColumn());

            for (int i = 0; i < matrix1.GetCountString(); i++)
            {
                Vector vector = new Vector(matrix2.GetCountColumn());
                for (int j = 0; j < matrix2.GetCountColumn(); j++)
                {
                    vector.SetComponent(j, Vector.GetScalarMultiplication(matrix1.GetString(i), matrix2.GetColumn(j)));
                }

                newMatrix.SetString(i, vector);
            }

            return newMatrix;
        }

        public override string ToString()
        {
            Console.Write("{ ");
            for (int i = 0; i < components.Length; i++)
            {
                Console.Write(components[i]);
                if (i == components.Length - 1)
                {
                    break;
                }
                Console.Write(",");
            }
            Console.Write(" }");
            return null;
        }
    }
}
