using System;
using System.Collections.Generic;

namespace ContinuousClientIntegration.Business.Coverage
{
    public class CoveredAssembly
    {
        public string Name { get; set; }
        public int CodeSize
        {
            get
            {
                int total = 0;
                foreach (CoveredMethod m in Methods)
                {
                    total += m.CodeSize;
                }
                return total;
            }
        }
        public int CoveredCodeSize
        {
            get
            {
                int total = 0;
                foreach (CoveredMethod m in Methods)
                {
                    total += m.CoveredCodeSize;
                }
                return total;

            }
        }


        public double GetCoverage()
        {

            int codeSize = CodeSize;
            if (codeSize == 0)
            {
                return 0;
            }

            return Math.Round(100 * (double)(CoveredCodeSize / (double)codeSize));

        }


        public List<CoveredMethod> Methods { get; set; }
        public CoveredAssembly()
        {
            Methods = new List<CoveredMethod>();
        }
    }
}
