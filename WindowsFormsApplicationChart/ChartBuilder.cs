using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using ContinuousClientIntegration.Business.Statistics;

namespace WindowsFormsApplicationChart
{
    public class ChartBuilder
    {
        public static Chart CreateChart()
        {
            Chart chart1 = new Chart();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            chart1.Palette = ChartColorPalette.Bright;

            string dateFormat = "HH:mm:ss";

            // create first chartarea for coverage
            chart1.ChartAreas.Add(new ChartArea("Coverage"));
            chart1.ChartAreas[0].AxisY.Title = "Coverage (%)";

            // create second chartarea for codesize
            chart1.ChartAreas.Add(new ChartArea("Codesize"));
            chart1.ChartAreas[1].AxisY.Title = "Codesize";

            chart1.ChartAreas[1].AlignWithChartArea = chart1.ChartAreas[0].Name;
            chart1.ChartAreas[1].AlignmentStyle = AreaAlignmentStyles.PlotPosition | AreaAlignmentStyles.AxesView;

            // Set Back Color
            chart1.BackColor = Color.WhiteSmoke;
            // Set Back Gradient End Color
            chart1.BackSecondaryColor = Color.White;
            // Set Gradient Type
            chart1.BackGradientStyle = GradientStyle.DiagonalRight;
            // Set Border Color
            chart1.BorderColor = Color.Blue;
            // Set Border Style
            chart1.BorderDashStyle = ChartDashStyle.Solid;
            // Set Border Width
            chart1.BorderWidth = 2;

            
            chart1.Legends.Add(new Legend("Coverage"));
            chart1.Legends[0].Title = "Covered assemblies";
            chart1.Legends[0].DockedToChartArea = "Coverage";
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].IsDockedInsideChartArea = false;

            chart1.Legends.Add(new Legend("Codesize"));
            chart1.Legends[1].Title = "Measured Assemblies";
            chart1.Legends[1].DockedToChartArea = "Codesize";
            chart1.Legends[1].Docking = Docking.Right;
            chart1.Legends[1].IsDockedInsideChartArea = false;
            
            //two chart area's
            for (int i = 0; i < 2; i++)
            {
                ApplyChartSettings(chart1.ChartAreas[i], dateFormat, i);
            }

            return chart1;
        }

        private static void ApplyChartSettings(ChartArea area, string dateFormat, int i)
        {
            area.AxisX.MajorGrid.Interval = 15;
            area.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            area.AxisX.MajorTickMark.Interval = 15;
            area.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            area.AxisX.LabelStyle.Interval = 0.5;
            area.AxisX.LabelStyle.Format = dateFormat;
            area.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
        }

        public static void FillChartRanges(List<DataRange> ranges, Chart chart1)
        {
            foreach (DataRange range in ranges)
            {
                Series series = new Series(range.Id + " " + range.Description);
                series.ChartType = SeriesChartType.Line;
                series.MarkerStyle = MarkerStyle.Circle;

                series.EmptyPointStyle.BorderWidth = 0;
                series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;

                chart1.Series.Add(series);
                foreach (ContinuousClientIntegration.Business.Statistics.DataPoint point in range.DataPoints)
                {
                    series.Points.AddXY(point.TimeStamp, point.Value);
                }
                if (range.Description.Equals("Coverage"))
                {
                    series.ChartArea = "Coverage";
                    series.Legend = "Coverage";
                }
                if (range.Description.Equals("Codesize"))
                {
                    series.ChartArea = "Codesize";
                    series.Legend = "Codesize";
                }
            }
            if (ranges.Count > 0 && ranges[0].DataPoints.Count > 0)
            {
                chart1.Titles.Add("Coverage and codesize on " + ranges[0].DataPoints[0].TimeStamp.ToShortDateString());
            }
        }

        public static void FillChartRangesEvents(List<DataRange> ranges, Chart chart1)
        {
            foreach (DataRange range in ranges)
            {
                Series series = new Series(range.Description);
                series.ChartType = SeriesChartType.FastPoint;
                int value = 120;

                series.ChartArea = "Coverage";
                series.Legend = "Coverage";

                switch (range.Description.ToLower())
                {
                    case "starttimer":
                        series.MarkerStyle = MarkerStyle.Star5;
                        series.MarkerSize = 15;
                        series.MarkerBorderColor = Color.Green;
                        series.MarkerColor = Color.White;
                        break;
                    case "endtimer":
                        series.MarkerStyle = MarkerStyle.Star5;
                        series.MarkerSize = 15;
                        series.MarkerColor = Color.White;
                        series.MarkerBorderColor = Color.Blue;
                        break;
                    case "buildfailure":
                        series.MarkerStyle = MarkerStyle.Cross;
                        series.MarkerSize = 4;
                        series.MarkerColor = Color.Red;
                        series.MarkerBorderColor = Color.Red;
                        break;
                    case "buildsuccess":
                        series.MarkerStyle = MarkerStyle.Diamond;
                        series.MarkerSize = 4;
                        series.MarkerColor = Color.Green;
                        series.MarkerBorderColor = Color.Green;
                        break;
                    default:
                        break;
                }
   
                chart1.Series.Add(series);
                foreach (ContinuousClientIntegration.Business.Statistics.DataPoint point in range.DataPoints)
                {
                    series.Points.AddXY(point.TimeStamp, value);
                }
                
            }

        }
    }
}
