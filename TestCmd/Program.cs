using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtension.LinearAlgebra;
using MathExtension;
using System.Diagnostics;
//using MathExtension.Linear_Algebra;

namespace TestCmd
{
    class Program
    {
        static void Main(string[] args)
        {


            /*var vec = new Vector<Complex>(new Complex[] { new Complex(1, 2), new Complex(-5, 10) });
            var vec2 = new Vector<Complex>(new Complex[] { new Complex(3, -1), new Complex(2, 7) });

            var vec3 = vec + vec2;

            var genericNum = new Number();

            Debug.WriteLine(vec3.Str);

            Debug.WriteLine((vec3 * 2).Str);

            Debug.WriteLine((vec3 / 2).Str);

            var vec4 = new Vector<Complex>(new Complex[] { new Complex(0, 1), new Complex(2, 3) } );
            var vec5 = new Vector<Complex>(new Complex[] { new Complex(1, 0), new Complex(-3, 5) });

            Debug.WriteLine(vec4.Str);
            Debug.WriteLine(vec5.Str);

            Debug.WriteLine((vec4 * (vec5)).Str);*/

            Complex num1 = new Complex(1,2);

            Complex num2 = new Complex(3,4);

            var num3 = num1 + num2;

            Debug.WriteLine(num3.Str);
        }
    }
}
