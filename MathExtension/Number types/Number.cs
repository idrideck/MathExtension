using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    public class Number
    {

        public double[] components;

        public Func<double[], double[], int, double[]> sum;
        public Func<double[], double, double[]> scalarMultiple;
        public Func<double, double[], double[]> reciprocal;
        public Func<double[], double[], double[]> multiply;

        public virtual string Str
        {
            get { throw new InvalidOperationException(); }
        }
    }
}