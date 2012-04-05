using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Configuration;
using System.Xml;
using ContinuousClientIntegration.Business.Statistics;
using ContinuousClientIntegration.Business.Config;

namespace DojoTimer
{
    public partial class FormSessionChart : Form
    {
        private string _fileNameToMonitor = string.Empty;
        private string _basePathToMonitor = string.Empty;
        private string _initialTitle = string.Empty;
        private DateTime _lastWriteTime;
        private Chart _chart;

        private System.Windows.Forms.Timer _continousTestingTimer;

        public FormSessionChart(Settings settings)
        {
            InitializeComponent();

            string filenameToMonitor = "";
            _basePathToMonitor = settings.BasePath;
            
            InitializeFileToMonitor(filenameToMonitor);
            _initialTitle = this.Text;

            _continousTestingTimer_Tick(null, null);

            //setup timer
            _continousTestingTimer = new Timer();
            _continousTestingTimer.Interval = 10000;    //10 seconds
            _continousTestingTimer.Tick += new EventHandler(_continousTestingTimer_Tick);
            _continousTestingTimer.Start();
        }

        private bool HasAnythingChangedSinceTheLastTime()
        {
            FileInfo f = new FileInfo(_fileNameToMonitor);
            if (f.LastWriteTime <= _lastWriteTime)
            {
                return false;
            }
            _lastWriteTime = f.LastWriteTime;
            return true;
        }

        void _continousTestingTimer_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(_fileNameToMonitor))
            {
                return;
            }

            if (!HasAnythingChangedSinceTheLastTime())
            {
                return;
            }

            this.Controls.Clear();

            DrawChartFromFile(_fileNameToMonitor);
            ResetTitle();
        }

        private void ResetTitle()
        {
            this.Text = _initialTitle + " " + DateTime.Now.ToLongTimeString();
        }


        private void InitializeFileToMonitor(string fileNameToMonitor)
        {
            if (string.IsNullOrEmpty(fileNameToMonitor))
            {
                DateTime d = DateTime.Now;
                fileNameToMonitor = d.Year.ToString() + d.Month.ToString().PadLeft(2, '0') + d.Day.ToString().PadLeft(2, '0') + ".xml";
            }

            _fileNameToMonitor = Path.Combine(_basePathToMonitor, fileNameToMonitor);
        }



        private void ResizeChart()
        {
            _chart.Top = 0;
            _chart.Left = 0;
            _chart.Width = this.Width;
            _chart.Height = this.Height - 50;
        }

        private void DrawChartFromFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            DataRangeReader reader = new DataRangeReader();
            List<DataRange> dataRanges = reader.ReadDataRangesFromXmlDocument(doc);

            List<DataRange> eventRanges = reader.ReadEventRangesFromXmlDocument(doc);

            _chart = ChartBuilder.CreateChart();
            ChartBuilder.FillChartRanges(dataRanges, _chart);

            ChartBuilder.FillChartRangesEvents(eventRanges, _chart);

            this.Controls.Add(_chart);
            _chart.Dock = DockStyle.Fill;

            ResizeChart();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeChart();
        }

    }
}
