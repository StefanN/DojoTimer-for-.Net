using System.IO;
using System.Reflection;
using System.Xml;
using ContinuousClientIntegration.Business.Coverage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class CoveredAssemblySetTests
    {

        [TestMethod]
        public void AnalyzeCoverage_ThreeAssemblies_10percentCoverage()
        {
            string path = "ContinuousClientIntegration.Business.Tests.TestFiles.partcoverresults_1.xml";
                          
            Assembly a = Assembly.GetExecutingAssembly();
            XmlDocument doc = new XmlDocument();

            using (Stream s = a.GetManifestResourceStream(path))
            {
                doc.Load(s);
            }
            
            CoveredAssemblySet assemblies = CoverageAnalyzer.AnalyzeCoverage(doc);
            Assert.AreEqual(3, assemblies.Count);

            Assert.AreEqual(0, assemblies[0].GetCoverage());
            Assert.AreEqual(100, assemblies[1].GetCoverage());
            Assert.AreEqual(70, assemblies[2].GetCoverage());

            Assert.AreEqual(10, assemblies.GetCoverage());

        }
    }

  }
