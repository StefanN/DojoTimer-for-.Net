using System;
using System.Drawing;
using System.Windows.Forms;
using ContinuousClientIntegration.Business;
using System.Configuration;
using System.Threading;
using ContinuousClientIntegration.Business.Statistics;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using ContinuousClientIntegration.Business.Config;
using System.Collections.Generic;
using System.IO;

namespace DojoTimer
{


    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private TimeSpan _timeLeft;
        private TimeSpan _startTime;
        private Settings _settings;
        private bool _continousTestingisRunning;
        private ProcessResult _continuousTestResult;
        private System.Windows.Forms.Timer _continousTestingTimer;
        StatisticsLogger _logger = new StatisticsLogger();
        private FormStatusReport _formStatusReport = null;
        private FormTaskList _formTaskList = null;
        private FormSessionChart _formSessionChart = null;

        private ObservableTaskCollection _tasks;

        public Form1()
        {
            InitializeComponent();
            ReadSettings();

            // tasks
            ChangeCurrentTask(null);
            _tasks = new ObservableTaskCollection();
            _tasks.Read();
            _tasks.CurrentTaskChanged += new EventHandler(_tasks_CurrentTaskChanged);
            _tasks_CurrentTaskChanged(null, null);
           
            UpdateViewSize(_currentViewSize);
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 4;
            this.Top = Screen.PrimaryScreen.WorkingArea.Top + 26;

            StartTimer();
            UpdateUI();
            this.TopMost = true;

            _startBackColor = this.BackColor;
            _startForeColor = Color.Black;

            StartContinousTesting();
        }

     
        void _tasks_CurrentTaskChanged(object sender, EventArgs e)
        {
            ChangeCurrentTask(_tasks.CurrentTask);
        }

        private void ChangeCurrentTask(Task task)
        {
            string description = string.Empty;

            if (task != null)
            {
                description = task.Description;
            }
            this.labelCurrentTaskSmall.Text = description;
            this.labelCurrentTaskLarge.Text = description;
        }

        private void CompileAndTestThreaded()
        {
            UpdateColorStatus(Color.Yellow);
            ThreadStart ts = new ThreadStart(CompileAndTest);
            Thread t = new Thread(ts);
            t.Start();
        }

        private void CompileAndTest()
        {
            if (_continousTestingisRunning)
                return;

            UpdateButtonVisibility(false);
            _continousTestingisRunning = true;
            ContinuousIntegrationClientProcess process = new ContinuousIntegrationClientProcess(_settings);

            ProcessResult result = process.Start();
            _continuousTestResult = result;

            _logger.LogStatistics(_settings, result);

            if (result.ResultCode == ExitCode.Success)
            {
                _logger.LogEvent_BuildSuccess(_settings);
            }
            else if (result.ResultCode == ExitCode.Failure)
            {
                _logger.LogEvent_BuildFailure(_settings);
            }

            if (result.ResultCode == ExitCode.Success)
            {
                UpdateColorStatus(Color.LightGreen);
                UpdateButtonVisibility(true);
            }
            else
            {
                UpdateColorStatus(Color.Red);
                UpdateButtonVisibility(true);
            }
            _continousTestingisRunning = false;
        }

        public void StartContinousTesting()
        {
          
            buttonStatusReport.Visible = false;
            _continousTestingTimer = new System.Windows.Forms.Timer();
            _continousTestingTimer.Enabled = true;
            _continousTestingTimer.Interval = _settings.CompileInterval;
            _continousTestingTimer.Tick += new EventHandler(_continousTestingTimer_Tick);

            CompileAndTestThreaded();
        }

        void _continousTestingTimer_Tick(object sender, EventArgs e)
        {
            CompileAndTestThreaded();
        }


        public void StartTimer()
        {
            _logger.LogEvent_StartTimer(_settings);
            _startTime = new TimeSpan(0, _settings.TimerInterval, 0);
            _timeLeft = new TimeSpan(0, _settings.TimerInterval, 0);
            UpdateUI();
            _timer = new System.Windows.Forms.Timer();
            _timer.Enabled = true;
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);

            this.BackColor = _startBackColor;
            this.labelTimerLarge.ForeColor = _startForeColor;
            this.labelTimerSmall.ForeColor = _startForeColor;
            this.buttonRestartTimer.BackColor = _startBackColor;
        }

        private Color _startBackColor;
        private Color _startForeColor;

        private void ShowTimedOutUI()
        {
            this.BackColor = Color.Black;
            this.labelTimerLarge.ForeColor = Color.White;
            this.labelTimerSmall.ForeColor = Color.White;
            this.buttonRestartTimer.BackColor = Color.White;
        }

        private void ShowLastMinuteUI()
        {
            this.labelTimerLarge.ForeColor = Color.Red;
            this.labelTimerSmall.ForeColor = Color.Red;
        }

        private void UpdateUI()
        {
            string text = _timeLeft.Minutes.ToString().PadLeft(2, '0') + ":" + _timeLeft.Seconds.ToString().PadLeft(2, '0');
            labelTimerLarge.Text = text;
            labelTimerSmall.Text = text;

            if (_timeLeft.TotalSeconds <= 60)
            {
                ShowLastMinuteUI();
            }

            if (_timeLeft.TotalSeconds == 0)
            {
                ShowTimedOutUI();
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timeLeft = _timeLeft.Add(new TimeSpan(0, 0, -1));

            if (_timeLeft.TotalSeconds == 0)
            {
                _timer.Enabled = false;
                _logger.LogEvent_EndTimer(_settings);
            }
            UpdateUI();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _timer.Dispose();
            StartTimer();
        }

        private void buttonContinuousTesting_Click(object sender, EventArgs e)
        {
            CompileAndTestThreaded();
        }

        public delegate void ColorParameterDelegate(Color value);
        void UpdateColorStatus(Color value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new ColorParameterDelegate(UpdateColorStatus), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            buttonContinuousTesting.BackColor = value;
            buttonContinuousTesting2.BackColor = value;
        }

        delegate void BoolParameterDelegate(bool value);
        void UpdateButtonVisibility(bool value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new BoolParameterDelegate(UpdateButtonVisibility), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            buttonStatusReport.Visible = value;
        }

        private void ReadSettings()
        {
            _settings = new Settings();

            _settings.BuildLogFileName = "buildresults.txt";
            _settings.TestLogFileName = "testresults.xml";
            _settings.CoverageLogFileName = "partcoverresults.xml";

            _settings.SolutionPath = Properties.Settings.Default.SolutionPath;

            // read the interval from the settings
            _settings.TimerInterval = Properties.Settings.Default.TimerMinutes;
            _settings.CompileInterval = Properties.Settings.Default.CompileIntervalMilliseconds;
            _settings.CleanUp = Properties.Settings.Default.CleanupAfterCompile;
            _settings.UseCoverage = Properties.Settings.Default.UseCoverage;

            _settings.BasePath = Properties.Settings.Default.BaseCompilePath;
            _settings.OutputPath = _settings.BasePath;
            _settings.MSBuildPath = Properties.Settings.Default.MSBuildPath;
            _settings.MSTestPath = Properties.Settings.Default.MSTestPath;
            _settings.PartCoverPath = Properties.Settings.Default.PartCoverPath;
            _settings.CoverageReportingAssembliesRegEx = Properties.Settings.Default.CoverageReportingAssembliesRegEx;
        }

        private void buttonStatusReport_Click(object sender, EventArgs e)
        {
            if (_formStatusReport != null)
            {
                _formStatusReport.Close();
                _formStatusReport = null;
                return;
            }

            _formStatusReport = new FormStatusReport();
            _formStatusReport.SetValues(_continuousTestResult);
            _formStatusReport.Width = this.Width;
            _formStatusReport.Top = this.Top + this.Height;
            _formStatusReport.Left = this.Left;
            _formStatusReport.Show();
        }


        private ViewSize _currentViewSize = ViewSize.Large;
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentViewSize == ViewSize.Large)
            {
                _currentViewSize = ViewSize.Small;
            }
            else
            {
                _currentViewSize = ViewSize.Large;
            }
            UpdateViewSize(_currentViewSize);
        }

        delegate void ViewSizeParameterDelegate(ViewSize size);
        void UpdateViewSize(ViewSize size)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new ViewSizeParameterDelegate(UpdateViewSize), new object[] { size });
                return;
            }
            // Must be on the UI thread if we've got this far
            if (size == ViewSize.Large)
            {
                panelLarge.Visible = true;
                panelLarge.Left = 2;
                panelLarge.Top = 20;
                panelSmall.Visible = false;
                this.Width = panelLarge.Width + 4;
                this.Height = panelLarge.Height + 40;
            }
            if (size == ViewSize.Small)
            {
                panelSmall.Visible = true;
                panelSmall.Left = 2;
                panelSmall.Top = 20;
                panelSmall.Width = panelLarge.Width;
                panelSmall.Height = 40;
                panelLarge.Visible = false;
                this.Width = panelSmall.Width + 4;
                this.Height = panelSmall.Height + 34;
            }
        }

        private void buttonContinuousTesting2_Click(object sender, EventArgs e)
        {
            CompileAndTestThreaded();
        }

        private void buttonTaskList_Click(object sender, EventArgs e)
        {
            if (_formTaskList != null)
            {
                _formTaskList.Close();
                _formTaskList = null;
                return;
            }

            _formTaskList = new FormTaskList(_tasks);
            _formTaskList.Width = this.Width;
            _formTaskList.Top = this.Top + this.Height;
            _formTaskList.Left = this.Left;

            _formTaskList.Show();
        }

        void _formTaskList_TaskChanged(object sender, EventArgs e)
        {
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigure form = new FormConfigure(_settings);
            form.ShowDialog();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void buttonNewTask_Click(object sender, EventArgs e)
        {
            FormAddTask form = new FormAddTask(_tasks);
            form.ShowDialog();
        }

        private void buttonSessionLog_Click(object sender, EventArgs e)
        {
            if (_formSessionChart != null)
            {
                _formSessionChart.Close();
                _formSessionChart = null;
                return;
            }

            _formSessionChart = new FormSessionChart(_settings);
            _formSessionChart.Width = this.Width;
            _formSessionChart.Top = this.Top + this.Height;
            _formSessionChart.Left = 0;
            _formSessionChart.Width = Screen.GetBounds(this).Width;
            _formSessionChart.Height = Screen.GetBounds(this).Height - (this.Top + this.Height + 2);
            _formSessionChart.Show();
        }
    }


    public enum ViewSize
    {
        Small,
        Large
    }

   
}
