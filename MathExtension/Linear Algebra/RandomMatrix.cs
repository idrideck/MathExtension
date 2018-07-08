using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// A matrix derived from the matrix base class and contains randomly generated values
    /// </summary>
    public class RandomMatrix : Matrix
    {
        /// <summary>
        /// Ctor for an m x n Random Matrix
        /// </summary>
        /// <param name="M">Number of rows</param>
        /// <param name="N">Number of columns</param>
        /// <param name="rndDoubleGenerator">Random function generator</param>
        public RandomMatrix(int M, int N, Func<double> rndDoubleGenerator) : base(M, N)
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    A[i][j] = rndDoubleGenerator();
                }
            }
        }

    }
}
