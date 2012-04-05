
namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class ProcessResult
    {
        public ExitCode ResultCode { get; set; }
        public TestResults TestResults { get; set; }

        public ProcessResult()
        {
            TestResults = new TestResults();
        }
    }

    public enum ExitCode
    {
        Success,
        Failure
    }
}
