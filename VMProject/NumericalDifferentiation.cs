using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMProject
{
    public class NumericalDifferentiation
    {
        private double[] xValues;
        private double[] yValues;

        public NumericalDifferentiation(double start, double end, int n)
        {
            xValues = new double[n];
            yValues = new double[n];
            double h = (end - start) / (n - 1);
            for (int i = 0; i < n; i++)
            {
                xValues[i] = start + i * h;
                yValues[i] = (Math.Sin(xValues[i]) + xValues[i]) / Math.Tan(Math.Sqrt(xValues[i]));
            }
        }

        public double[] GetXValues()
        {
            return xValues;
        }

        public double[] GetYValues()
        {
            return yValues;
        }

        public double[] CalculateForwardDifferences()
        {
            double[] forwardDifferences = new double[yValues.Length - 1];
            for (int i = 0; i < forwardDifferences.Length; i++)
            {
                forwardDifferences[i] = yValues[i + 1] - yValues[i];
            }
            return forwardDifferences;
        }

        public double[] CalculateCentralDifferences()
        {
            double[] centralDifferences = new double[yValues.Length - 2];
            for (int i = 0; i < centralDifferences.Length; i++)
            {
                centralDifferences[i] = yValues[i + 2] - yValues[i];
            }
            return centralDifferences;
        }
    }
}
