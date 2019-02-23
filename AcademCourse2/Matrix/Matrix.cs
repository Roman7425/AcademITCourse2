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
        private Vector [] components;

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
            Array.Copy(matrix.components,components,matrix.components.Length);
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
                    array[j] = newComponents[i,j];
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

        private static Matrix GetMinor (Matrix matrix,int n)
        {
            Matrix minor = new Matrix(matrix.GetCountString() - 1,matrix.GetCountColumn() - 1);
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
