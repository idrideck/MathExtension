using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// A Row Vector object derived from the Vector base class
    /// </summary>
    public class RowVector : Vector
    {
        /// <summary>
        /// Returns the dimensions of this vector
        /// </summary>
        public int[] Dim
        {
            get { return new int[] { 1 , size }; }
        }

        /// <summary>
        /// Ctor for a Vector of dimension dim
        /// </summary>
        /// <param name="dim">Number of containing elements</param>
        public RowVector(int dim) : base(dim)
        {

        }
        /// <summary>
        /// Ctor for a Vector from an array
        /// </summary>
        /// <param name="A"></param>
        public RowVector(double[] A) : base(A)
        {

        }

        #region Row vector functions/operators

        /// <summary>
        /// Returns the sum of Vector A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static RowVector operator +(RowVector A, RowVector B)
        {
            return new RowVector(sum(A, B, 1));
        }

        /// <summary>
        /// Returns the difference of Vector A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static RowVector operator -(RowVector A, RowVector B)
        {
            return new RowVector(sum(A, B, -1));
        }

        /// <summary>
        /// Returns the negative of Vector A
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static RowVector operator -(RowVector A)
        {
            return new RowVector(scalarMultiply(A, -1));
        }

        /// <summary>
        /// Returns the scalar multiple of Vector A
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="k">Scalar multiple</param>
        /// <returns></returns>
        public static RowVector operator *(RowVector A, double k)
        {
            return new RowVector(scalarMultiply(A, k));
        }

        /// <summary>
        /// Returns the scalar multiple of Vector A
        /// </summary>
        /// <param name="k">Scalar multiple</param>
        /// <param name="A">Vector A</param>
        /// <returns></returns>
        public static RowVector operator *(double k, RowVector A)
        {
            return new RowVector(scalarMultiply(A, k));
        }

        /// <summary>
        /// Returns the 1/k scalar multiple of Vector A
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="k">1/k Scalar multiple</param>
        /// <returns></returns>
        public static RowVector operator /(RowVector A, double k)
        {
            return new RowVector(scalarMultiply(A, 1 / k));

        }

        /// <summary>
        /// Returns a double from the dot product of Vector A and Vector B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double operator *(RowVector A, ColumnVector B)
        {
            return dotMultiply(A, B);
        }

        /// <summary>
        /// Returns the Vector-Matrix product of Row Vector B and Matrix A 
        /// </summary>
        /// <param name="B">Vector B</param>
        /// <param name="A">Transformation matrix</param>
        /// <returns></returns>
        public static RowVector operator *(RowVector B , Matrix A)
        {
            return new RowVector(Vector.singleThreadMultiplication(A, B));
        }

        /// <summary>
        /// Returns a Column Vector of this Row Vector
        /// </summary>
        public ColumnVector T
        {
            get
            {
                return new ColumnVector(A);
            }
        }
        #endregion

        /// <summary>
        /// Returns the elements of this vector as a string
        /// </summary>
        /// <param name="separatorChar">Character to separate values by</param>
        /// <returns></returns>
        public override string Str(string separatorChar = ",")
        {
            return string.Join(separatorChar, A);
        }
    }
}
