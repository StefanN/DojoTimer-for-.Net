namespace DojoTimer
{
    partial class FormStatusReport
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
            this.labelTestsPassingCount = new System.Windows.Forms.Label();
            this.labelTestsFailingCount = new System.Windows.Forms.Label();
            this.labelTestsExecutedCount = new System.Windows.Forms.Label();
            this.labelTestsPassing = new System.Windows.Forms.Label();
            this.labelTestsFailing = new System.Windows.Forms.Label();
            this.labelTestsExecuted = new System.Windows.Forms.Label();
            this.groupBoxTests = new System.Windows.Forms.GroupBox();
            this.buttonTestDetails = new System.Windows.Forms.Button();
            this.groupBoxCoverage = new System.Windows.Forms.GroupBox();
            this.listBoxCoverage = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxTests.SuspendLayout();
            this.groupBoxCoverage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTestsPassingCount
            // 
            this.labelTestsPassingCount.AutoSize = true;
            this.labelTestsPassingCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTestsPassingCount.Location = new System.Drawing.Point(64, 29);
            this.labelTestsPassingCount.Name = "labelTestsPassingCount";
            this.labelTestsPassingCount.Size = new System.Drawing.Size(13, 13);
            this.labelTestsPassingCount.TabIndex = 0;
            this.labelTestsPassingCount.Text = "0";
            // 
            // labelTestsFailingCount
            // 
            this.labelTestsFailingCount.AutoSize = true;
            this.labelTestsFailingCount.ForeColor = System.Drawing.Color.Red;
            this.labelTestsFailingCount.Location = new System.Drawing.Point(64, 16);
            this.labelTestsFailingCount.Name = "labelTestsFailingCount";
            this.labelTestsFailingCount.Size = new System.Drawing.Size(13, 13);
            this.labelTestsFailingCount.TabIndex = 1;
            this.labelTestsFailingCount.Text = "0";
            // 
            // labelTestsExecutedCount
            // 
            this.labelTestsExecutedCount.AutoSize = true;
            this.labelTestsExecutedCount.Location = new System.Drawing.Point(64, 42);
            this.labelTestsExecutedCount.Name = "labelTestsExecutedCount";
            this.labelTestsExecutedCount.Size = new System.Drawing.Size(13, 13);
            this.labelTestsExecutedCount.TabIndex = 2;
            this.labelTestsExecutedCount.Text = "0";
            // 
            // labelTestsPassing
            // 
            this.labelTestsPassing.AutoSize = true;
            this.labelTestsPassing.Location = new System.Drawing.Point(6, 29);
            this.labelTestsPassing.Name = "labelTestsPassing";
            this.labelTestsPassing.Size = new System.Drawing.Size(30, 13);
            this.labelTestsPassing.TabIndex = 3;
            this.labelTestsPassing.Text = "Pass";
            // 
            // labelTestsFailing
            // 
            this.labelTestsFailing.AutoSize = true;
            this.labelTestsFailing.Location = new System.Drawing.Point(6, 16);
            this.labelTestsFailing.Name = "labelTestsFailing";
            this.labelTestsFailing.Size = new System.Drawing.Size(23, 13);
            this.labelTestsFailing.TabIndex = 4;
            this.labelTestsFailing.Text = "Fail";
            // 
            // labelTestsExecuted
            // 
            this.labelTestsExecuted.AutoSize = true;
            this.labelTestsExecuted.Location = new System.Drawing.Point(6, 42);
            this.labelTestsExecuted.Name = "labelTestsExecuted";
            this.labelTestsExecuted.Size = new System.Drawing.Size(52, 13);
            this.labelTestsExecuted.TabIndex = 5;
            this.labelTestsExecuted.Text = "Executed";
            // 
            // groupBoxTests
            // 
            this.groupBoxTests.Controls.Add(this.labelTestsFailing);
            this.groupBoxTests.Controls.Add(this.labelTestsExecuted);
            this.groupBoxTests.Controls.Add(this.labelTestsPassingCount);
            this.groupBoxTests.Controls.Add(this.labelTestsFailingCount);
            this.groupBoxTests.Controls.Add(this.labelTestsPassing);
            this.groupBoxTests.Controls.Add(this.labelTestsExecutedCount);
            this.groupBoxTests.Location = new System.Drawing.Point(27, 12);
            this.groupBoxTests.Name = "groupBoxTests";
            this.groupBoxTests.Size = new System.Drawing.Size(306, 63);
            this.groupBoxTests.TabIndex = 6;
            this.groupBoxTests.TabStop = false;
            this.groupBoxTests.Text = "Tests";
            // 
            // buttonTestDetails
            // 
            this.buttonTestDetails.Location = new System.Drawing.Point(8, 22);
            this.buttonTestDetails.Name = "buttonTestDetails";
            this.buttonTestDetails.Size = new System.Drawing.Size(21, 25);
            this.buttonTestDetails.TabIndex = 7;
            this.buttonTestDetails.Text = "<<";
            this.buttonTestDetails.UseVisualStyleBackColor = true;
            this.buttonTestDetails.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxCoverage
            // 
            this.groupBoxCoverage.Controls.Add(this.listBoxCoverage);
            this.groupBoxCoverage.Location = new System.Drawing.Point(27, 81);
            this.groupBoxCoverage.Name = "groupBoxCoverage";
            this.groupBoxCoverage.Size = new System.Drawing.Size(306, 100);
            this.groupBoxCoverage.TabIndex = 8;
            this.groupBoxCoverage.TabStop = false;
            this.groupBoxCoverage.Text = "Coverage";
            // 
            // listBoxCoverage
            // 
            this.listBoxCoverage.Enabled = false;
            this.listBoxCoverage.FormattingEnabled = true;
            this.listBoxCoverage.Location = new System.Drawing.Point(9, 20);
            this.listBoxCoverage.Name = "listBoxCoverage";
            this.listBoxCoverage.Size = new System.Drawing.Size(286, 69);
            this.listBoxCoverage.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormStatusReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 81);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxCoverage);
            this.Controls.Add(this.buttonTestDetails);
            this.Controls.Add(this.groupBoxTests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStatusReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormStatusReport";
            this.groupBoxTests.ResumeLayout(false);
            this.groupBoxTests.PerformLayout();
            this.groupBoxCoverage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTestsPassingCount;
        private System.Windows.Forms.Label labelTestsFailingCount;
        private System.Windows.Forms.Label labelTestsExecutedCount;
        private System.Windows.Forms.Label labelTestsPassing;
        private System.Windows.Forms.Label labelTestsFailing;
        private System.Windows.Forms.Label labelTestsExecuted;
        private System.Windows.Forms.GroupBox groupBoxTests;
        private System.Windows.Forms.Button buttonTestDetails;
        private System.Windows.Forms.GroupBox groupBoxCoverage;
        private System.Windows.Forms.ListBox listBoxCoverage;
        private System.Windows.Forms.Button button1;
    }
}