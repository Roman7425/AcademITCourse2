using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private int ArrayLength;
        public double[] VectorsArray { get; set; }

        public Vector(int newArrayLength)
        {
            if (newArrayLength <= 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            ArrayLength = newArrayLength;
            VectorsArray = new double[ArrayLength];

            for (int i = 0; i < ArrayLength; i++)
            {
                VectorsArray[i] = 0;
            }
        }

        public Vector(double[] array)
        {
            VectorsArray = new double[array.Length];
            ArrayLength = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                VectorsArray[i] = array[i];
            }
        }

        public Vector(int newArrayLength, double[] array)
        {
            VectorsArray = new double[newArrayLength];
            ArrayLength = newArrayLength;

            for (int i = 0; i < newArrayLength; i++)
            {
                if (i >= array.Length)
                {
                    VectorsArray[i] = 0;
                }
                else
                {
                    VectorsArray[i] = array[i];
                }
            }
        }

        public Vector(Vector clonVector)
        {
            VectorsArray = new double[clonVector.GetSize()];
            ArrayLength = clonVector.ArrayLength;

            for (int i = 0; i < VectorsArray.Length; i++)
            {
                VectorsArray[i] = clonVector.VectorsArray[i];
            }
        }

        public int GetSize()
        {
            return ArrayLength;
        }

        public Vector AddVector(Vector vector)
        {
            int newVectorsArrayLength = GetSize() > vector.GetSize() ? GetSize() : vector.GetSize();
            double[] newVectorsArray = new double[newVectorsArrayLength];

            if (GetSize() > vector.GetSize())
            {

                for (int i = 0; i < GetSize(); i++)
                {
                    if (i >= vector.GetSize())
                    {
                        newVectorsArray[i] = VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = VectorsArray[i] + vector.VectorsArray[i];
                    }
                }
            }
            else if (GetSize() < vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    if (i >= GetSize())
                    {
                        newVectorsArray[i] = vector.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = VectorsArray[i] + vector.VectorsArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < GetSize(); i++)
                {
                    newVectorsArray[i] = VectorsArray[i] + vector.VectorsArray[i];
                }
            }

            return new Vector(newVectorsArray);
        }

        public Vector ExceptVector(Vector vector)
        {
            int newVectorsArrayLength = GetSize() > vector.GetSize() ? GetSize() : vector.GetSize();
            double[] newVectorsArray = new double[newVectorsArrayLength];

            if (GetSize() > vector.GetSize())
            {
                for (int i = 0; i < GetSize(); i++)
                {
                    if (i >= vector.GetSize())
                    {
                        newVectorsArray[i] = VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = VectorsArray[i] - vector.VectorsArray[i];
                    }
                }
            }
            else if (GetSize() < vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    if (i >= GetSize())
                    {
                        newVectorsArray[i] = -vector.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = VectorsArray[i] - vector.VectorsArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < GetSize(); i++)
                {
                    newVectorsArray[i] = VectorsArray[i] - vector.VectorsArray[i];
                }
            }

            return new Vector(newVectorsArray);
        }

        public Vector MultipliedByNumber(double number)
        {
            double[] array = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                array[i] = VectorsArray[i] * number;
            }

            return new Vector(array);
        }

        public Vector TurnVector()
        {
            double[] array = new double[GetSize()];
            for (int i = 0; i < GetSize(); i++)
            {
                array[i] = VectorsArray[i] * -1;
            }

            return new Vector(array);
        }

        public double GetVectorsLength()
        {
            double sum = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                sum += Math.Pow(VectorsArray[i], 2);
            }
            return Math.Sqrt(sum);
        }

        public double GetElement(int index)
        {
            return VectorsArray[index];
        }

        public static Vector AdditionTwoVectors(Vector vector1, Vector vector2)
        {
            int newVectorArrayLength = vector1.GetSize() > vector2.GetSize() ? vector1.GetSize() : vector2.GetSize();
            double[] newVectorsArray = new double[newVectorArrayLength];

            if (vector1.GetSize() > vector2.GetSize())
            {
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    if (i >= vector2.GetSize())
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i] + vector2.VectorsArray[i];
                    }
                }
            }
            else if (vector1.GetSize() < vector2.GetSize())
            {
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    if (i >= vector1.GetSize())
                    {
                        newVectorsArray[i] = vector2.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i] + vector2.VectorsArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newVectorsArray[i] = vector1.VectorsArray[i] + vector2.VectorsArray[i];
                }
            }

            return new Vector(newVectorsArray);
        }

        public static Vector SubtractionTwoVectors(Vector vector1, Vector vector2)
        {
            int newVectorsArrayLength = vector1.GetSize() > vector2.GetSize() ? vector1.GetSize() : vector2.GetSize();
            double[] newVectorsArray = new double[newVectorsArrayLength];

            if (vector1.GetSize() > vector2.GetSize())
            {
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    if (i >= vector2.GetSize())
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i] - vector2.VectorsArray[i];
                    }
                }
            }
            else if (vector1.GetSize() < vector2.GetSize())
            {
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    if (i >= vector1.GetSize())
                    {
                        newVectorsArray[i] = -vector2.VectorsArray[i];
                    }
                    else
                    {
                        newVectorsArray[i] = vector1.VectorsArray[i] - vector2.VectorsArray[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    newVectorsArray[i] = vector1.VectorsArray[i] - vector2.VectorsArray[i];
                }
            }

            return new Vector(newVectorsArray);
        }

        public static double ScalarMultiplicationTwoVectors(Vector vector1, Vector vector2)
        {
            int minArraysLength = vector1.GetSize() < vector2.GetSize() ? vector1.GetSize() : vector2.GetSize();
            double scalar = 0;

            for (int i = 0; i < minArraysLength; i++)
            {
                scalar += vector1.VectorsArray[i] * vector1.VectorsArray[i];
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

            bool isEqually = true;
            for (int i = 0; i < GetSize(); i++)
            {
                if (VectorsArray[i] != vector.VectorsArray[i])
                {
                    isEqually = false;
                    break;
                }
            }
            return isEqually;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            for (int i = 0; i < VectorsArray.Length; i++)
            {
                hash += prime * hash + VectorsArray[i].GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return String.Join(", ", VectorsArray);
        }
    }
}
