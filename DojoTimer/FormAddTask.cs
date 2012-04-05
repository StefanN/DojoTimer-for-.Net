using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DojoTimer
{
    public partial class FormAddTask : Form
    {
        public FormAddTask()
        {
            InitializeComponent();
        }
        private ObservableTaskCollection _tasks;
        public FormAddTask(ObservableTaskCollection tasks) : this()
        {
            this._tasks = tasks;
        }

        private void FormAddTask_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyValue.ToString());
            this.Close();
        }

        const int C_KEY_ESCAPE = 27;
        const int C_KEY_ENTER = 13;
        const int C_TASK_MAXLENGTH = 35;

        private void DisplaySize()
        {
            int size = (C_TASK_MAXLENGTH - this.textBox1.Text.Length);
            this.labelMaxSize.Text = size.ToString();

            if (size < 0)
            {
                this.labelMaxSize.ForeColor = Color.Red;
            }
            else
            {
                this.labelMaxSize.ForeColor = Color.Black;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == C_KEY_ESCAPE)
            {
                this.Close();
            }

            if (e.KeyValue == C_KEY_ENTER)
            {
                _tasks.Add(this.textBox1.Text);
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DisplaySize();
        }
    }
}
