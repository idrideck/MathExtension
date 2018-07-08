using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// A Column Vector object derived from the Vector base class
    /// </summary>
    public class ColumnVector : Vector
    {
        /// <summary>
        /// Returns the dimensions of this vector
        /// </summary>
        public int[] Dim
        {
            get { return new int[] { size, 1 }; }
        }

        /// <summary>
        /// Ctor for a Vector of dimension dim
        /// </summary>
        /// <param name="dim">Number of containing elements</param>
        public ColumnVector(int dim) : base(dim)
        {

        }
        /// <summary>
        /// Ctor for a Vector from an array
        /// </summary>
        /// <param name="A"></param>
        public ColumnVector(double[] A) : base(A)
        {

        }

        #region Column vector functions/operators
        /// <summary>
        /// Returns the sum of Vector A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static ColumnVector operator +(ColumnVector A, ColumnVector B)
        {
            return new ColumnVector(sum(A, B, 1));
        }

        /// <summary>
        /// Returns the difference of Vector A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static ColumnVector operator -(ColumnVector A, ColumnVector B)
        {
            return new ColumnVector(sum(A, B, -1));
        }

        /// <summary>
        /// Returns the negative of Vector A
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static ColumnVector operator -(ColumnVector A)
        {
            return new ColumnVector(scalarMultiply(A, -1));
        }

        /// <summary>
        /// Returns the scalar multiple of Vector A
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="k">Scalar multiple</param>
        /// <returns></returns>
        public static ColumnVector operator *(ColumnVector A, double k)
        {
            return new ColumnVector(scalarMultiply(A, k));
        }

        /// <summary>
        /// Returns the scalar multiple of Vector A
        /// </summary>
        /// <param name="k">Scalar multiple</param>
        /// <param name="A">Vector A</param>
        /// <returns></returns>
        public static ColumnVector operator *(double k, ColumnVector A)
        {
            return new ColumnVector(scalarMultiply(A, k));
        }

        /// <summary>
        /// Returns the 1/k scalar multiple of Vector A
        /// </summary>
        /// <param name="A">Vector A</param>
        /// <param name="k">1/k Scalar multiple</param>
        /// <returns></returns>
        public static ColumnVector operator /(ColumnVector A, double k)
        {
            return new ColumnVector(scalarMultiply(A, 1 / k));

        }

        /// <summary>
        /// Returns an m x n matrix from the diadic product of vector A and B
        /// </summary>
        /// <param name="A">Vector A of size m</param>
        /// <param name="B">Vector B of size n</param>
        /// <returns></returns>
        public static Matrix operator *(ColumnVector A, RowVector B)
        {
            Matrix C = new Matrix(A.size, B.size);
            for (int i = 0; i < A.size; i++)
            {
                C.SetArr(i, (A[i] * B).Arr);
            }
            return C;
        }

        /// <summary>
        /// Returns the Matrix-Vector product of Matrix A and Column Vector B
        /// </summary>
        /// <param name="A">Transformation matrix</param>
        /// <param name="B">Vector B</param>
        /// <returns></returns>
        public static ColumnVector operator *(Matrix A, ColumnVector B)
        {
            return new ColumnVector(Vector.singleThreadMultiplication(A, B));
        }

        /// <summary>
        /// Returns a Row Vector of this Column Vector
        /// </summary>
        public RowVector T
        {
            get
            {
                return new RowVector(A);
            }
        }
        #endregion
    }
}
