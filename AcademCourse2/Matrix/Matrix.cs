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
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (columnsCount <= 0 || rowsCount <= 0)
            {
                throw new ArgumentException("количество строк и столбцов должно быть > 0");
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < matrix.rows.Length; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] newComponents)
        {
            if (newComponents.Length == 0)
            {
                throw new ArgumentException("Длинна массива не должна быть = 0");
            }

            int componentsCount = newComponents.Length / (newComponents.GetLength(0));
            rows = new Vector[newComponents.GetLength(0)];

            for (int i = 0; i < newComponents.GetLength(0); i++)
            {
                double[] array = new double[componentsCount];

                for (int j = 0; j < componentsCount; j++)
                {
                    array[j] = newComponents[i, j];
                }
                rows[i] = new Vector(array);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("Длинна массива не должна быть = 0");
            }

            int maxLength = 0;
            foreach (Vector vector in vectors)
            {
                maxLength = vector.GetSize() >= maxLength ? vector.GetSize() : maxLength;
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                double[] componentsArray = new double[maxLength];

                for (int j = 0; j < vectors[i].GetSize(); j++)
                {
                    componentsArray[j] = vectors[i].GetComponent(j);
                }

                rows[i] = new Vector(componentsArray);
            }

        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= GetRowsCount())
            {
                throw new IndexOutOfRangeException();
            }

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= GetRowsCount())
            {
                throw new IndexOutOfRangeException();
            }

            if (vector.GetSize() < GetColumnsCount() || vector.GetSize() > GetColumnsCount())
            {
                double[] components = new double[GetColumnsCount()];
                for (int i = 0; i < Math.Min(vector.GetSize(), GetColumnsCount()); i++)
                {
                    components[i] = vector.GetComponent(i);
                }

                vector = new Vector(components);
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= GetColumnsCount())
            {
                throw new IndexOutOfRangeException();
            }

            double[] column = new double[GetRowsCount()];
            for (int i = 0; i < GetRowsCount(); i++)
            {
                column[i] = rows[i].GetComponent(index);
            }
            return new Vector(column);
        }

        public void Transpose()
        {
            Vector[] array = new Vector[GetColumnsCount()];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetColumn(i);
            }

            rows = array;

        }

        public void MultiplyByNumber(double number)
        {
            foreach (Vector row in rows)
            {
                row.MultiplyByNumber(number);
            }
        }

        private static Matrix GetMinor(Matrix matrix, int n)
        {
            Matrix minor = new Matrix(matrix.GetRowsCount() - 1, matrix.GetColumnsCount() - 1);
            for (int i = 1; i < matrix.rows.GetLength(0); i++)
            {
                minor.rows[i - 1] = new Vector(matrix.rows[0].GetSize() - 1);
                for (int j = 0, k = 0; j < matrix.rows[0].GetSize(); j++)
                {
                    if (j == n)
                    {
                        continue;
                    }
                    minor.rows[i - 1].SetComponent(k, matrix.rows[i].GetComponent(j));
                    k++;
                }
            }
            return minor;
        }

        public double GetDeterminant()
        {
            if (GetColumnsCount() != GetRowsCount())
            {
                throw new ArgumentException("Матрица должна быть квадратной!");
            }

            if (rows.Length == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (GetRowsCount() == 2)
            {
                return rows[0].GetComponent(0) * rows[1].GetComponent(1) -
                    rows[0].GetComponent(1) * rows[1].GetComponent(0);
            }

            double factor = 1;
            double determinator = 0;

            for (int i = 0; i < rows[0].GetSize(); i++)
            {
                Matrix minor = GetMinor(this, i);
                determinator += factor * rows[0].GetComponent(i) * minor.GetDeterminant();
                factor *= -1;
            }

            return determinator;
        }

        public Matrix MultiplyByVector(Vector vector)
        {
            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException("Количество столбцов матрицы должно совпадать с количеством компонентов вектора!");
            }

            Matrix resultMatrix = new Matrix(vector.GetSize(), 1);

            for (int i = 0; i < resultMatrix.GetRowsCount(); i++)
            {
                double[] resultComponents = new double[1];
                for (int j = 0; j < vector.GetSize(); j++)
                {
                    resultComponents[0] += GetRow(i).GetComponent(j) * vector.GetComponent(j);
                }
                resultMatrix.rows[i] = new Vector(resultComponents);
            }

            return resultMatrix;
        }

        public void AddMatrix(Matrix matrix)
        {
            if (GetRowsCount() != matrix.GetRowsCount() || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("Размерность матриц должна быт одинакова!");
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].AddVector(matrix.rows[i]);
            }
        }

        public void SubtractMatrix(Matrix matrix)
        {
            if (GetRowsCount() != matrix.GetRowsCount() || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("Размерность матриц должна быт одинакова!");
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].SubtractVector(matrix.rows[i]);
            }
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount() || matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Размерность матриц должна быть одинакова!");
            }

            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.AddMatrix(matrix2);
            return newMatrix;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount() || matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Размерность матриц должна быть одинакова!");
            }

            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.SubtractMatrix(matrix2);
            return newMatrix;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы!");
            }

            Matrix newMatrix = new Matrix(matrix1.GetRowsCount(), matrix2.GetColumnsCount());

            for (int i = 0; i < matrix1.GetRowsCount(); i++)
            {
                Vector vector = new Vector(matrix2.GetColumnsCount());
                for (int j = 0; j < matrix2.GetColumnsCount(); j++)
                {
                    vector.SetComponent(j, Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j)));
                }
                newMatrix.rows[i] = new Vector(vector);
            }

            return newMatrix;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");
            for (int i = 0; i < rows.Length; i++)
            {
                sb.Append(rows[i]);
                if (i != rows.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
