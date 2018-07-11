using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    public class Number<T> where T : new()
    {
        public double[] components;

        public Number()
        {

        }

        public Number(double[] components)
        {
            this.components = components;
        }

        protected static Func<Number<T>, Number<T>, int, T> add;

        public virtual string Str
        {
            get { throw new InvalidOperationException(); }
        }

        public static T operator + (Number<T> left, Number<T> right)
        {
            return add(left, right, 1);
        }
    }
}