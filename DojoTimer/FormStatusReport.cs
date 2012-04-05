using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using ContinuousClientIntegration.Business.Coverage;

namespace DojoTimer
{
    public partial class FormStatusReport : Form
    {
        private FormTestDetails _formTestDetails = null;
        private ProcessResult _result = null;

        public FormStatusReport()
        {
            InitializeComponent();
        }

        public void SetValues(ProcessResult result)
        {
            this.buttonTestDetails.Visible = false;

            _result = result;
            if (result.TestResults != null)
            {
                 this.labelTestsFailingCount.Text = result.TestResults.CountFailed.ToString();
                this.labelTestsPassingCount.Text = result.TestResults.CountPassed.ToString();
                this.labelTestsExecutedCount.Text = result.TestResults.CountExecuted.ToString();

                if (result.TestResults.CountFailed > 0)
                {
                    this.buttonTestDetails.Visible = true;
                }

                if (result.TestResults.CoveredAssemblies != null)
                {
                    foreach (CoveredAssembly assembly in result.TestResults.CoveredAssemblies)
                    {
                        listBoxCoverage.Items.Add(assembly.Name + " " + assembly.GetCoverage().ToString() + "%");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDetails(_result.TestResults.FailingTests);
        }

        private void ShowDetails(List<string> text)
        {
            if (_formTestDetails != null)
            {
                _formTestDetails.Close();
                _formTestDetails = null;
                return;
            }

            if (_result != null)
            {
                _formTestDetails = new FormTestDetails();
                _formTestDetails.Top = this.Top;
                _formTestDetails.Left = this.Left - _formTestDetails.Width;
                _formTestDetails.SetValues(text);
                _formTestDetails.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_result != null)
            {
                List<string> text = new List<string>();
                if (_result.TestResults.CoveredAssemblies != null)
                {
                    List<CoveredMethod> allMethods = new List<CoveredMethod>();
                    foreach (CoveredAssembly assembly in _result.TestResults.CoveredAssemblies)
                    {
                        allMethods.AddRange(assembly.Methods);
                    }

                    var ordered = allMethods.Where(c => c.GetCoverage() < 100).OrderBy(c => c.GetCoverage() * c.CodeSize);
                    foreach (CoveredMethod method in ordered)
                    {
                        text.Add(method.TypeName + "." + method.Name + " " + method.GetCoverage() + "% " + method.CodeSize.ToString());
                    }
                }

                ShowDetails(text);
            }
        }
    }
}
