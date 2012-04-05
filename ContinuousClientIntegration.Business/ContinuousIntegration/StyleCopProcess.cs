using System.Diagnostics;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class StyleCopProcess : BaseProcess
    {
        public StyleCopProcess(Settings settings)
            : base(settings)
        {

        }

        public override ProcessResult Process()
        {
            ExitCode resultvalue = CheckStyle();
            ProcessResult result = new ProcessResult() { ResultCode = resultvalue };
            return result;
        }

        private ExitCode CheckStyle()
        {
            ProcessStartInfo startInfo = ProcessStartInfoFactory.CreateStyleCopProcessStartInfo(_settings);

            int exitCode = 0;
            try
            {
                exitCode = ExecuteProcess(startInfo);
            }
            catch { return ExitCode.Failure; }


            if (exitCode == 0)
            {
                return ExitCode.Success;
            }
            return ExitCode.Failure;
        }
    }
}
