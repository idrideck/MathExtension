using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtension.LinearAlgebra;
using MathExtension;
using System.Diagnostics;

namespace TestCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] A = new double[][] { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, new double[] { 7, 8, 9 } };
            ColumnMajorMatrix mat1 = new ColumnMajorMatrix(2, 4);
            Debug.WriteLine(mat1.Str());
            Debug.WriteLine(mat1.T.Str());

            var mat2 = new ColumnMajorMatrix(A);
            Debug.WriteLine(mat2.Str());

            var vec1 = new ColumnVector(new double[] { 10, 11, 12 });

            Debug.WriteLine((mat2 * vec1).Str());

            var complex1 = new Complex(1, 2);

            Debug.WriteLine(complex1.Str);
            Debug.WriteLine((complex1 * complex1).Str);
            
            Debug.WriteLine((complex1 + complex1).Str);
            Debug.WriteLine((complex1 - complex1).Str);
            Debug.WriteLine((2*complex1).Str);
            Debug.WriteLine((complex1*4).Str);
            Debug.WriteLine((2 / complex1).Str);
            Debug.WriteLine((complex1 / 4).Str);

            SquareMatrix mat1Sqr = complex1;

            Debug.WriteLine(mat1Sqr.Str());
        }
    }
}
