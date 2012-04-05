namespace DojoTimer
{
    partial class FormConfigure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSearchSolutionFile = new System.Windows.Forms.Button();
            this.textBoxSolutionFile = new System.Windows.Forms.TextBox();
            this.labelSolutionFile = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelMSBuildPath = new System.Windows.Forms.Label();
            this.textBoxMSBuildPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseMSBuild = new System.Windows.Forms.Button();
            this.labelMSTestPath = new System.Windows.Forms.Label();
            this.textBoxMSTestPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseMSTestPath = new System.Windows.Forms.Button();
            this.labelPartCoverPath = new System.Windows.Forms.Label();
            this.textBoxPartcoverPath = new System.Windows.Forms.TextBox();
            this.buttonBrowsePartcoverPath = new System.Windows.Forms.Button();
            this.groupBoxEnvironmentSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxPersonalSettings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTimerDuration = new System.Windows.Forms.TextBox();
            this.labelWorkingDirectory = new System.Windows.Forms.Label();
            this.textBoxBasePath = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCompileMinutes = new System.Windows.Forms.TextBox();
            this.groupBoxEnvironmentSettings.SuspendLayout();
            this.groupBoxPersonalSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearchSolutionFile
            // 
            this.buttonSearchSolutionFile.Location = new System.Drawing.Point(592, 26);
            this.buttonSearchSolutionFile.Name = "buttonSearchSolutionFile";
            this.buttonSearchSolutionFile.Size = new System.Drawing.Size(58, 23);
            this.buttonSearchSolutionFile.TabIndex = 0;
            this.buttonSearchSolutionFile.Text = "Browse";
            this.buttonSearchSolutionFile.UseVisualStyleBackColor = true;
            this.buttonSearchSolutionFile.Click += new System.EventHandler(this.buttonSearchSolutionFile_Click);
            // 
            // textBoxSolutionFile
            // 
            this.textBoxSolutionFile.Location = new System.Drawing.Point(95, 26);
            this.textBoxSolutionFile.Name = "textBoxSolutionFile";
            this.textBoxSolutionFile.Size = new System.Drawing.Size(491, 20);
            this.textBoxSolutionFile.TabIndex = 1;
            this.textBoxSolutionFile.TextChanged += new System.EventHandler(this.textBoxSolutionFile_TextChanged);
            // 
            // labelSolutionFile
            // 
            this.labelSolutionFile.AutoSize = true;
            this.labelSolutionFile.Location = new System.Drawing.Point(14, 31);
            this.labelSolutionFile.Name = "labelSolutionFile";
            this.labelSolutionFile.Size = new System.Drawing.Size(61, 13);
            this.labelSolutionFile.TabIndex = 2;
            this.labelSolutionFile.Text = "SolutionFile";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(597, 260);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelMSBuildPath
            // 
            this.labelMSBuildPath.AutoSize = true;
            this.labelMSBuildPath.Location = new System.Drawing.Point(14, 22);
            this.labelMSBuildPath.Name = "labelMSBuildPath";
            this.labelMSBuildPath.Size = new System.Drawing.Size(70, 13);
            this.labelMSBuildPath.TabIndex = 6;
            this.labelMSBuildPath.Text = "MSBuild path";
            // 
            // textBoxMSBuildPath
            // 
            this.textBoxMSBuildPath.Location = new System.Drawing.Point(95, 19);
            this.textBoxMSBuildPath.Name = "textBoxMSBuildPath";
            this.textBoxMSBuildPath.Size = new System.Drawing.Size(491, 20);
            this.textBoxMSBuildPath.TabIndex = 5;
            this.textBoxMSBuildPath.TextChanged += new System.EventHandler(this.textBoxMSBuildPath_TextChanged);
            // 
            // buttonBrowseMSBuild
            // 
            this.buttonBrowseMSBuild.Location = new System.Drawing.Point(592, 17);
            this.buttonBrowseMSBuild.Name = "buttonBrowseMSBuild";
            this.buttonBrowseMSBuild.Size = new System.Drawing.Size(58, 23);
            this.buttonBrowseMSBuild.TabIndex = 4;
            this.buttonBrowseMSBuild.Text = "Browse";
            this.buttonBrowseMSBuild.UseVisualStyleBackColor = true;
            this.buttonBrowseMSBuild.Click += new System.EventHandler(this.buttonBrowseMSBuild_Click);
            // 
            // labelMSTestPath
            // 
            this.labelMSTestPath.AutoSize = true;
            this.labelMSTestPath.Location = new System.Drawing.Point(14, 48);
            this.labelMSTestPath.Name = "labelMSTestPath";
            this.labelMSTestPath.Size = new System.Drawing.Size(68, 13);
            this.labelMSTestPath.TabIndex = 9;
            this.labelMSTestPath.Text = "MSTest path";
            // 
            // textBoxMSTestPath
            // 
            this.textBoxMSTestPath.Location = new System.Drawing.Point(95, 45);
            this.textBoxMSTestPath.Name = "textBoxMSTestPath";
            this.textBoxMSTestPath.Size = new System.Drawing.Size(491, 20);
            this.textBoxMSTestPath.TabIndex = 8;
            this.textBoxMSTestPath.TextChanged += new System.EventHandler(this.textBoxMSTestPath_TextChanged);
            // 
            // buttonBrowseMSTestPath
            // 
            this.buttonBrowseMSTestPath.Location = new System.Drawing.Point(592, 43);
            this.buttonBrowseMSTestPath.Name = "buttonBrowseMSTestPath";
            this.buttonBrowseMSTestPath.Size = new System.Drawing.Size(58, 23);
            this.buttonBrowseMSTestPath.TabIndex = 7;
            this.buttonBrowseMSTestPath.Text = "Browse";
            this.buttonBrowseMSTestPath.UseVisualStyleBackColor = true;
            this.buttonBrowseMSTestPath.Click += new System.EventHandler(this.buttonBrowseMSTestPath_Click);
            // 
            // labelPartCoverPath
            // 
            this.labelPartCoverPath.AutoSize = true;
            this.labelPartCoverPath.Location = new System.Drawing.Point(14, 74);
            this.labelPartCoverPath.Name = "labelPartCoverPath";
            this.labelPartCoverPath.Size = new System.Drawing.Size(78, 13);
            this.labelPartCoverPath.TabIndex = 12;
            this.labelPartCoverPath.Text = "PartCover path";
            // 
            // textBoxPartcoverPath
            // 
            this.textBoxPartcoverPath.Location = new System.Drawing.Point(95, 71);
            this.textBoxPartcoverPath.Name = "textBoxPartcoverPath";
            this.textBoxPartcoverPath.Size = new System.Drawing.Size(491, 20);
            this.textBoxPartcoverPath.TabIndex = 11;
            this.textBoxPartcoverPath.TextChanged += new System.EventHandler(this.textBoxPartcoverPath_TextChanged);
            // 
            // buttonBrowsePartcoverPath
            // 
            this.buttonBrowsePartcoverPath.Location = new System.Drawing.Point(592, 69);
            this.buttonBrowsePartcoverPath.Name = "buttonBrowsePartcoverPath";
            this.buttonBrowsePartcoverPath.Size = new System.Drawing.Size(58, 23);
            this.buttonBrowsePartcoverPath.TabIndex = 10;
            this.buttonBrowsePartcoverPath.Text = "Browse";
            this.buttonBrowsePartcoverPath.UseVisualStyleBackColor = true;
            this.buttonBrowsePartcoverPath.Click += new System.EventHandler(this.buttonBrowsePartcoverPath_Click);
            // 
            // groupBoxEnvironmentSettings
            // 
            this.groupBoxEnvironmentSettings.Controls.Add(this.textBoxMSBuildPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.labelPartCoverPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.buttonBrowseMSBuild);
            this.groupBoxEnvironmentSettings.Controls.Add(this.textBoxPartcoverPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.labelMSBuildPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.buttonBrowsePartcoverPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.buttonBrowseMSTestPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.labelMSTestPath);
            this.groupBoxEnvironmentSettings.Controls.Add(this.textBoxMSTestPath);
            this.groupBoxEnvironmentSettings.Location = new System.Drawing.Point(12, 154);
            this.groupBoxEnvironmentSettings.Name = "groupBoxEnvironmentSettings";
            this.groupBoxEnvironmentSettings.Size = new System.Drawing.Size(660, 100);
            this.groupBoxEnvironmentSettings.TabIndex = 13;
            this.groupBoxEnvironmentSettings.TabStop = false;
            this.groupBoxEnvironmentSettings.Text = "Environment Settings";
            // 
            // groupBoxPersonalSettings
            // 
            this.groupBoxPersonalSettings.Controls.Add(this.label4);
            this.groupBoxPersonalSettings.Controls.Add(this.label5);
            this.groupBoxPersonalSettings.Controls.Add(this.textBoxTimerDuration);
            this.groupBoxPersonalSettings.Controls.Add(this.labelWorkingDirectory);
            this.groupBoxPersonalSettings.Controls.Add(this.textBoxBasePath);
            this.groupBoxPersonalSettings.Controls.Add(this.checkBox1);
            this.groupBoxPersonalSettings.Controls.Add(this.label3);
            this.groupBoxPersonalSettings.Controls.Add(this.label2);
            this.groupBoxPersonalSettings.Controls.Add(this.label1);
            this.groupBoxPersonalSettings.Controls.Add(this.textBoxCompileMinutes);
            this.groupBoxPersonalSettings.Controls.Add(this.labelSolutionFile);
            this.groupBoxPersonalSettings.Controls.Add(this.buttonSearchSolutionFile);
            this.groupBoxPersonalSettings.Controls.Add(this.textBoxSolutionFile);
            this.groupBoxPersonalSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPersonalSettings.Name = "groupBoxPersonalSettings";
            this.groupBoxPersonalSettings.Size = new System.Drawing.Size(660, 136);
            this.groupBoxPersonalSettings.TabIndex = 14;
            this.groupBoxPersonalSettings.TabStop = false;
            this.groupBoxPersonalSettings.Text = "Personal Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Timer set to";
            // 
            // textBoxTimerDuration
            // 
            this.textBoxTimerDuration.Location = new System.Drawing.Point(95, 52);
            this.textBoxTimerDuration.Name = "textBoxTimerDuration";
            this.textBoxTimerDuration.Size = new System.Drawing.Size(37, 20);
            this.textBoxTimerDuration.TabIndex = 10;
            // 
            // labelWorkingDirectory
            // 
            this.labelWorkingDirectory.AutoSize = true;
            this.labelWorkingDirectory.Location = new System.Drawing.Point(14, 85);
            this.labelWorkingDirectory.Name = "labelWorkingDirectory";
            this.labelWorkingDirectory.Size = new System.Drawing.Size(63, 13);
            this.labelWorkingDirectory.TabIndex = 9;
            this.labelWorkingDirectory.Text = "Output path";
            // 
            // textBoxBasePath
            // 
            this.textBoxBasePath.Location = new System.Drawing.Point(95, 82);
            this.textBoxBasePath.Name = "textBoxBasePath";
            this.textBoxBasePath.Size = new System.Drawing.Size(491, 20);
            this.textBoxBasePath.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(95, 108);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cleanup?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "minutes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Compile every";
            // 
            // textBoxCompileMinutes
            // 
            this.textBoxCompileMinutes.Location = new System.Drawing.Point(317, 52);
            this.textBoxCompileMinutes.Name = "textBoxCompileMinutes";
            this.textBoxCompileMinutes.Size = new System.Drawing.Size(37, 20);
            this.textBoxCompileMinutes.TabIndex = 3;
            // 
            // FormConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 292);
            this.Controls.Add(this.groupBoxPersonalSettings);
            this.Controls.Add(this.groupBoxEnvironmentSettings);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConfigure";
            this.ShowInTaskbar = false;
            this.Text = "FormConfigure";
            this.groupBoxEnvironmentSettings.ResumeLayout(false);
            this.groupBoxEnvironmentSettings.PerformLayout();
            this.groupBoxPersonalSettings.ResumeLayout(false);
            this.groupBoxPersonalSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchSolutionFile;
        private System.Windows.Forms.TextBox textBoxSolutionFile;
        private System.Windows.Forms.Label labelSolutionFile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelMSBuildPath;
        private System.Windows.Forms.TextBox textBoxMSBuildPath;
        private System.Windows.Forms.Button buttonBrowseMSBuild;
        private System.Windows.Forms.Label labelMSTestPath;
        private System.Windows.Forms.TextBox textBoxMSTestPath;
        private System.Windows.Forms.Button buttonBrowseMSTestPath;
        private System.Windows.Forms.Label labelPartCoverPath;
        private System.Windows.Forms.TextBox textBoxPartcoverPath;
        private System.Windows.Forms.Button buttonBrowsePartcoverPath;
        private System.Windows.Forms.GroupBox groupBoxEnvironmentSettings;
        private System.Windows.Forms.GroupBox groupBoxPersonalSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCompileMinutes;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelWorkingDirectory;
        private System.Windows.Forms.TextBox textBoxBasePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTimerDuration;
    }
}