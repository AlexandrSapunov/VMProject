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
    public partial class GraphicsView : Form
    {
        public GraphicsView()
        {
            InitializeComponent();
            button1_Click();
        }

        private void button1_Click()
        {
            NumericalDifferentiation numericalDiff = new NumericalDifferentiation(0, 10, 30);
            double[] xValues = numericalDiff.GetXValues();
            double[] yValues = numericalDiff.GetYValues();
            double[] forwardDifferences = numericalDiff.CalculateForwardDifferences();
            double[] centralDifferences = numericalDiff.CalculateCentralDifferences();

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";

            Series ySeries = chart1.Series.Add("Y полученые из X");
            ySeries.ChartType = SeriesChartType.Line;
            ySeries.Color = Color.Blue;

            Series forwardSeries = chart1.Series.Add("Метод односторонней разности");
            forwardSeries.ChartType = SeriesChartType.Line;
            forwardSeries.Color = Color.Red;

            Series centralSeries = chart1.Series.Add("Метод двустороней разности");
            centralSeries.ChartType = SeriesChartType.Line;
            centralSeries.Color = Color.Green;
            Console.WriteLine("\nY");
            for (int i = 0; i < xValues.Length; i++)
            {
                ySeries.Points.AddXY(xValues[i], yValues[i]);
                Console.Write($"\t{yValues[i]}");
            }
            Console.WriteLine("\none dif");
            for (int i = 0; i < forwardDifferences.Length; i++)
            {
                forwardSeries.Points.AddXY(xValues[i], forwardDifferences[i]);
                Console.Write($"\t{forwardDifferences[i]}");
            }
            Console.WriteLine("\ntwo dif");
            for (int i = 0; i < centralDifferences.Length; i++)
            {
                centralSeries.Points.AddXY(xValues[i], centralDifferences[i]);
                Console.Write($"\t{centralDifferences[i]}");
            }
        }

    }
}
