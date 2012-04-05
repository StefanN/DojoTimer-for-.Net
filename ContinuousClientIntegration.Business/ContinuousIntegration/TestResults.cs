using System.Collections.Generic;
using ContinuousClientIntegration.Business.Coverage;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class TestResults
    {
        public TestResults()
        {
            FailingTests = new List<string>();
            this.Outcome = string.Empty;
            this.CountExecuted = 0;
            this.CountFailed = 0;
            this.CountPassed = 0;

            CoveredAssemblies = null;
        }

        public CoveredAssemblySet CoveredAssemblies { get; set; }

        public List<string> FailingTests { get; private set; }

        public string Outcome { get; set; }

        public int CountExecuted { get; set; }

        public int CountPassed { get; set; }

        public int CountFailed { get; set; }

        public ExitCode ResultCode { get; set; }
    }
}
