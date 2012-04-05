using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace DojoTimer
{
    public class ObservableTaskCollection : List<Task>
    {
        public event EventHandler Changed;
        public event EventHandler CurrentTaskChanged;

        private Task _currentTask;


        public void Add(string value)
        {
            Task newTask = new Task(value);
            Add(newTask);
        }


        public new void Add(Task item)
        {
            base.Add(item);
            OnChanged();
        }

        public new void Remove(Task item)
        {
            if (item == CurrentTask)
            {
                CurrentTask = null;
            }

            base.Remove(item);
            OnChanged();
        }

        private void OnChanged()
        {
            if (Changed != null)
            {
                Save();
                Changed(null, null);
            }
        }

        private void OnCurrentTaskChanged()
        {
            if (CurrentTaskChanged != null)
            {
                Save();
                CurrentTaskChanged(null, null);
            }
        }

        public Task CurrentTask
        {
            get { return _currentTask; }
            set
            {
                _currentTask = value;
                OnCurrentTaskChanged();
            }
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode baseNode = doc.CreateElement("tasks");
            doc.AppendChild(baseNode);

            foreach (Task task in this)
            {
                XmlNode taskNode = doc.CreateElement("task");
                baseNode.AppendChild(taskNode);
                XmlAttribute att = doc.CreateAttribute("text");
                taskNode.Attributes.Append(att);
                att.Value = task.Description;

                if (task == CurrentTask)
                {
                    XmlAttribute attActive = doc.CreateAttribute("active");
                    taskNode.Attributes.Append(attActive);
                    attActive.Value = "True";
                }

            }
            CreateFolderIfItDoesNotExist();
            doc.Save(FileName);
        }

        public void Read()
        {
            if (!File.Exists(FileName))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);

            XmlNodeList nodes = doc.SelectNodes("tasks/task");

            foreach (XmlNode node in nodes)
            {
                string text = node.Attributes["text"].InnerText;

                Task task = new Task(text);

                XmlAttribute a = node.Attributes["active"];
                if (a != null && a.Value=="True" )
                {
                    CurrentTask = task;
                }
                this.Add(task);
            }
        }

        private void CreateFolderIfItDoesNotExist()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DojoTimer");

            if(!Directory.Exists("path"))
            {
                Directory.CreateDirectory(path);
            }
        }


        private string FileName
        {
            get {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DojoTimer");
                return Path.Combine(path, "tasks.xml");
            }
        }
    }
}
