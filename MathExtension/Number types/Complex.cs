using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    public class Complex : Number
    {

        public double Real { get { return components[0]; } set { components[0] = value; } }

        public double Imaginary { get { return components[1]; } set { components[1] = value; } }

        /// <summary>
        /// Default Ctor for a Complex number object in the form of C = 0 + 0i
        /// </summary>
        public Complex()
        {
            components = new double[] { 0, 0 };
            setDerivedNumberClassMethods();
        }

        /// <summary>
        /// Ctor for a Complex number object in the form of C = a + bi
        /// </summary>
        /// <param name="a">Real component</param>
        /// <param name="b">Imaginary component</param>
        public Complex(double a, double b)
        {
            components = new double[] { a, b };
            setDerivedNumberClassMethods();
        }

        /// <summary>
        /// Ctor for a Complex number object with data from another Complex number copied over
        /// </summary>
        /// <param name="numberToCopy">Complex number to copy</param>
        public Complex(Complex numberToCopy)
        {
            components = new double[] { numberToCopy.components[0], numberToCopy.components[1] };
            setDerivedNumberClassMethods();
        }

        /// <summary>
        /// Method to link specific Complex number math operator functions to its derived Number class
        /// </summary>
        private void setDerivedNumberClassMethods()
        {
            sum = complexSum;
            scalarMultiple = complexScalarMultiple;
            reciprocal = complexReciprocal;
            multiply = complexMultiplication;
        }

        #region Complex user defined operator overloads
        /// <summary>
        /// Returns the sum of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator +(Complex A, Complex B)
        {
            var newArrVal = complexSum(A.components, B.components, 1);
            return new Complex(newArrVal[0], newArrVal[1]);
        }

        /// <summary>
        /// Returns the difference of Complex A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Complex operator -(Complex A, Complex B)
        {
            var newArrVal = complexSum(A.components, B.components, -1);
            return new Complex(newArrVal[0], newArrVal[1]);
        }

        /// <summary>
        /// Returns the scalar multiple of Complex A and scalar k
        /// </summary>
        /// <param name="A"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Complex operator *(Complex A, double k)
        {
            var newArrVal = complexScalarMultiple(A.components, k);
            return new Complex(newArrVal[0], newArrVal[1]);
        }

        /// <summary>
        /// Returns the scalar multiple of scalar k and Complex A
        /// </summary>
        /// <param name="k"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Complex operator *(double k, Complex A)
        {
            var newArrVal = complexScalarMultiple(A.components, k);
            return new Complex(newArrVal[0], newArrVal[1]);
        }

        /// <summary>
        /// Returns the scalar multiple of Complex A and scalar 1/k
        /// </summary>
        /// <param name="A"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Complex operator /(Complex A, double k)
        {
            var newArrVal = complexScalarMultiple(A.components, 1 / k);
            return new Complex(newArrVal[0], newArrVal[1]);

        }

        /// <summary>
        /// Returns the reciprocal of Complex A
        /// </summary>
        /// <param name="k"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Complex operator /(double k, Complex A)
        {
            var newArrVal = complexReciprocal(k, A.components);
            return new Complex(newArrVal[0], newArrVal[1]);
        }
        #endregion

        #region Class Complex operator functions
        private static double[] complexSum(double[] leftComponents, double[] rightComponents, int sign)
        {
            return new double[] { leftComponents[0] + sign * rightComponents[0], leftComponents[1] + sign * rightComponents[1] };
        }

        private static double[] complexScalarMultiple(double[] leftComponents, double k)
        {
            //return new Complex(A.real * k, A.imaginary * k);

            return new double[] { leftComponents[0] * k, leftComponents[1] * k };
        }

        private static double[] complexMultiplication(double[] leftComponents, double[] rightComponents)
        {
            //return new Complex(A.real * B.real - A.imaginary * B.imaginary, A.imaginary * B.real + A.real * B.imaginary);

            return new double[] { leftComponents[0] * rightComponents[0] - leftComponents[1] * rightComponents[1], leftComponents[1] * rightComponents[0] + leftComponents[0] * rightComponents[1] };
        }

        private static double[] complexReciprocal(double k, double[] rightComponents)
        {
            double divisor = (rightComponents[0] * rightComponents[0] + rightComponents[1] * rightComponents[1]);
            return new double[] { rightComponents[0] * k / divisor, -rightComponents[1] * k / divisor };
        }
        #endregion

        /// <summary>
        /// Returns the conjugate of this complex number
        /// </summary>
        public Complex Conjugate
        {
            get
            {
                return new Complex(Real, -Imaginary);
            }
        }

        /// <summary>
        /// Returns the magnitude of the complex number given by the square root of the sum of its squared components
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Real * Real + Imaginary * Imaginary);
            }
        }

        #region Misc functions
        /// <summary>
        /// Returns this complex number in string format
        /// </summary>
        public override string Str
        {

            get
            {
                string signStr = Imaginary >= 0 ? " + " : " - ";
                return string.Format("{0}{1}{2}i", Real, signStr, Math.Abs(Imaginary));
            }
        }
        #endregion
    }
}