using System.Xml;
using System.IO;

namespace ContinuousClientIntegration.Business.Coverage
{
    public class CoverageAnalyzer
    {
        public static CoveredAssemblySet AnalyzeCoverage(XmlDocument doc)
        {
            XmlNodeList assemblyNodes = doc.SelectNodes("PartCoverReport/Assembly");
            CoveredAssemblySet assemblies = new CoveredAssemblySet();
            foreach (XmlNode assemblyNode in assemblyNodes)
            {
                CoveredAssembly assembly = new CoveredAssembly();
                assemblies.Add(assembly);
                assembly.Name = assemblyNode.Attributes["name"].Value;
                string id = assemblyNode.Attributes["id"].Value;

                string xpath = "//Type[@asmref=" + id + "]/Method";
                XmlNodeList methods = doc.SelectNodes(xpath);

                foreach (XmlNode method in methods)
                {

                    string typeName = method.ParentNode.Attributes["name"].Value;

                    CoveredMethod m = new CoveredMethod();
                    m.Name = method.Attributes["name"].Value;
                    m.TypeName = typeName;
                    assembly.Methods.Add(m);

                    XmlNodeList ptNodes = method.SelectNodes("pt");

                    if (ptNodes.Count == 0)
                    {
                        m.CodeSize += int.Parse(method.Attributes["bodysize"].Value);
                    }
                    else
                    {
                        foreach (XmlNode ptNode in ptNodes)
                        {
                            int length = int.Parse(ptNode.Attributes["len"].Value);
                            int visit = int.Parse(ptNode.Attributes["visit"].Value);
                            m.CodeSize += length;
                            if (visit > 0)
                            {
                                m.CoveredCodeSize += length;
                            }
                        }
                    }
                }
            }
            return assemblies;
        }


        public static CoveredAssemblySet AnalyzeCoverage(string path)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(path))
            {
                doc.Load(path);
                return AnalyzeCoverage(doc);

            }
            return null;
        }

    }
}
