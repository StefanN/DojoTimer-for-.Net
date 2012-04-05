using System;
using System.Xml;
using ContinuousClientIntegration.Business.Config;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using ContinuousClientIntegration.Business.Coverage;
using ContinuousClientIntegration.Business.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class StatisticsLoggerTests
    {
        [TestMethod]
        public void LogEvent_EndTimer_AddEvent_EventAdded()
        {
            StatisticsLoggerStub stub = new StatisticsLoggerStub();
            TestEventAdded(stub, stub.LogEvent_EndTimer, "endtimer");
        }


        [TestMethod]
        public void LogEvent_StartTimer_AddEvent_EventAdded()
        {
            StatisticsLoggerStub stub = new StatisticsLoggerStub();
            TestEventAdded(stub, stub.LogEvent_StartTimer, "starttimer");
        }

        [TestMethod]
        public void LogEvent_BuildSuccess_AddEvent_EventAdded()
        {
            StatisticsLoggerStub stub = new StatisticsLoggerStub();
            TestEventAdded(stub, stub.LogEvent_BuildSuccess, "buildsuccess");
        }

        [TestMethod]
        public void LogEvent_BuildFailure_AddEvent_EventAdded()
        {
            StatisticsLoggerStub stub = new StatisticsLoggerStub();
            TestEventAdded(stub, stub.LogEvent_BuildFailure, "buildfailure");
        }

        [TestMethod]
        public void LogEvent_BuildFailure_AddEvent_EvellntAdded()
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";

            StatisticsLoggerStub stub = new StatisticsLoggerStub();
            
            ProcessResult r = new ProcessResult();
            r.TestResults.CoveredAssemblies = new CoveredAssemblySet();
            CoveredAssembly assembly = new CoveredAssembly();
            assembly.Name = "thename";
            r.TestResults.CoveredAssemblies.Add(assembly);
            
            stub.LogStatistics(settings, r);

            Assert.AreEqual(1, stub.XmlDocument.SelectNodes("timestamps/timestamp/assembly[@id='thename']").Count);
            Assert.IsTrue(stub.IsSaved);
        }

        [TestMethod]
        public void GetTimeStamp_RegularDate_ValidValue()
        {
            DateTime now = new DateTime(2010, 11, 24, 13, 55, 44);
            string result = StatisticsLogger.GetTimeStamp(now);
            Assert.AreEqual("20101124_135544", result);
        }

        [TestMethod]
        public void GetLogFilePath_RegularDate_ValidValue()
        {
            DateTime now = new DateTime(2010, 11, 24, 13, 55, 44);
            Settings settings = new Settings() { BasePath = @"c:\" };
            
            string result = StatisticsLogger.GetLogFilePath(now, settings);
            Assert.AreEqual(@"c:\20101124.xml", result);
        }


        delegate void LogEvent(Settings settings);

        private void TestEventAdded(StatisticsLoggerStub stub, LogEvent ev, string eventtype)
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";

            ev(settings);

            XmlDocument result = stub.XmlDocument;

            string xpath = string.Format("timestamps/timestamp/event[@type='{0}']", eventtype);
            XmlNodeList nodes = result.SelectNodes(xpath);

            Assert.AreEqual(1, nodes.Count);

            Assert.IsTrue(stub.IsSaved);
        }



    }

    public class StatisticsLoggerStub : StatisticsLogger
    {
        public bool IsSaved { get; set; }
        public XmlDocument XmlDocument { get; set; }
        protected override System.Xml.XmlDocument GetXmlDocument(string path)
        {
            this.XmlDocument = new XmlDocument();
            return this.XmlDocument;
        }

        protected override void Save(XmlDocument doc, string path)
        {
            IsSaved = true;
        }
    }
}
