using MathNet.Numerics;
using MathNet.Numerics.Integration;
using System;

namespace VMProject
{
    public class NumericalIntegration
    {
        private double func(double x)
        {
            // variant 21
            double result = (Math.Sin(x)+x) / Math.Tan(Math.Sqrt(x));
            return result;
        }

        public double LeftRectangleIntegrate(double a, double b, int n)
        {
            double h = (b - a) / n; double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += func(a + h * i);
            }

            double error = Math.Abs((b - a) * Math.Pow(h, 2) / 2 * func(1));
            double result = sum * h;
            Show("Метод левых прямоугольников", result, error);
            return result;
        }

        public double MidpointMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                double x1 = a + i * h;
                double x2 = a + (i + 1) * h;
                double middlePoint = (x1 + x2) / 2;
                sum += func(middlePoint) * h;
            }

            double result = sum;
            double error = Math.Abs((b - a) * Math.Pow(h, 2) / 24 * func(1));
            Show("Метод средних прямоугольников", result, error);
            return result;
        }

        public double RightRectangleIntegrate(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += func(a + h * (i + 1));
            }
            double error = Math.Abs((b - a) * Math.Pow(h, 2) / 2 * func(1));
            double result = sum * h;
            Show("Метод правых прямоугольнпиков", result, error);
            return result;
        }

        public double TrapezoidMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = 0;

            for (int i = 0; i < n; i++)
            {
                double x1 = a + i * h;
                double x2 = a + (i + 1) * h;
                result += (func(x1) + func(x2)) * h / 2;
            }
            double error = Math.Abs((b - a) * Math.Pow(h, 2) / 12 * func(1));
            Show("Метод трапеций", result, error);
            return result;
        }

        public double SimpsonMethod(double a, double b, int n)
        {
            if (n % 2 != 0)
            {
                throw new ArgumentException("Для правила Симпсона количество разделов должно быть четным!");
            }

            double h = (b - a) / n;
            double result = func(a) + func(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                result += i % 2 == 0 ? 2 * func(x) : 4 * func(x);
            }
            double error = Math.Abs((b - a) * Math.Pow(h, 4) / 180 * func(1));
            result = result * h / 3;
            Show("Метод Симпсона", result, error);

            return result;
        }

        private int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        private void Show(string desc, double result, double error)
        {
            Console.WriteLine($"{desc}\nОтвет:\t{result:F4}");
            Console.WriteLine($"Погрешность:\t{error}");
            Console.WriteLine();
        }
    }
}
