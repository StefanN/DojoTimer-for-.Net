using System.IO;

namespace ContinuousClientIntegration.Business.Config
{
    public class Settings
    {
        public string MSBuildPath { get; set; }
        public string OutputPath { get; set; }
        public string SolutionPath { get; set; }
        public string BuildLogFileName { get; set; }
        public bool UseCoverage { get; set; }
        public string PartCoverPath { get; set; }
        public string CoverageReportingAssembliesRegEx { get; set; }

        public string GetBuildLogPath()
        {
            return Path.Combine(OutputPath, BuildLogFileName);
        }

        public string GetTestLogPath()
        {
            string path = Path.Combine(OutputPath, TestLogFileName);
            if (path.EndsWith(@"\"))
            {
                path.Substring(0, path.Length - 1);
            }
            return path;
        }

        public string GetTestAssemblyPath(string assemblyName)
        {
            return Path.Combine(OutputPath, assemblyName);
        }

        public string MSTestPath { get; set; }
        public string TestLogFileName { get; set; }

        public string BasePath { get; set; }

        public void UpdateOutputPath(string subdir)
        {
            OutputPath = Path.Combine(BasePath, subdir);
            if (OutputPath.EndsWith(@"\"))
            {
                OutputPath.Substring(0, OutputPath.Length - 1);
            }

        }

        public bool CleanUp { get; set; }

        public int TimerInterval { get; set; }

        public string CoverageLogFileName { get; set; }

        public int CompileInterval { get; set; }

        public string StyleCopPath { get; set; }

        public string StyleCopStyleSheet { get; set; }

        public string StyleCopSettingsfile { get; set; }

        public string StyleCopLogFileName { get; set; }
    }
}
