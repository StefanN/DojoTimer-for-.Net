using System;
using System.IO;
using System.Xml;
using ContinuousClientIntegration.Business.Config;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using ContinuousClientIntegration.Business.Coverage;

namespace ContinuousClientIntegration.Business.Statistics
{
    public class StatisticsLogger
    {

        public void LogStatistics(Settings settings, ProcessResult result)
        {
            DateTime now = DateTime.Now;
            string path = GetLogFilePath(now, settings);
            string timestamp = GetTimeStamp(now);

            XmlDocument doc = GetXmlDocument(path);
            XmlNode root = GetRootNode(doc);

            AppendTimestampNode(result, timestamp, doc, root);

            Save(doc, path);
        }

        private void LogEvent(Settings settings, string eventName)
        {
            DateTime now = DateTime.Now;
            string path = GetLogFilePath(now, settings);
            string timestamp = GetTimeStamp(now);

            XmlDocument doc = GetXmlDocument(path);
            XmlNode root = GetRootNode(doc);

            AppendEventNode(eventName, timestamp, doc, root);

            Save(doc, path);
        }


        protected virtual void Save(XmlDocument doc, string path)
        {
            doc.Save(path);
        }

        public static string GetTimeStamp(DateTime now)
        {
            string timestamp = now.Year.ToString() + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0');
            timestamp += "_" + now.Hour.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0') + now.Second.ToString().PadLeft(2, '0');
            return timestamp;
        }

        public static string GetLogFilePath(DateTime now, Settings settings)
        {
            string fileName = now.Year.ToString() + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + ".xml";
            string path = System.IO.Path.Combine(settings.BasePath, fileName);
            return path;
        }

        public void LogEvent_StartTimer(Settings settings)
        {
            LogEvent(settings, "starttimer");
        }

        public void LogEvent_EndTimer(Settings settings)
        {
            LogEvent(settings, "endtimer");
        }

        public void LogEvent_BuildSuccess(Settings settings)
        {
            LogEvent(settings, "buildsuccess");
        }

        public void LogEvent_BuildFailure(Settings settings)
        {
            LogEvent(settings, "buildfailure");
        }

        protected virtual XmlDocument GetXmlDocument(string path)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(path))
            {
                doc.Load(path);
            }
            return doc;
        }

        private XmlNode GetRootNode(XmlDocument doc)
        {

            XmlNode root = doc.SelectSingleNode("timestamps");

            if (root == null)
            {
                root = doc.CreateElement("timestamps");
                doc.AppendChild(root);
            }

            return root;
        }


        private void AppendEventNode(string eventtype, string timestamp, XmlDocument doc, XmlNode root)
        {
            XmlNode timestampNode = AppendTimeStampNode(timestamp, doc, root);

            XmlNode eventNode = doc.CreateElement("event");
            XmlAttribute eventtypeAttribute = doc.CreateAttribute("type");
            eventNode.Attributes.Append(eventtypeAttribute);

            timestampNode.AppendChild(eventNode);
            eventtypeAttribute.Value = eventtype;
        }

        private XmlNode AppendTimeStampNode(string timestamp, XmlDocument doc, XmlNode root)
        {
            XmlNode timestampNode = doc.CreateElement("timestamp");
            timestampNode.Attributes.Append(doc.CreateAttribute("value"));
            timestampNode.Attributes["value"].Value = timestamp;
            root.AppendChild(timestampNode);
            return timestampNode;
        }

        private void AppendTimestampNode(ProcessResult result, string timestamp, XmlDocument doc, XmlNode root)
        {
            XmlNode timestampNode = AppendTimeStampNode(timestamp, doc, root);

            if (result.TestResults.CoveredAssemblies != null)
            {
                foreach (CoveredAssembly assembly in result.TestResults.CoveredAssemblies)
                {
                    XmlNode assemblyNode = doc.CreateElement("assembly");
                    XmlAttribute id = doc.CreateAttribute("id");
                    XmlAttribute cs = doc.CreateAttribute("cs");
                    XmlAttribute cov = doc.CreateAttribute("cov");
                    assemblyNode.Attributes.Append(id);
                    assemblyNode.Attributes.Append(cs);
                    assemblyNode.Attributes.Append(cov);
                    timestampNode.AppendChild(assemblyNode);
                    id.Value = assembly.Name;
                    cov.Value = assembly.GetCoverage().ToString();
                    cs.Value = assembly.CodeSize.ToString();
                }
            }
        }

    }
}
