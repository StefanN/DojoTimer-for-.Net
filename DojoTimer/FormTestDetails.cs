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
    public partial class FormTestDetails : Form
    {
        public FormTestDetails()
        {
            InitializeComponent();
        }

        public void SetValues(List<string> list)
        {
            foreach (string item in list)
            {
                this.richTextBox1.AppendText(item + Environment.NewLine);
            }
        }
    }
}
