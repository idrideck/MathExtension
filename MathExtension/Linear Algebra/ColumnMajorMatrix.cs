using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// A columnn major matrix object derived from the Matrix base class
    /// </summary>
    public class ColumnMajorMatrix : Matrix
    {
        /// <summary>
        /// Ctor for an M x N Column-Major Matrix
        /// </summary>
        /// <param name="M">Number of rows</param>
        /// <param name="N">Number of columns</param>
        public ColumnMajorMatrix(int M, int N) : base(M, N,false)
        {
            A = new double[N][];
            for (int i = 0; i < N; i++)
            {
                A[i] = new double[M];
            }
        }

        /// <summary>
        /// Ctor for a Column-Major Matrix from a jagged array
        /// </summary>
        /// <param name="doubleArr"></param>
        public ColumnMajorMatrix(double[][] doubleArr): base(doubleArr[0].Length,doubleArr.Length)
        {
            A = doubleArr;
        }

        /// <summary>
        /// Returns the value at the i-th row of j-th column
        /// </summary>
        /// <param name="i">Row zeroed index</param>
        /// <param name="j">Column zeroed index</param>
        /// <returns></returns>
        public override double this[int i, int j]
        {
            get
            {
                return A[j][i];
            }
            set
            {
                A[j][i] = value;
            }
        }

        /// <summary>
        /// Returns a character seperated string of this matrix values
        /// </summary>
        /// <param name="seperatorChar"></param>
        /// <returns></returns>
        public override string Str(string seperatorChar = ",")
        {
            
            string outStr = "";

            double[] toRowMajorRow = new double[n];
            

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    toRowMajorRow[j] = this[i, j];
                }
                outStr += string.Format("{0}\n", string.Join(seperatorChar, toRowMajorRow));
            }
            return outStr;
        }
    }
}
