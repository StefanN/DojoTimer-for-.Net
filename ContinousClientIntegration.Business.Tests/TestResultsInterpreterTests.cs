using System.IO;
using System.Reflection;
using System.Xml;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class TestResultsInterpreterTests
    {
        [TestMethod]
        public void InterpretTestResults_PassingTests_PropertiesSet()
        {

            string path = "ContinuousClientIntegration.Business.Tests.TestFiles.testresults_1.xml";
                          
            Assembly a = Assembly.GetExecutingAssembly();
            XmlDocument doc = new XmlDocument();

            using (Stream s = a.GetManifestResourceStream(path))
            {
                doc.Load(s);
            }

            TestResults results = TestResultsInterpreter.InterpretTestResults(doc);

            Assert.AreEqual(18, results.CountPassed);
            Assert.AreEqual(0, results.CountFailed);
            Assert.AreEqual(18, results.CountExecuted);
            Assert.AreEqual(0, results.FailingTests.Count);
            Assert.AreEqual("Completed", results.Outcome);
            Assert.AreEqual(ExitCode.Success, results.ResultCode);

        }


        [TestMethod]
        public void InterpretTestResults_FailingTest_PropertiesSet()
        {

            string path = "ContinuousClientIntegration.Business.Tests.TestFiles.testresults_2.xml";

            Assembly a = Assembly.GetExecutingAssembly();
            XmlDocument doc = new XmlDocument();

            using (Stream s = a.GetManifestResourceStream(path))
            {
                doc.Load(s);
            }

            TestResults results = TestResultsInterpreter.InterpretTestResults(doc);

            Assert.AreEqual(25, results.CountPassed);
            Assert.AreEqual(1, results.CountFailed);
            Assert.AreEqual(26, results.CountExecuted);
            Assert.AreEqual(1, results.FailingTests.Count);
            Assert.AreEqual("Failed", results.Outcome);
            Assert.AreEqual(ExitCode.Failure, results.ResultCode);

        }
    }
}
