using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    public class Number<T> where T : new()
    {
        public double[] values;

        public Number()
        {

        }

        public Number(double[] values)
        {
            this.values = values;
        }

        protected static Func<Number<T>, Number<T>, int, Number<T>> add;

        public virtual string Str
        {
            get { throw new InvalidOperationException(); }
        }

        public static Number<T> operator + (Number<T> left, Number<T> right)
        {
            return add(left,right, 1);
        }
    }
}