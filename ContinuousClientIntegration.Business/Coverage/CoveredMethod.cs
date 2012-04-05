using System;

namespace ContinuousClientIntegration.Business.Coverage
{
    public class CoveredMethod
    {
        public int CodeSize { get; set; }
        public int CoveredCodeSize { get; set; }
        public string Name { get; set; }
        public double GetCoverage()
        {
            int codeSize = CodeSize;
            if (codeSize == 0)
            {
                return 0;
            }

            return Math.Round(100 * (double)(CoveredCodeSize / (double)codeSize));
        }

        public string TypeName { get; set; }
    }
}
