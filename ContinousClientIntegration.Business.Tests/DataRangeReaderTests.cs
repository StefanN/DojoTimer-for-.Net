using System;
using System.Collections.Generic;
using System.Xml;
using ContinuousClientIntegration.Business.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class DataRangeReaderTests
    {
        [TestMethod]
        public void ParseDate_ValidDate_ValidResult()
        {
            DateTime result = DataRangeReader.ParseDate("20100301_203004");

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(3, result.Month);
            Assert.AreEqual(1, result.Day);
            Assert.AreEqual(20, result.Hour);
            Assert.AreEqual(30, result.Minute);
            Assert.AreEqual(4, result.Second);
        }

        [TestMethod]
        public void ParseDouble_ValidValue_ValidResult()
        {
            double result = DataRangeReader.ParseDouble("70.66");

            Assert.AreEqual(70.66d, result);
        }

        [TestMethod]
        public void ReadDataRangesFromXmlDocument_2Assemblies_4Ranges()
        {

            string xml = string.Empty;
            xml += "<timestamps>";
            xml += string.Format("<timestamp value=\"20100101_203055\">");
            xml += string.Format("<assembly id=\"1\" cs=\"1000\" cov=\"70.5\"/>"); 
            xml += string.Format("<assembly id=\"2\" cs=\"200\" cov=\"80\"/>");
            xml += "</timestamp>";
            xml += string.Format("<timestamp value=\"20100101_203555\">");
            xml += string.Format("<assembly id=\"1\" cs=\"900\" cov=\"79.7\"/>"); 
            xml += string.Format("<assembly id=\"2\" cs=\"300\" cov=\"60\"/>");
            xml += "</timestamp>";
            xml += "</timestamps>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            DataRangeReader reader = new DataRangeReader();
            List<DataRange> ranges = reader.ReadDataRangesFromXmlDocument(doc);

            Assert.AreEqual(4, ranges.Count);


        }
    }
}
