using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMProject
{
    public class SolverDiffEquations
    {
        public List<double> eulerMetodResult { get; set; }
        public List<double> rungeKuttaMethodResult { get; set; }
        public double Func(double x, double y)
        {
            return (Math.Cos(Math.Pow(x,2)+Math.Pow(y,2))/Math.Pow(1+Math.Pow(x,2)+Math.Pow(y,2),1/3));
        }

        public double EulerMethod(double initialValue, double x0, double X, int n)
        {
            eulerMetodResult = new List<double>();
            double h = (X - x0) / n;
            double x = x0;
            double y = initialValue;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\tx: {x}\ty: {y:F4}\tdy: {h * Func(x, y):F4}");
                eulerMetodResult.Add(h * Func(x, y));
                y += h * Func(x, y);
                x += h;
            }

            return y;
        }

        public double RungeKuttaMethod(double initialValue, double x0, double X, int n)
        {
            rungeKuttaMethodResult = new List<double>();
            double h = (X - x0) / n;
            double x = x0;
            double y = initialValue;

            for (int i = 0; i < n; i++)
            {
                double k1 = h * Func(x, y);
                double k2 = h * Func(x + h / 2, y + k1 / 2);
                double k3 = h * Func(x + h / 2, y + k2 / 2);
                double k4 = h * Func(x + h, y + k3);
                Console.WriteLine($"\tx: {x}\ty: {y:F4}\tdy: {((k1 + 2 * k2 + 2 * k3 + k4) / 6):F4}");
                rungeKuttaMethodResult.Add((k1 + 2 * k2 + 2 * k3 + k4) / 6);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                x += h;
            }

            return y;
        }

    }
}
