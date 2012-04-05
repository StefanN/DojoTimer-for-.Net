using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContinuousClientIntegration.Business.Config;
using System.IO;

namespace DojoTimer
{
    public partial class FormConfigure : Form
    {
        private Settings _settings;

        public FormConfigure(Settings settings)
        {
            _settings = settings;
            InitializeComponent();
            this.textBoxSolutionFile.Text = _settings.SolutionPath;

            this.textBoxMSTestPath.Text = _settings.MSTestPath;
            this.textBoxPartcoverPath.Text = _settings.PartCoverPath;
            this.textBoxMSBuildPath.Text = _settings.MSTestPath;

            this.textBoxCompileMinutes.Text = (_settings.CompileInterval / 60000).ToString();
            this.textBoxTimerDuration.Text = _settings.TimerInterval.ToString();
            this.checkBox1.Checked = _settings.CleanUp;
            this.textBoxBasePath.Text = _settings.BasePath;

            ValidatePaths();
        }

        private void ValidatePath(TextBox control)
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                if (!File.Exists(control.Text))
                {
                    control.BackColor = Color.LightSalmon;
                }
                else
                {
                    control.BackColor = Color.White;
                }
            }
        }


        private void Save()
        {
            _settings.SolutionPath = this.textBoxSolutionFile.Text;
            Properties.Settings.Default.SolutionPath = _settings.SolutionPath;
            Properties.Settings.Default.Save();
        }

        private void buttonSearchSolutionFile_Click(object sender, EventArgs e)
        {
            BrowseFile("Browse for solution file", "Solution Files|*.sln", this.textBoxSolutionFile);
            ValidatePath(this.textBoxSolutionFile);
        }

        private void buttonBrowseMSBuild_Click(object sender, EventArgs e)
        {
            BrowseFile("Browse for MSBuild exe", "Executable|*.exe", this.textBoxMSBuildPath);
            ValidatePath(this.textBoxMSBuildPath);
        }

        private void buttonBrowseMSTestPath_Click(object sender, EventArgs e)
        {
            BrowseFile("Browse for MSTest exe", "Executable|*.exe", this.textBoxMSTestPath);
            ValidatePath(this.textBoxMSTestPath);
        }

        private void buttonBrowsePartcoverPath_Click(object sender, EventArgs e)
        {
            BrowseFile("Browse for PartCover exe", "Executable|*.exe", this.textBoxPartcoverPath);
            ValidatePath(this.textBoxPartcoverPath);
        }

        private void ValidatePaths()
        {
            ValidatePath(this.textBoxSolutionFile);
            ValidatePath(this.textBoxMSBuildPath);
            ValidatePath(this.textBoxMSTestPath);
            ValidatePath(this.textBoxPartcoverPath);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }


        private void BrowseFile(string title, string filter, TextBox textboxResult)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse for solution file";
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Filter = "Solution Files|*.sln";
            ofd.Multiselect = false;

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                textboxResult.Text = ofd.FileName;
            }
        }

        private void textBoxSolutionFile_TextChanged(object sender, EventArgs e)
        {
            ValidatePath((TextBox)sender);
        }

        private void textBoxMSBuildPath_TextChanged(object sender, EventArgs e)
        {
            ValidatePath((TextBox)sender);
        }

        private void textBoxMSTestPath_TextChanged(object sender, EventArgs e)
        {
            ValidatePath((TextBox)sender);
        }

        private void textBoxPartcoverPath_TextChanged(object sender, EventArgs e)
        {
            ValidatePath((TextBox)sender);
        }
    }
}
