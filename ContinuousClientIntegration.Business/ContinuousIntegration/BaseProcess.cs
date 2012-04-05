using System.Diagnostics;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    /// <summary>
    /// base class for the processes that can be started as a continuous integration process
    /// </summary>
    public class BaseProcess
    {
        protected Settings _settings;

        /// <summary>
        /// Initializes a new instance of the BaseProcess class
        /// </summary>
        /// <param name="settings"></param>
        public BaseProcess(Settings settings)
        {
            _settings = settings;
        }

        public virtual ProcessResult Process()
        {
            return new ProcessResult();
        }

        protected virtual int ExecuteProcess(ProcessStartInfo psi)
        {
            int exitCode = -99;
            try
            {
                using (Process exeProcess = System.Diagnostics.Process.Start(psi))
                {
                    exeProcess.WaitForExit();
                    exitCode = exeProcess.ExitCode;
                }
            }
            catch{ }

            return exitCode;
        }
    }

    

}
