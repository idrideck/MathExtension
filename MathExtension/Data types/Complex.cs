using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    /// <summary>
    /// Complex number object
    /// </summary>
    public class Complex
    {
        double real;
        double imaginary;

        /// <summary>
        /// Ctor for a complex number in the form of a + b*i
        /// </summary>
        /// <param name="a">Real component</param>
        /// <param name="b">Imaginary component</param>
        public Complex(double a, double b)
        {
            real = a;
            imaginary = b;
        }

        /// <summary>
        /// Ctor for a complex number in the form of a + b*i
        /// </summary>
        /// <param name="complexArr">A two element array whose first element is the real component and second is the imaginary component</param>
        public Complex(double[] complexArr)
        {
            if(complexArr.Length == 2)
            {
                real = complexArr[0];
                imaginary = complexArr[1];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #region Operators
        private static double[] sum(Complex num1, Complex num2, int sign = 1)
        {
            return new double[] { num1.real + sign * num2.real, num1.imaginary + sign * num2.imaginary };
        }

        /// <summary>
        /// Returns the sum of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator +(Complex A, Complex B)
        {
            return new Complex(sum(A, B, 1));
        }

        /// <summary>
        /// Returns the difference of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator -(Complex A, Complex B)
        {
            return new Complex(sum(A, B, -1));
        }

        /// <summary>
        /// Returns the mulplication of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator *(Complex A, Complex B)
        {
            return new Complex(A.real*B.real - A.imaginary*B.imaginary,A.imaginary*B.real + A.real*B.imaginary);
        }

        /// <summary>
        /// Returns the division of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator /(Complex A, Complex B)
        {
            if(B.real == 0 && B.imaginary == 0) { throw new DivideByZeroException(); } else
            {
                double divisor = (B.real * B.real + B.imaginary * B.imaginary);
                return new Complex(
                    (A.real * B.real + A.imaginary * B.imaginary) / divisor,
                    (A.imaginary * B.real - A.real * B.imaginary) / divisor
                    );
            }
            
        }

        /// <summary>
        /// Returns the reciprocal of Complex A
        /// </summary>
        /// <param name="k"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Complex operator /(double k, Complex A)
        {
            double divisor = (A.real * A.real + A.imaginary * A.imaginary);
            return new Complex(A.real*k/divisor,-A.imaginary*k/divisor);
        }

        private static Complex scalarMultiple(Complex A, double k)
        {
            return new Complex(A.real * k, A.imaginary * k);
        }

        /// <summary>
        /// Returns the scalar multiple of Complex A and scalar k
        /// </summary>
        /// <param name="A"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Complex operator *(Complex A, double k)
        {
            return scalarMultiple(A, k);

        }

        /// <summary>
        /// Returns the scalar multiple of scalar k and Complex A
        /// </summary>
        /// <param name="k"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Complex operator *(double k, Complex A)
        {
            return scalarMultiple(A, k);
        }

        /// <summary>
        /// Returns the scalar multiple of Complex A and scalar 1/k
        /// </summary>
        /// <param name="A"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Complex operator /(Complex A, double k)
        {
            return scalarMultiple(A, 1/k);

        }

        #endregion
        /// <summary>
        /// Returns the conjugate of this complex number
        /// </summary>
        public Complex Conjugate
        {
            get
            {
                return new Complex(real, -imaginary);
            }
        }

        /// <summary>
        /// Returns the magnitude of the complex number given by the square root of the sum of its squared components
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(real * real + imaginary * imaginary);
            }
        }

        /// <summary>
        /// Returns this complex number in string format
        /// </summary>
        public string Str
        {
            
            get
            {
                string signStr = imaginary >= 0 ? " + " : " - ";
                return string.Format("{0}{1}{2}i", real, signStr ,Math.Abs(imaginary));
            }
        }

        #region Casting conversions
        /// <summary>
        /// Returns this complex number as a square matrix
        /// </summary>
        /// <param name="A"></param>
        public static implicit operator LinearAlgebra.SquareMatrix (Complex A)
        {
            return new LinearAlgebra.SquareMatrix(new double[][] { new double[] { A.real, -A.imaginary }, new double[] { A.imaginary, A.real } });
        }
        #endregion
    }
}
