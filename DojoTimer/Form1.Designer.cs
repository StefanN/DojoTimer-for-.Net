namespace DojoTimer
{
    partial class Form1
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
            this.buttonRestartTimer = new System.Windows.Forms.Button();
            this.labelTimerLarge = new System.Windows.Forms.Label();
            this.buttonContinuousTesting = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTimerSmall = new System.Windows.Forms.Label();
            this.panelSmall = new System.Windows.Forms.Panel();
            this.labelCurrentTaskSmall = new System.Windows.Forms.Label();
            this.buttonContinuousTesting2 = new System.Windows.Forms.Button();
            this.panelLarge = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSessionLog = new System.Windows.Forms.Button();
            this.buttonTaskList = new System.Windows.Forms.Button();
            this.buttonStatusReport = new System.Windows.Forms.Button();
            this.labelCurrentTaskLarge = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelSmall.SuspendLayout();
            this.panelLarge.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRestartTimer
            // 
            this.buttonRestartTimer.Location = new System.Drawing.Point(175, 3);
            this.buttonRestartTimer.Name = "buttonRestartTimer";
            this.buttonRestartTimer.Size = new System.Drawing.Size(54, 23);
            this.buttonRestartTimer.TabIndex = 1;
            this.buttonRestartTimer.Text = "Restart";
            this.buttonRestartTimer.UseVisualStyleBackColor = true;
            this.buttonRestartTimer.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTimerLarge
            // 
            this.labelTimerLarge.AutoSize = true;
            this.labelTimerLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerLarge.Location = new System.Drawing.Point(-10, -4);
            this.labelTimerLarge.Name = "labelTimerLarge";
            this.labelTimerLarge.Size = new System.Drawing.Size(145, 55);
            this.labelTimerLarge.TabIndex = 4;
            this.labelTimerLarge.Text = "07:00";
            // 
            // buttonContinuousTesting
            // 
            this.buttonContinuousTesting.Location = new System.Drawing.Point(131, 3);
            this.buttonContinuousTesting.Name = "buttonContinuousTesting";
            this.buttonContinuousTesting.Size = new System.Drawing.Size(38, 39);
            this.buttonContinuousTesting.TabIndex = 5;
            this.buttonContinuousTesting.Text = "Test";
            this.buttonContinuousTesting.UseVisualStyleBackColor = true;
            this.buttonContinuousTesting.Click += new System.EventHandler(this.buttonContinuousTesting_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(350, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.viewToolStripMenuItem.Text = "Switch View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // labelTimerSmall
            // 
            this.labelTimerSmall.AutoSize = true;
            this.labelTimerSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerSmall.Location = new System.Drawing.Point(275, 0);
            this.labelTimerSmall.Name = "labelTimerSmall";
            this.labelTimerSmall.Size = new System.Drawing.Size(71, 29);
            this.labelTimerSmall.TabIndex = 8;
            this.labelTimerSmall.Text = "07:00";
            // 
            // panelSmall
            // 
            this.panelSmall.Controls.Add(this.labelCurrentTaskSmall);
            this.panelSmall.Controls.Add(this.buttonContinuousTesting2);
            this.panelSmall.Controls.Add(this.labelTimerSmall);
            this.panelSmall.Location = new System.Drawing.Point(3, 26);
            this.panelSmall.Name = "panelSmall";
            this.panelSmall.Size = new System.Drawing.Size(347, 28);
            this.panelSmall.TabIndex = 9;
            // 
            // labelCurrentTaskSmall
            // 
            this.labelCurrentTaskSmall.AutoSize = true;
            this.labelCurrentTaskSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTaskSmall.Location = new System.Drawing.Point(4, 6);
            this.labelCurrentTaskSmall.Name = "labelCurrentTaskSmall";
            this.labelCurrentTaskSmall.Size = new System.Drawing.Size(242, 16);
            this.labelCurrentTaskSmall.TabIndex = 11;
            this.labelCurrentTaskSmall.Text = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
            // 
            // buttonContinuousTesting2
            // 
            this.buttonContinuousTesting2.Location = new System.Drawing.Point(256, 3);
            this.buttonContinuousTesting2.Name = "buttonContinuousTesting2";
            this.buttonContinuousTesting2.Size = new System.Drawing.Size(22, 23);
            this.buttonContinuousTesting2.TabIndex = 10;
            this.buttonContinuousTesting2.Text = "T";
            this.buttonContinuousTesting2.UseVisualStyleBackColor = true;
            this.buttonContinuousTesting2.Click += new System.EventHandler(this.buttonContinuousTesting2_Click);
            // 
            // panelLarge
            // 
            this.panelLarge.Controls.Add(this.panel1);
            this.panelLarge.Controls.Add(this.labelCurrentTaskLarge);
            this.panelLarge.Controls.Add(this.buttonRestartTimer);
            this.panelLarge.Controls.Add(this.buttonContinuousTesting);
            this.panelLarge.Controls.Add(this.labelTimerLarge);
            this.panelLarge.Location = new System.Drawing.Point(3, 61);
            this.panelLarge.Name = "panelLarge";
            this.panelLarge.Size = new System.Drawing.Size(347, 100);
            this.panelLarge.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.buttonSessionLog);
            this.panel1.Controls.Add(this.buttonTaskList);
            this.panel1.Controls.Add(this.buttonStatusReport);
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 30);
            this.panel1.TabIndex = 11;
            // 
            // buttonSessionLog
            // 
            this.buttonSessionLog.Location = new System.Drawing.Point(176, 3);
            this.buttonSessionLog.Name = "buttonSessionLog";
            this.buttonSessionLog.Size = new System.Drawing.Size(71, 23);
            this.buttonSessionLog.TabIndex = 10;
            this.buttonSessionLog.Text = "SessionLog";
            this.buttonSessionLog.UseVisualStyleBackColor = true;
            this.buttonSessionLog.Click += new System.EventHandler(this.buttonSessionLog_Click);
            // 
            // buttonTaskList
            // 
            this.buttonTaskList.Location = new System.Drawing.Point(4, 3);
            this.buttonTaskList.Name = "buttonTaskList";
            this.buttonTaskList.Size = new System.Drawing.Size(74, 23);
            this.buttonTaskList.TabIndex = 7;
            this.buttonTaskList.Text = "Task List";
            this.buttonTaskList.UseVisualStyleBackColor = true;
            this.buttonTaskList.Click += new System.EventHandler(this.buttonTaskList_Click);
            // 
            // buttonStatusReport
            // 
            this.buttonStatusReport.Location = new System.Drawing.Point(84, 3);
            this.buttonStatusReport.Name = "buttonStatusReport";
            this.buttonStatusReport.Size = new System.Drawing.Size(86, 23);
            this.buttonStatusReport.TabIndex = 8;
            this.buttonStatusReport.Text = "Status Report";
            this.buttonStatusReport.UseVisualStyleBackColor = true;
            this.buttonStatusReport.Click += new System.EventHandler(this.buttonStatusReport_Click);
            // 
            // labelCurrentTaskLarge
            // 
            this.labelCurrentTaskLarge.AutoSize = true;
            this.labelCurrentTaskLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTaskLarge.Location = new System.Drawing.Point(2, 45);
            this.labelCurrentTaskLarge.Name = "labelCurrentTaskLarge";
            this.labelCurrentTaskLarge.Size = new System.Drawing.Size(323, 18);
            this.labelCurrentTaskLarge.TabIndex = 9;
            this.labelCurrentTaskLarge.Text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 165);
            this.Controls.Add(this.panelLarge);
            this.Controls.Add(this.panelSmall);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DojoTimer";
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSmall.ResumeLayout(false);
            this.panelSmall.PerformLayout();
            this.panelLarge.ResumeLayout(false);
            this.panelLarge.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRestartTimer;
        private System.Windows.Forms.Label labelTimerLarge;
        private System.Windows.Forms.Button buttonContinuousTesting;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label labelTimerSmall;
        private System.Windows.Forms.Panel panelSmall;
        private System.Windows.Forms.Label labelCurrentTaskSmall;
        private System.Windows.Forms.Button buttonContinuousTesting2;
        private System.Windows.Forms.Panel panelLarge;
        private System.Windows.Forms.Button buttonStatusReport;
        private System.Windows.Forms.Button buttonTaskList;
        private System.Windows.Forms.Label labelCurrentTaskLarge;
        private System.Windows.Forms.Button buttonSessionLog;
        private System.Windows.Forms.Panel panel1;
    }
}

