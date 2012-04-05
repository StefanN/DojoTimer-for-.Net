using System.Diagnostics;
using System.IO;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.ContinuousIntegration
{
    public class ProcessStartInfoFactory
    {
        public static ProcessStartInfo CreateCompileProcessStartInfo(Settings settings)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"""" + settings.MSBuildPath + @"""";
            startInfo.Arguments = @"""" + settings.SolutionPath + @"""";
            startInfo.Arguments += " /p:OutputPath=";
            startInfo.Arguments += @"""" + settings.OutputPath + @"""";
            startInfo.Arguments += @" /flp:logfile=";
            startInfo.Arguments += @"""" + settings.GetBuildLogPath() + @"""";
            return startInfo;
        }


        public static ProcessStartInfo CreateTestProcessStartInfo(Settings settings, string[] fileNames)
        {
            ////// Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"""" + settings.MSTestPath + @"""";

            foreach (string fileName in fileNames)
            {
                FileInfo f = new FileInfo(fileName);

                startInfo.Arguments += " /testcontainer:";
                startInfo.Arguments += @"""" + settings.GetTestAssemblyPath(f.Name) + @"""";

            }
            startInfo.Arguments += " /nologo";
            startInfo.Arguments += " /resultsfile:";
            startInfo.Arguments += @"""" + settings.GetTestLogPath() + @"""";
            return startInfo;
        }




        public static ProcessStartInfo CreateTestAndCoverageProcessStartInfo(Settings settings, string[] fileNames)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"""" + settings.PartCoverPath + @"""";

            startInfo.Arguments += " --target ";
            startInfo.Arguments += @"""" + settings.MSTestPath + @"""";
            startInfo.Arguments += " --target-work-dir ";
            startInfo.Arguments += @"""" + settings.OutputPath + @"""";    // trim trailing slash?
            startInfo.Arguments += " --target-args ";

            startInfo.Arguments += @"""";
            foreach (string fileName in fileNames)
            {
                FileInfo f = new FileInfo(fileName);
                startInfo.Arguments += " /testcontainer:";
                startInfo.Arguments += f.Name;
            }
            startInfo.Arguments += " /noisolation";
            startInfo.Arguments += " /nologo";
            startInfo.Arguments += " /resultsfile:";
            startInfo.Arguments += settings.TestLogFileName;
            startInfo.Arguments += @"""";

            startInfo.Arguments += " --include " + settings.CoverageReportingAssembliesRegEx;
            startInfo.Arguments += " --output " + @"""" + Path.Combine(settings.OutputPath, settings.CoverageLogFileName) + @"""";

            return startInfo;
        }

        public static ProcessStartInfo CreateStyleCopProcessStartInfo(Settings settings)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"""" + settings.StyleCopPath + @"""";

            startInfo.Arguments += "-sf ";
            startInfo.Arguments += @"""" + settings.SolutionPath + @"""";

            startInfo.Arguments += " -of ";
            startInfo.Arguments += @"""" + Path.Combine(settings.OutputPath, settings.StyleCopLogFileName) + @"""";

            startInfo.Arguments += " -tf ";
            startInfo.Arguments += @"""" + settings.StyleCopStyleSheet + @"""";

            startInfo.Arguments += " -sc ";
            startInfo.Arguments += @"""" + settings.StyleCopSettingsfile + @"""";             

            return startInfo;
        }
    }
}
