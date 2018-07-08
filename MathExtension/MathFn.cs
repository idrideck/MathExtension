using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    /// <summary>
    /// An extension to the random class object
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Generates a random variable with a gaussian distribution probability.
        /// </summary>
        /// <param name="RndVar"></param>
        /// <param name="mean">Data mean value</param>
        /// <param name="stdDev">Standard deviation of values</param>
        /// <returns></returns>
        public static double GaussianDistr(this Random RndVar, double mean, double stdDev)
        {
            double u1 = RndVar.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = RndVar.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return mean + stdDev * randStdNormal;
        }
    }
    /// <summary>
    /// A static class of math functions
    /// </summary>
    public static class Function
    {
        /// <summary>
        /// Returns x^n
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double power(double x, double n)
        {
            return Math.Pow(x, n);
        }

        /// <summary>
        /// Outputs value from sigmoid function 1/(1+e^-x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Returns (2a/(1+e^-2x)) -1
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double tanh(double x)
        {
            //x = 0.65847895, minimum change in vel; change in accel = 0
            //return (2 / (1 + Math.Exp(-2 * x))) - 1;
            return Math.Tanh(x);
        }

        /// <summary>
        /// Returns x/(1+|x|)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double softsign(double x)
        {
            return x / (1 + Math.Abs(x));
        }
        
        /// <summary>
        /// Returns the standard deviation (sample type) of a list of double
        /// </summary>
        /// <param name="valueList">List of double values</param>
        /// <returns></returns>
        public static double StandardDeviationSample(this List<double> valueList)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (double value in valueList)
            {
                double tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 2));
        }
        
        /// <summary>
        /// Returns the standard deviation (sample type) of a list of int
        /// </summary>
        /// <param name="valueList">List of int values</param>
        /// <returns></returns>
        public static double StandardDeviationSample(this List<int> valueList)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (int value in valueList)
            {
                double tmpM = M;
                M += ((double)value - tmpM) / k;
                S += ((double)value - tmpM) * ((double)value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 2));
        }
        
        /// <summary>
        /// Returns the variance (sample type) of a list of double
        /// </summary>
        /// <param name="valueList">List of double values</param>
        /// <returns></returns>
        public static double VarianceSample(this List<double> valueList)
        {
            double std = StandardDeviationSample(valueList);
            return std * std;
        }
        
        /// <summary>
        /// Returns the variance (sample type) of a list of int
        /// </summary>
        /// <param name="valueList">List of int values</param>
        /// <returns></returns>
        public static double VarianceSample(this List<int> valueList)
        {
            double std = StandardDeviationSample(valueList);
            return std * std;
        }

        /// <summary>
        /// Returns the median value of a list of doubles
        /// </summary>
        /// <param name="valueList"></param>
        /// <param name="sortedList"></param>
        /// <returns></returns>
        public static double Median(this List<double> valueList, List<double> sortedList = null)
        {
            List<double> tempList;
            if (sortedList == null)
            {
                tempList = new List<double>(valueList);
                tempList.Sort();
            }
            else
            {
                tempList = sortedList;
            }
            
            int numVal = tempList.Count();
            if (numVal % 2 == 0)
            {
                //is even number
                int bottomIndex = (numVal / 2) -1 ;
                int topIndex = bottomIndex + 1;

                double bottomVal = tempList[bottomIndex];
                double topVal = tempList[topIndex];

                return (bottomVal + topVal )/ 2;
            }
            else
            {
                return tempList[numVal / 2];
            }
        }
        /// <summary>
        /// Returns the first, second and third quartiles
        /// </summary>
        /// <param name="valueList"></param>
        /// <param name="sortedList"></param>
        /// <returns></returns>
        public static double[] Quartiles(this List<double> valueList, List<double> sortedList = null)
        {
            List<double> tempList;
            double[] quartiles = new double[3];
            if (sortedList == null)
            {
                tempList = new List<double>(valueList);
                tempList.Sort();
            }
            else
            {
                tempList = sortedList;
            }
            int numVal = tempList.Count();
            
            if(numVal % 2 == 0)
            {
                //is even number
                quartiles[0] = Median(tempList.Take(numVal / 2).ToList(), tempList.Take(numVal / 2).ToList());
                quartiles[1] = Median(tempList, tempList);
                quartiles[2] = Median(tempList.Skip(numVal / 2).ToList(), tempList.Skip(numVal / 2).ToList());
            }
            else
            {
                //numVal = 2n+1, use n entries, (numval-1)/2 = n
                int n = (numVal - 1) / 2;
                quartiles[0] = Median(tempList.Take(n).ToList(), tempList.Take(n).ToList());
                quartiles[1] = Median(tempList, tempList);
                quartiles[2] = Median(tempList.Skip(n).ToList(), tempList.Skip(n).ToList());
            }
            return quartiles;
        }

        private const double normalDistPDFConst = 0.39894228040143267793994605993438;//1 / Math.Sqrt(2 * Math.PI);
        /// <summary>
        /// Returns the probability of a normally distributed variable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mean"></param>
        /// <param name="standardDeviation"></param>
        /// <returns></returns>
        public static double normalDistPDF(double value,double mean, double standardDeviation)
        {
            //(1/(sigmaFailed*sqrt(2*pi)))*e^(-0.5*((x-meanFailed)/sigmaFailed)^2)
            double valueToSquare = (value - mean) / standardDeviation;
            return normalDistPDFConst * (1 / standardDeviation) * Math.Exp(-0.5 * valueToSquare * valueToSquare);
        }
        /// <summary>
        /// Returns the Cumulative Density of a normally distributed variable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mean"></param>
        /// <param name="standardDeviation"></param>
        /// <returns></returns>
        public static double normalDistCDF(double value, double mean, double standardDeviation)
        {
            return 0.5 * (1 + erf((value - mean) / (standardDeviation * Math.Pow(2, 0.5))));
        }
        
        /// <summary>
        /// Returns the error function with a maximual error of 1.2x10^-7
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double erf(double x)
        {
            double tau;
            double t = 1 / (1 + 0.5 * Math.Abs(x));

            tau = t * Math.Exp(-(x * x) 
                - 1.26551223 
                + 1.00002368 * t 
                + 0.37409196 * Math.Pow(t, 2) 
                + 0.09678418 * Math.Pow(t, 3) 
                - 0.18628806 * Math.Pow(t, 4) 
                + 0.278860807 * Math.Pow(t, 5) 
                - 1.13520398 * Math.Pow(t, 6) 
                + 1.48851587 * Math.Pow(t, 7) 
                - 0.82215223 * Math.Pow(t, 8) 
                + 0.17087277 * Math.Pow(t, 9));

            if(x >= 0)
            {
                return 1 - tau;
            }
            else
            {
                return tau - 1;
            }
        }

        /// <summary>
        /// Returns the baysian conditional probability of P(A|B)
        /// </summary>
        /// <param name="pA">Probability of true A</param>
        /// <param name="pBgivenA">Probability of B given A is true</param>
        /// <param name="pBgivenMinusA">Probability of B given A is not true</param>
        /// <param name="pMinusA">Probability of false A</param>
        /// <returns></returns>
        public static double BayesPofAgivenB(double pA, double pBgivenA, double pBgivenMinusA, double pMinusA)
        {
            return (pBgivenA * pA) / (pBgivenA * pA + pBgivenMinusA * pMinusA);
        }
    }
    

    
}
