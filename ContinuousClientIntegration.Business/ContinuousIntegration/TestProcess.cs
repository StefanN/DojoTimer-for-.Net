using System.Diagnostics;
using System.IO;
using ContinuousClientIntegration.Business.Config;
using ContinuousClientIntegration.Business.Coverage;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class TestProcess : BaseProcess
    {
        public TestProcess(Settings settings)
            : base(settings)
        {

        }

        public override ProcessResult Process()
        {
            string[] fileNames = Directory.GetFiles(_settings.OutputPath, "*tests.dll");
            ProcessResult result = new ProcessResult();
            result.TestResults = TestMultipleAssemblies(fileNames);
            result.ResultCode = result.TestResults.ResultCode;
            return result;
        }


        private TestResults TestMultipleAssemblies(string[] fileNames)
        {
            ProcessStartInfo startInfo = null;
            if (_settings.UseCoverage)
            {
                startInfo = ProcessStartInfoFactory.CreateTestAndCoverageProcessStartInfo(_settings, fileNames);
            }
            else
            {
                startInfo = ProcessStartInfoFactory.CreateTestProcessStartInfo(_settings, fileNames);
            }

            int exitCode = ExecuteProcess(startInfo);

            string logfile = _settings.GetTestLogPath();
            TestResults testResults = TestResultsInterpreter.InterpretTestResults(logfile);
            
            if (_settings.UseCoverage)
            {
                testResults.CoveredAssemblies = CoverageAnalyzer.AnalyzeCoverage(Path.Combine(_settings.OutputPath, _settings.CoverageLogFileName));
            }

            if (testResults.FailingTests.Count == 0 && exitCode == 0)
            {
                testResults.ResultCode = ExitCode.Success;
            }
            else
            {
                testResults.ResultCode = ExitCode.Failure;
            }

            return testResults;
        }
    }
}
