using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// Matrix object base class
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Jagged array containing matrix elements
        /// </summary>
        public double[][] A;

        /// <summary>
        /// Number of rows
        /// </summary>
        public readonly int m;

        /// <summary>
        /// Number of columns
        /// </summary>
        public readonly int n;
        /// <summary>
        /// Returns the m x n dimensions of this matrix
        /// </summary>
        public int[] Dim
        {
            get { return new int[] { m, n }; }
        }
        /// <summary>
        /// Returns the number of elements stored in this matrix
        /// </summary>
        public int numElements { get { return m * n; } }

        /// <summary>
        /// Ctor for an m x n Matrix
        /// </summary>
        /// <param name="M">Number of rows</param>
        /// <param name="N">Number of columns</param>
        /// <param name="initializeArray">Determines if Ctor initializes the array</param>
        public Matrix(int M, int N, bool initializeArray = true)
        {
            if (initializeArray)
            {
                A = new double[M][];
                for (int i = 0; i < M; i++)
                {
                    A[i] = new double[N];
                }
            }
            

            m = M;
            n = N;
        }
        /// <summary>
        /// Ctor for a matrix from a jagged array
        /// </summary>
        /// <param name="doubleArr"></param>
        public Matrix(double[][] doubleArr)
        {
            A = doubleArr;
            m = doubleArr.Length;
            n = doubleArr[0].Length;
        }

        /// <summary>
        /// Returns the value at the i-th row of j-th column
        /// </summary>
        /// <param name="i">Row zeroed index</param>
        /// <param name="j">Column zeroed index</param>
        /// <returns></returns>
        public virtual double this[int i, int j]
        {
            get
            {
                return A[i][j];
            }
            set
            {
                A[i][j] = value;
            }
        }

        #region Matrix functions/operators
        private static Matrix Sum(Matrix A, Matrix B, int sign)
        {
            Matrix C = new Matrix(A.m, A.n);
            for(int i = 0; i < A.m; i++)
            {
                for(int j = 0; j < A.n; j++)
                {
                    C[i, j] = A[i, j] + sign*B[i, j];
                }
            }
            return C;
        }
        /// <summary>
        /// Returns the sum of Matrix A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator + (Matrix A, Matrix B)
        {
            return Sum(A, B, 1);
        }
        /// <summary>
        /// Returns the difference of Matrix A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator - (Matrix A, Matrix B)
        {
            return Sum(A, B, -1);
        }

        private static Matrix HadamardProduct(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.m, A.n);
            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    C[i, j] = A[i, j] * B[i, j];
                }
            }
            return C;
        }
        /// <summary>
        /// Returns the Hadamard Product of two matricies
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator ^(Matrix A, Matrix B)
        {
            return HadamardProduct(A, B);
        }
        

        private static Matrix singleThreadMultiplication(Matrix A, Matrix B)
        {
            if (A.n != B.m)
            {
                throw new ArgumentOutOfRangeException(string.Format("Tried to multiply Matrix with dim {0} and Matrix with dim {1}", string.Join(",", A.Dim), string.Join(",", B.Dim)));
            }
            else
            {
                Matrix C = new Matrix(A.m, B.n);
                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < B.n; j++)
                    {
                        for (int k = 0; k < A.n; k++)
                        {
                            C[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
                return C;
            }
        }
        /// <summary>
        /// Matrix dot multipilcation
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, Matrix B)
        {
            return singleThreadMultiplication(A, B);
        }
        

        #region Scalar multiply/divide
        /// <summary>
        /// Returns the scalar multiple of Matrix A
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="k">Scalar multiple</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, double k)
        {
            return scale(A, k);
        }
        /// <summary>
        /// Returns the scalar multiple of Matrix A
        /// </summary>
        /// <param name="k">Scalar multiple</param>
        /// <param name="A">Matrix A</param>
        /// <returns></returns>
        public static Matrix operator *(double k, Matrix A)
        {
            return scale(A, k);
        }
        /// <summary>
        /// Returns the scalar multiple of 1/k of Matrix A
        /// </summary>
        /// <param name="A">Matrix a</param>
        /// <param name="k">Scalar multiple</param>
        /// <returns></returns>
        public static Matrix operator /(Matrix A, double k)
        {
            return scale(A, 1 / k);
        }
        /// <summary>
        /// Returns the negative of Matrix A
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix A)
        {
            return scale(A, -1);
        }

        private static Matrix scale(Matrix A, double k)
        {
            Matrix C = new Matrix(A.m, A.n);
            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    C[i,j] = A[i,j] * k;
                }
            }
            return C;
        }
        /// <summary>
        /// Returns the sum of all elements in Matrix A
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <returns></returns>
        public static double sum(Matrix A)
        {
            double total = 0;
            for(int i = 0; i < A.m; i++)
            {
                for(int j = 0; j < A.n; j++)
                {
                    total += A[i, j];
                }
            }
            return total;
        }
        #endregion
        

        /// <summary>
        /// Returns this matrix transposed
        /// </summary>
        public virtual Matrix T
        {
            get
            {
                Matrix C = new Matrix(n, m);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        C[i, j] = this[j, i];//A[j][i];
                    }
                }
                return C;
            }
        }
        /// <summary>
        /// Returns the Frobenius norm of this matrix by returning the squareroot of the sum of all squared elements 
        /// </summary>
        public double FrobeniusNorm
        {
            get
            {
                double sum = 0;

                for(int i = 0; i < m; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        sum += this[i, j] * this[i, j];
                    }
                }

                return Math.Sqrt(sum);
            }
        }

        #endregion


        #region Misc functions
        /// <summary>
        /// Returns a character seperated string of this matrix values
        /// </summary>
        /// <param name="seperatorChar"></param>
        /// <returns></returns>
        public virtual string Str(string seperatorChar = ",")
        {
            string outStr = "";
            for(int i = 0; i < m; i++)
            {
                outStr += string.Format("{0}\n", string.Join(seperatorChar, A[i]));
            }
            return outStr;
        }
        /// <summary>
        /// Returns the containing row array
        /// </summary>
        public double[] GetArr(int rowIndex)
        {
            return A[rowIndex];
        }
        /// <summary>
        /// Sets the row array of this matrix
        /// </summary>
        /// <param name="rowIndex">Zero indexed</param>
        /// <param name="rowArr">Array to set</param>
        public void SetArr(int rowIndex, double[] rowArr)
        {
            if(rowArr.Length != n)
            {
                throw new ArgumentOutOfRangeException("Tried to set row array larger than matrix n dim");
            }
            else
            {
                A[rowIndex] = rowArr;
            }
            
        }
        #endregion
    }
}
