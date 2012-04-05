using System;
using System.Collections.Generic;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class ContinuousIntegrationClientProcess
    {
        private Settings _settings;
        private IFileSystem _fileSystem;
        private List<BaseProcess> _processes;

        public ContinuousIntegrationClientProcess(Settings settings)
        {
            _settings = settings;
            _fileSystem = new FileSystem();
            _processes = new List<BaseProcess>();
            _processes.Add(new CompileProcess(_settings));
            _processes.Add(new TestProcess(_settings));
          //  _processes.Add(new StyleCopProcess(_settings));
        }

        /// <summary>
        /// Initializes a new instance of the ContinuousIntegrationClientProcess for testing purposes
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="fileSystem"></param>
        public ContinuousIntegrationClientProcess(Settings settings, IFileSystem fileSystem, List<BaseProcess> processes)
        {
            _settings = settings;
            _fileSystem = fileSystem;
            _processes = processes;
        }

        public ProcessResult Start()
        {
            ProcessResult totalResult = new ProcessResult();

            if (!_fileSystem.DirectoryExists(_settings.BasePath))
            {
                _fileSystem.CreateDirectory(_settings.BasePath);
            }

            string subdir = CreateNewSubdirName(DateTime.Now);
            _settings.UpdateOutputPath(subdir);
            if (!_fileSystem.DirectoryExists(_settings.OutputPath))
            {
                _fileSystem.CreateDirectory(_settings.OutputPath);
            }

            foreach (BaseProcess process in _processes)
            {
                totalResult = process.Process();

                if (totalResult.ResultCode == ExitCode.Failure)
                {
                    break;
                }
            }

            CleanUp();

            return totalResult;
        }

        private void CleanUp()
        {
            if (_settings.CleanUp)
            {
                _fileSystem.DeleteDirectory(_settings.OutputPath);
            }
        }


        public static string CreateNewSubdirName(DateTime now)
        {
            string name = string.Empty;

            name = now.Year.ToString().PadLeft(4, '0')
                            + now.Month.ToString().PadLeft(2, '0')
                            + now.Day.ToString().PadLeft(2, '0') + "_"
                            + now.Hour.ToString().PadLeft(2, '0')
                            + now.Minute.ToString().PadLeft(2, '0')
                            + now.Second.ToString().PadLeft(2, '0');

            return name;
        }
    }
}
