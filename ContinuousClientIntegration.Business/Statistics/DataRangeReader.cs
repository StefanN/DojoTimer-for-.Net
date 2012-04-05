using System;
using System.Collections.Generic;
using System.Xml;

namespace ContinuousClientIntegration.Business.Statistics
{
    public class DataRangeReader
    {

        public static DateTime ParseDate(string date)
        {
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));

            int hours = int.Parse(date.Substring(9, 2));
            int minutes = int.Parse(date.Substring(11, 2));
            int seconds = int.Parse(date.Substring(13, 2));

            return new DateTime(year, month, day, hours, minutes, seconds);

        }

        public List<DataRange> ReadDataRangesFromXmlDocument(XmlDocument doc)
        {
            // <timestamps>
            //  <timestamp value="20100101_203055">
            //    <assembly id="1" cs="1000" cov="70.5"> 
            //    <assembly id="2" cs="200" cov="80">
            //  </timestamp>
            //  <timestamp value="20100101_203500">
            //    <assembly id="1" cs="1000" cov=5"70.5"> 
            //    <assembly id="2" cs="200" cov="80">
            //  </timestamp>
            // </timestamps>

            List<DataRange> ranges = new List<DataRange>();
            Dictionary<string, DataRange> uniqueRanges = new Dictionary<string, DataRange>();

            XmlNodeList nodes = doc.SelectNodes("timestamps/timestamp");

            foreach (XmlNode node in nodes)
            {
                XmlAttribute timestamp = node.Attributes["value"];
                DateTime dt = ParseDate(timestamp.Value);

                XmlNodeList assemblyNodes = node.SelectNodes("assembly");

                foreach (XmlNode assemblyNode in assemblyNodes)
                {
                    string id = assemblyNode.Attributes["id"].Value;

                    if (!uniqueRanges.ContainsKey(id + "_cov"))
                    {
                        uniqueRanges.Add(id + "_cov", new DataRange(id, "Coverage"));
                    }
                    if (!uniqueRanges.ContainsKey(id + "_cs"))
                    {
                        uniqueRanges.Add(id + "_cs", new DataRange(id, "Codesize"));
                    }

                    string cov = assemblyNode.Attributes["cov"].Value;
                    uniqueRanges[id + "_cov"].DataPoints.Add(new DataPoint() { TimeStamp = dt, Value = ParseDouble(cov) });

                    string cs = assemblyNode.Attributes["cs"].Value;
                    uniqueRanges[id + "_cs"].DataPoints.Add(new DataPoint() { TimeStamp = dt, Value = ParseDouble(cs) });
                }
            }

            ranges.AddRange(uniqueRanges.Values);

            return ranges;
        }

        public static double ParseDouble(string value)
        {
            value = value.Replace(".", ",");
            return Double.Parse(value);
        }

        public List<DataRange> ReadEventRangesFromXmlDocument(XmlDocument doc)
        {
            // <timestamps>
            //  <timestamp value="20100101_203055">
            //    <assembly id="1" cs="1000" cov="70.5"> 
            //    <assembly id="2" cs="200" cov="80">
            //      <event type="starttimer">
            //      <event type="endtimer">
            //  </timestamp>
            //  <timestamp value="20100101_203500">
            //    <assembly id="1" cs="1000" cov=5"70.5"> 
            //    <assembly id="2" cs="200" cov="80">
            //  </timestamp>
            // </timestamps>

            List<DataRange> ranges = new List<DataRange>();
            Dictionary<string, DataRange> uniqueRanges = new Dictionary<string, DataRange>();

            XmlNodeList nodes = doc.SelectNodes("timestamps/timestamp");

            int valueInGraph = 110;

            foreach (XmlNode node in nodes)
            {
                XmlAttribute timestamp = node.Attributes["value"];
                DateTime dt = ParseDate(timestamp.Value);
                XmlNodeList assemblyNodes = node.SelectNodes("event");

                foreach (XmlNode assemblyNode in assemblyNodes)
                {
                    string eventtype = assemblyNode.Attributes["type"].Value;

                    if (!uniqueRanges.ContainsKey(eventtype))
                    {
                        uniqueRanges.Add(eventtype, new DataRange(eventtype, eventtype));
                    }
                    
                    uniqueRanges[eventtype].DataPoints.Add(new DataPoint() { TimeStamp = dt, Value = valueInGraph });
                }
            }
            ranges.AddRange(uniqueRanges.Values);

            return ranges;
        }
    }
}
