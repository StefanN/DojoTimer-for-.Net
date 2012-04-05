using System;
using System.Collections.Generic;

namespace ContinuousClientIntegration.Business.Coverage
{
    public class CoveredAssemblySet : List<CoveredAssembly>
    {
        public int CodeSize
        {
            get
            {
                int total = 0;

                foreach (CoveredAssembly assembly in this)
                {
                    total += assembly.CodeSize;
                }
                return total;

            }
        }
        public int CoveredCodeSize
        {
            get
            {
                int total = 0;

                foreach (CoveredAssembly assembly in this)
                {
                    total += assembly.CoveredCodeSize;
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


    }
}
