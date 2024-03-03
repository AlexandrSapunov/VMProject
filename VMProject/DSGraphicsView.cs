using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VMProject
{
    public partial class DSGraphicsView : Form
    {
        public DSGraphicsView()
        {
            InitializeComponent();
            DrawChart();
        }

        private void DrawChart()
        {
            SolverDiffEquations solver = new SolverDiffEquations();
            double initialValue = 3;
            double x0 = 1;
            double X = 3;
            int n = 20;

            solver.EulerMethod(initialValue, x0, X, n);
            solver.RungeKuttaMethod(initialValue, x0, X, n);

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "x";
            chart1.ChartAreas[0].AxisY.Title = "y";
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = X;

            Series eulerSeries = new Series();
            eulerSeries.ChartType = SeriesChartType.Line;
            for (int i = 0; i < solver.eulerMetodResult.Count; i++)
            {
                eulerSeries.Points.AddXY(x0 + i * (X - x0) / n, solver.eulerMetodResult[i]);
            }
            eulerSeries.LegendText = "Euler Method";
            chart1.Series.Add(eulerSeries);

            Series rungeKuttaSeries = new Series();
            rungeKuttaSeries.ChartType = SeriesChartType.Line;
            for (int i = 0; i < solver.rungeKuttaMethodResult.Count; i++)
            {
                rungeKuttaSeries.Points.AddXY(x0 + i * (X - x0) / n, solver.rungeKuttaMethodResult[i]);
            }
            rungeKuttaSeries.LegendText = "Runge-Kutta Method";
            chart1.Series.Add(rungeKuttaSeries);
        }
    }
}
