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

        public virtual string Str
        {
            get { return "Error getting string value from containing type."; }
        }
    }
}