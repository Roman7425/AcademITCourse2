using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        public double[] components;

        public Vector(int newVectorsLength)
        {
            if (newVectorsLength <= 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            components = new double[newVectorsLength];
        }

        public Vector(double[] newVectorsComponents)
        {
            if (newVectorsComponents.Length == 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            components = new double[newVectorsComponents.Length];
            Array.Copy(newVectorsComponents, components, newVectorsComponents.Length);
        }

        public Vector(int newVectorsLength, double[] newVectorsComponents)
        {
            if (newVectorsComponents.Length == 0)
            {
                throw new ArgumentException("Количество компонент вектора должно быть больше нуля.");
            }
            components = new double[newVectorsLength];
            Array.Copy(newVectorsComponents, components, newVectorsComponents.Length);
        }

        public Vector(Vector cloneVector)
        {
            components = new double[cloneVector.GetSize()];
            Array.Copy(cloneVector.components, components, cloneVector.components.Length);
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void AddVector(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void SubtractVector(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByNumber(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= number;
            }
        }

        public void Turn()
        {
            MultiplyByNumber(-1);
        }

        public double GetLength()
        {
            double sum = 0;
            foreach (double component in components)
            {
                sum += Math.Pow(component, 2);
            }
            return Math.Sqrt(sum);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponentByIndex(int index, double newComponent)
        {
            components[index] = newComponent;
        }

        public static Vector AddTwoVectors(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1);
            newVector.AddVector(vector2);
            return newVector;
        }

        public static Vector SubtractTwoVectors(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1);
            newVector.SubtractVector(vector2);
            return newVector;
        }

        public static double GetScalarMultiplicationTwoVectors(Vector vector1, Vector vector2)
        {
            int minArraysLength = Math.Min(vector1.GetSize(), vector2.GetSize());
            double scalar = 0;

            for (int i = 0; i < minArraysLength; i++)
            {
                scalar += vector1.components[i] * vector1.components[i];
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
                if (components[i] != vector.components[i])
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
            foreach (double comp in components)
            {
                hash += prime * hash + comp.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", components)}}}";
        }
    }
}
