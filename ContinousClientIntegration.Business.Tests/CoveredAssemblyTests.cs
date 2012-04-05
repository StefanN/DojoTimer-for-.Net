using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContinuousClientIntegration.Business.Coverage;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class CoveredAssemblyTests
    {
        [TestMethod]
        public void GetCoverage_NoMethods_0()
        {
            CoveredAssembly ca = new CoveredAssembly();
            double coverage = ca.GetCoverage();
            Assert.AreEqual(0, coverage);
        }

        [TestMethod]
        public void GetCoverage_1MethodNoCoverage_0()
        {
            CoveredAssembly ca = new CoveredAssembly();
            ca.Methods.Add(new CoveredMethod() { CodeSize = 100, CoveredCodeSize = 0 });
            double coverage = ca.GetCoverage();
            Assert.AreEqual(0, coverage);
        }

        [TestMethod]
        public void GetCoverage_OneMethodFullCoverage_100()
        {
            CoveredAssembly ca = new CoveredAssembly();
            ca.Methods.Add(new CoveredMethod() { CodeSize = 100, CoveredCodeSize = 100 });
            double coverage = ca.GetCoverage();
            Assert.AreEqual(100, coverage);
        }


        [TestMethod]
        public void GetCoverage_TwoMethodsSomeCoverage_100()
        {
            CoveredAssembly ca = new CoveredAssembly();
            CoveredMethod method1 = new CoveredMethod() { CodeSize = 100, CoveredCodeSize = 100 };
            CoveredMethod method2 = new CoveredMethod() { CodeSize = 100, CoveredCodeSize = 0 };
            ca.Methods.Add(method1);
            ca.Methods.Add(method2);

            double coverage = ca.GetCoverage();
            Assert.AreEqual(50, coverage);
        }
    }
}
