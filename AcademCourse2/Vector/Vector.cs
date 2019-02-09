using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        public double[] componentsArray;

        public Vector(int newArrayLength)
        {
            if (newArrayLength <= 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            componentsArray = new double[newArrayLength];
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            componentsArray = new double[array.Length];
            Array.Copy(array, componentsArray, array.Length);
        }

        public Vector(int newArrayLength, double[] array)
        {
            if (array.Length <= 0 || newArrayLength <= 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            componentsArray = new double[newArrayLength];
            Array.Copy(array, componentsArray, array.Length);
        }

        public Vector(Vector cloneVector)
        {
            componentsArray = new double[cloneVector.GetSize()];
            Array.Copy(cloneVector.componentsArray, componentsArray, cloneVector.componentsArray.Length);
        }

        public int GetSize()
        {
            return componentsArray.Length;
        }

        public void AddVector(Vector vector)
        {
            if (componentsArray.Length < vector.componentsArray.Length)
            {
                Array.Resize(ref componentsArray, vector.componentsArray.Length);
                for (int i = 0; i < componentsArray.Length; i++)
                {
                    componentsArray[i] += vector.componentsArray[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.componentsArray.Length; i++)
                {
                    componentsArray[i] += vector.componentsArray[i];
                }
            }
        }

        public void SubtractVector(Vector vector)
        {
            if (componentsArray.Length < vector.componentsArray.Length)
            {
                Array.Resize(ref componentsArray, vector.componentsArray.Length);
                for (int i = 0; i < componentsArray.Length; i++)
                {
                    componentsArray[i] -= vector.componentsArray[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.componentsArray.Length; i++)
                {
                    componentsArray[i] -= vector.componentsArray[i];
                }
            }
        }

        public void MultipliedByNumber(double number)
        {
            for (int i = 0; i < componentsArray.Length; i++)
            {
                componentsArray[i] = componentsArray[i] * number;
            }
        }

        public void Turn()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                componentsArray[i] = componentsArray[i] * -1;
            }
        }

        public double GetLength()
        {
            double sum = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                sum += Math.Pow(componentsArray[i], 2);
            }
            return Math.Sqrt(sum);
        }

        public double GetElement(int index)
        {
            return componentsArray[index];
        }

        public static Vector AdditionTwoVectors(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() < vector2.GetSize())
            {
                Array.Resize(ref vector1.componentsArray, vector2.GetSize());
                double[] newComponentsArray = new double[vector1.GetSize()];

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newComponentsArray[i] = vector1.componentsArray[i] + vector2.componentsArray[i];
                }
                return new Vector(newComponentsArray);
            }
            else
            {
                Array.Resize(ref vector2.componentsArray, vector1.GetSize());
                double[] newComponentsArray = new double[vector1.GetSize()];

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newComponentsArray[i] = vector1.componentsArray[i] + vector2.componentsArray[i];
                }
                return new Vector(newComponentsArray);
            }
        }

        public static Vector SubtractionTwoVectors(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() < vector2.GetSize())
            {
                Array.Resize(ref vector1.componentsArray, vector2.GetSize());
                double[] newComponentsArray = new double[vector1.GetSize()];

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newComponentsArray[i] = vector1.componentsArray[i] - vector2.componentsArray[i];
                }
                return new Vector(newComponentsArray);
            }
            else
            {
                Array.Resize(ref vector2.componentsArray, vector1.GetSize());
                double[] newComponentsArray = new double[vector1.GetSize()];

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newComponentsArray[i] = vector1.componentsArray[i] - vector2.componentsArray[i];
                }
                return new Vector(newComponentsArray);
            }
        }

        public static double ScalarMultiplicationTwoVectors(Vector vector1, Vector vector2)
        {
            int minArraysLength = vector1.GetSize() < vector2.GetSize() ? vector1.GetSize() : vector2.GetSize();
            double scalar = 0;

            for (int i = 0; i < minArraysLength; i++)
            {
                scalar += vector1.componentsArray[i] * vector1.componentsArray[i];
            }

            return scalar;
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

            Vector vector = (Vector)obj;
            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (componentsArray[i] != vector.componentsArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            foreach (double comp in componentsArray)
            {
                hash += prime * hash + comp.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", componentsArray)}}}";
        }
    }
}
