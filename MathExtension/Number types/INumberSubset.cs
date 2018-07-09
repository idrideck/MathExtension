using System;
using System.Collections.Generic;
using System.Text;

namespace MathExtension
{
    public interface INumberSubset
    {
        int numElements { get; }

        double[] values { get; set; }

        double[] sum(INumberSubset right, int sign = 1); 

    }
}
