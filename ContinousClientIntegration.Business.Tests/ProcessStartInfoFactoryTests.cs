using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContinuousClientIntegration.Business.Config;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using System.Diagnostics;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class ProcessStartInfoFactoryTests
    {
        [TestMethod]
        public void CreateCompileProcessStartInfo_AllSettingsValid_ValidResult()
        {
            Settings settings = new Settings();
            settings.MSBuildPath = @"c:\msbuild\msbuild.exe";
            settings.SolutionPath = @"c:\solution\test.sln";
            settings.OutputPath = @"c:\output\";
            settings.BuildLogFileName = "build.log";

            ProcessStartInfo info = ProcessStartInfoFactory.CreateCompileProcessStartInfo(settings);
            string arguments = info.Arguments;

            // "c:\solution\test.sln" /p:OutputPath="c:\output\" /flp:logfile="c:\output\build.log";
            string expected = @"""c:\solution\test.sln"" /p:OutputPath=""c:\output\"" /flp:logfile=""c:\output\build.log""";

            Assert.AreEqual(@"""c:\msbuild\msbuild.exe""", info.FileName);
            Assert.AreEqual(expected, arguments);
        }

        [TestMethod]
        public void CreateTestProcessStartInfo_AllSettingsValid_ValidResult()
        {
            Settings settings = new Settings();
            settings.MSTestPath = @"c:\mstest\mstest.exe";
            settings.OutputPath = @"c:\output\";
            settings.TestLogFileName = "testlog.log";

            string[] fileNames = new string[] { "file1.dll", "file2.dll" };

            ProcessStartInfo info = ProcessStartInfoFactory.CreateTestProcessStartInfo(settings, fileNames);
            string arguments = info.Arguments;

            // "c:\output\file1.dll" /testcontainer:"c:\output\file2.dll" /nologo /resultsfile:"c:\output\testlog.log"
            string expected = @" /testcontainer:""c:\output\file1.dll"" /testcontainer:""c:\output\file2.dll"" /nologo /resultsfile:""c:\output\testlog.log""";

            Assert.AreEqual(@"""c:\mstest\mstest.exe""", info.FileName);
            Assert.AreEqual(expected, arguments);
        }


        [TestMethod]
        public void CreateTestAndCoverageProcessStartInfo_AllSettingsValid_ValidResult()
        {
            Settings settings = new Settings();
            settings.MSTestPath = @"c:\mstest\mstest.exe";
            settings.OutputPath = @"c:\output\";
            settings.TestLogFileName = "testlog.log";
            settings.CoverageLogFileName = "coveragelog.log";

            settings.CoverageReportingAssembliesRegEx = "REGEX";

            settings.PartCoverPath = @"c:\partcover\partcover.exe";

            string[] fileNames = new string[] { "file1.dll", "file2.dll" };

            ProcessStartInfo info = ProcessStartInfoFactory.CreateTestAndCoverageProcessStartInfo(settings, fileNames);

            // " --target "c:\mstest\mstest.exe" --target-work-dir "c:\output\" --target-args " /testcontainer:file1.dll /testcontainer:file2.dll /noisolation /nologo /resultsfile:testlog.log" --include REGEX --output "c:\output\coveragelog.log"
            string expected = @" --target ""c:\mstest\mstest.exe"" --target-work-dir ""c:\output\"" --target-args "" /testcontainer:file1.dll /testcontainer:file2.dll /noisolation /nologo /resultsfile:testlog.log"" --include REGEX --output ""c:\output\coveragelog.log""";

            Assert.AreEqual(@"""c:\partcover\partcover.exe""", info.FileName);
            Assert.AreEqual(expected, info.Arguments);
        }

        [TestMethod]
        public void CreateStyleCopProcessStartInfo_AllSettingsValid_ValidResult()
        {
            Settings settings = new Settings();
            settings.StyleCopPath = @"C:\Program Files\StyleCopCmd-bin-0.2.1.0\Net.SF.StyleCopCmd.Console\StyleCopCmd.exe";
            settings.SolutionPath = @"c:\solution\test.sln";

            settings.OutputPath = @"c:\"; 
            settings.StyleCopLogFileName = "result.xml";
            settings.StyleCopStyleSheet = @"c:\stylesheet.xsl";
            settings.StyleCopSettingsfile = @"c:\stylecop.settings";

            ProcessStartInfo info = ProcessStartInfoFactory.CreateStyleCopProcessStartInfo(settings);
            string expected = @"-sf ""c:\solution\test.sln"" -of ""c:\result.xml"" -tf ""c:\stylesheet.xsl"" -sc ""c:\stylecop.settings""";

            Assert.AreEqual(@"""C:\Program Files\StyleCopCmd-bin-0.2.1.0\Net.SF.StyleCopCmd.Console\StyleCopCmd.exe""", info.FileName);
            Assert.AreEqual(expected, info.Arguments);
        }
    }
}
