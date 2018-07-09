using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.Linear_Algebra
{
    public class Vector<T> where T : Number , new()
    {
        readonly int numElements;
        private T[] VectorData;

        public Vector(int size)
        {
            VectorData = new T[size];
            numElements = size;
            for(int i = 0; i < size; i++)
            {
                VectorData[i] = new T();
            }
        }

        public Vector(T[] numberArr)
        {
            numElements = numberArr.Length;

            VectorData = new T[numElements];
            for(int i = 0; i < numberArr.Length; i++)
            {
                VectorData[i] = new T();
                for(int j = 0; j < VectorData[i].components.Length; j++)
                {
                    VectorData[i].components[j] = numberArr[i].components[j];
                }
            }
            VectorData = numberArr;
        }

        public T this[int i]
        {
            get { return VectorData[i]; }
            set { VectorData[i] = value; }
        }


        #region Class vector operator functions

        private static Vector<T> vectorSumSub(Vector<T> left, Vector<T> right, int sign)
        {
            int size = left.numElements;
            var newVec = new Vector<T>(size);

            for (int i = 0; i < size; i++)
            {
                double[] newVecDoubleArrVal = left[i].sum(left[i].components, right[i].components, sign);
                newVec[i].components = newVecDoubleArrVal;
            }
            return newVec;
        }

        private static Vector<T> vectorScalarMultiply(Vector<T> left, double k)
        {
            int size = left.numElements;
            var newVec = new Vector<T>(size);

            for (int i = 0; i < size; i++)
            {
                double[] newVecDoubleArrVal = left[i].scalarMultiple(left[i].components, k);
                newVec[i].components = newVecDoubleArrVal;
            }
            return newVec;
        }
        #endregion

        #region Vector user defined operator overloads
        public static Vector<T> operator +(Vector<T> left, Vector<T> right)
        {
            return vectorSumSub(left, right, 1);
        }

        public static Vector<T> operator -(Vector<T> left, Vector<T> right)
        {
            return vectorSumSub(left, right, -1);
        }

        public static Vector<T> operator *(Vector<T> left, double k)
        {
            return vectorScalarMultiply(left, k);
        }

        public static Vector<T> operator *(double k, Vector<T> right)
        {
            return vectorScalarMultiply(right, k);
        }

        public static Vector<T> operator /(Vector<T> left, double k)
        {
            return vectorScalarMultiply(left, 1/k);
        }
        #endregion

        #region Misc functions

        public virtual string Str
        {
            get
            {
                string outputStr = "";
                for(int i = 0; i < numElements; i++)
                {
                    outputStr += VectorData[i].Str + "\n";
                }
                return outputStr;
            }
        }

        #endregion


    }
}
