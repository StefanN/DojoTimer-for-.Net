using System.Diagnostics;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class CompileProcess : BaseProcess
    {

        public CompileProcess(Settings settings)
            : base(settings)
        {

        }

        public override ProcessResult Process()
        {
            ExitCode resultvalue = Compile();
            ProcessResult result = new ProcessResult() { ResultCode = resultvalue };
            return result;
        }

        private ExitCode Compile()
        {
            ProcessStartInfo startInfo = ProcessStartInfoFactory.CreateCompileProcessStartInfo(_settings);
            int exitCode = ExecuteProcess(startInfo);

            if (exitCode == 0)
            {
                return ExitCode.Success;
            }
            return ExitCode.Failure;
        }
    }
}
