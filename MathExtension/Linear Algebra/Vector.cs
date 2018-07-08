using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// Vector object base class
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Array containing vector elements
        /// </summary>
        protected double[] A;

        /// <summary>
        /// Number of vector elements
        /// </summary>
        public readonly int size;

        /// <summary>
        /// Ctor for a vector of dim elements
        /// </summary>
        /// <param name="dim">Number of elements to consist in this Vector</param>
        protected Vector(int dim)
        {
            size = dim;
            A = new double[size];
        }

        /// <summary>
        /// Ctor for a vector from an array
        /// </summary>
        /// <param name="doubleArr"></param>
        protected Vector(double[] doubleArr)
        {
            size = doubleArr.Length;
            A = doubleArr;
        }

        /// <summary>
        /// Returns the i-th value within this vector
        /// </summary>
        /// <param name="i">Zero indexed</param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                return A[i];
            }
            set
            {
                A[i] = value;
            }
        }

        /// <summary>
        /// Returns the dot muliplication of Vectors A and B
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="B">Vector B</param>
        /// <returns></returns>
        protected static double dotMultiply(Vector A, Vector B)
        {
            if (A.size == B.size)
            {
                double C = 0;

                for (int i = 0; i < A.size; i++)
                {
                    C += A[i] * B[i];
                }
                return C;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        /// <summary>
        /// Returns the sum/difference of Vectors A and B in an array depending on the sign
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="B">Vector B</param>
        /// <param name="sign">1 for addition, -1 for subtraction</param>
        /// <returns></returns>
        protected static double[] sum(Vector A, Vector B, int sign)
        {
            if(A.size == B.size)
            {
                double[] C = new double[A.size];

                for (int i = 0; i < A.size; i++)
                {
                    C[i] = A[i] + sign * B[i];
                }
                return C;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns the scalar multiple of Vector A
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="k">Scalar multiple</param>
        /// <returns></returns>
        protected static double[] scalarMultiply(Vector A, double k)
        {
            double[] C = new double[A.size];

            for (int i = 0; i < A.size; i++)
            {
                C[i] = A[i] * k;
            }
            return C;
        }

        /// <summary>
        /// Returns/sets the array of this Vector
        /// </summary>
        public double[] Arr
        {
            get { return A; }
            set
            {
                if(value.Length != size) { throw new ArgumentOutOfRangeException(); } else { A = value; }
            }
        }

        /// <summary>
        /// Returns the Euclidian norm of this Vector by returning the square root of the sum of all squared elements 
        /// </summary>
        public double EuclidNorm
        {
            get
            {
                double sum = 0;
                for(int i = 0; i < size; i++)
                {
                    sum += A[i] * A[i];
                }

                return Math.Sqrt(sum);
            }
            
        }

        /// <summary>
        /// Returns the Matrix-vector multiplication as an array
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="B">Vector B</param>
        /// <returns></returns>
        protected static double[] singleThreadMultiplication(Matrix A, Vector B)
        {
            if (A.n != B.size)
            {
                throw new ArgumentOutOfRangeException(string.Format("Tried to multiply Matrix with dim {0} and Vector with dim {1}", string.Join(",", A.Dim), string.Join(",", B.size)));
            }
            else
            {
                double[] C = new double[B.size];
                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < B.size; j++)
                    {
                        C[i] += A[i, j] * B[j];
                    }
                }
                return C;
            }
        }

        /// <summary>
        /// Returns the elements of this vector as a string
        /// </summary>
        /// <param name="separatorChar">Character to separate values by</param>
        /// <returns></returns>
        public virtual string Str(string separatorChar = "\n")
        {
            return string.Join(separatorChar, A);
        }
    }
}
