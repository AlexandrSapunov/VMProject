using System;
using System.Windows.Forms;

namespace VMProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumericalIntegration ni = new NumericalIntegration();
            int upEdge = 2;
            int downEdge = 1;
            int n = 30;
            ni.SimpsonMethod(downEdge, upEdge, n);
            ni.TrapezoidMethod(downEdge, upEdge, n);
            ni.MidpointMethod(downEdge, upEdge, n);
            ni.RightRectangleIntegrate(downEdge, upEdge, n);
            ni.LeftRectangleIntegrate(downEdge, upEdge, n);

            SolverDiffEquations solver = new SolverDiffEquations();
            Console.WriteLine("Эйлер");
            solver.EulerMethod(3, 1, Math.PI, 10);
            Console.WriteLine();
            Console.WriteLine("Runga");
            solver.RungeKuttaMethod(3, 1, Math.PI, 10);

            Application.Run(new DSGraphicsView());

            Application.Run(new GraphicsView());
            Console.ReadKey();
        }
    }
}
