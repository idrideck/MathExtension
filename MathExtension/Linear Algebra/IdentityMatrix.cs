using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// An identity matrix object derived from the SquareMatrix base class
    /// </summary>
    public class IdentityMatrix : SquareMatrix
    {
        /// <summary>
        /// Ctor for an m x m Identity Matrix
        /// </summary>
        /// <param name="size">Number of rows and columns</param>
        public IdentityMatrix(int size) : base(size)
        {
            for(int i = 0; i < size; i++)
            {
                A[i][i] = 1;
            }
        }

    }
}
