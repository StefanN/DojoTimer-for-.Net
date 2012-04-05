using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class TestResultsTests
    {
        [TestMethod]
        public void SettersAndGetters()
        {
            TestResults t = new TestResults();
            t.CountExecuted = 2;
            t.CountFailed = 5;
            t.CountPassed = 4;
            t.Outcome = "Completed";

            Assert.AreEqual(2, t.CountExecuted);
            Assert.AreEqual(5, t.CountFailed);
            Assert.AreEqual(4, t.CountPassed);
            Assert.AreEqual("Completed", t.Outcome);
        }
        
        [TestMethod]
        public void DefaultValues()
        {
            TestResults t = new TestResults();
   
            Assert.AreEqual(0, t.CountExecuted);
            Assert.AreEqual(0, t.CountFailed);
            Assert.AreEqual(0, t.CountPassed);
            Assert.AreEqual(string.Empty, t.Outcome);
            Assert.IsNotNull(t.FailingTests);
            Assert.IsNull(t.CoveredAssemblies);
        }
               

    }
}
