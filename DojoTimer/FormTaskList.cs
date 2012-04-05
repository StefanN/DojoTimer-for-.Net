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
    public partial class FormTaskList : Form
    {
        private ObservableTaskCollection _tasks;
        public FormTaskList(ObservableTaskCollection tasks)
        {
            InitializeComponent();
            _tasks = tasks;
            _tasks.Changed += new EventHandler(_tasks_Changed);

            listView1.View = View.Details;
            listView1.Columns.Add("Description", 210);
            listView1.Columns.Add("Dome", 60);

            UpdateTasks();
        }

        void _tasks_Changed(object sender, EventArgs e)
        {
            UpdateTasks();
        }

        private void UpdateTasks()
        {
            this.listView1.Items.Clear();
            foreach (Task task in _tasks)
            {
                ListViewItem item = new ListViewItem(task.Description);
                item.SubItems.Add(task.Done.ToString());
                this.listView1.Items.Add(item);
            }
        }


        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            FormAddTask add = new FormAddTask(_tasks);
            add.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            var item = lv.FocusedItem;

            if (item != null)
            {
                Task task = _tasks[item.Index];
                _tasks.CurrentTask = task;
            }

        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }

            Point point = new Point(e.X, e.Y);

            if (listView1.GetItemAt(e.X, e.Y) != null)
            {
                this.contextMenuStrip1.Show(listView1, point);
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddTask add = new FormAddTask(_tasks);
            add.ShowDialog();
        }

        private void doneNotDoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = listView1.FocusedItem;

            if (item != null)
            {
                Task task = _tasks[item.Index];
                task.Done = !task.Done;
                item.SubItems[1].Text = task.Done.ToString();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = listView1.FocusedItem;

            if (item != null)
            {
                Task task = _tasks[item.Index];

                _tasks.Remove(task);
            }
        }
    }
}
