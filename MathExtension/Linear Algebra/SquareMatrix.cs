using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension.LinearAlgebra
{
    /// <summary>
    /// An square matrix object derived from the matrix base class
    /// </summary>
    public class SquareMatrix : Matrix
    {
        /// <summary>
        /// Ctor for an m x m Identity Matrix
        /// </summary>
        /// <param name="size">Number of rows and columns</param>
        public SquareMatrix(int size) : base(size, size)
        {
        }
        /// <summary>
        /// Ctor for a square matrix from a jagged array
        /// </summary>
        /// <param name="doubleArr"></param>
        public SquareMatrix(double[][] doubleArr) : base(doubleArr)
        {
            for(int i = 0; i < doubleArr.Length; i++)
            {
                if(doubleArr[i].Length != m)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
