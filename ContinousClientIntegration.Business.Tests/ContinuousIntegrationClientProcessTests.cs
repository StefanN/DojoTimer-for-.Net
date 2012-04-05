using System;
using System.Collections.Generic;
using ContinuousClientIntegration.Business.Config;
using ContinuousClientIntegration.Business.ContinuousIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class ContinuousIntegrationClientProcessTests
    {
        [TestMethod]
        public void CreateWithEmptySettings()
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";
            settings.CleanUp = true;

            IFileSystem fs = new FakeFileSystem();
            List<BaseProcess> processes = new List<BaseProcess>();
            processes.Add(new SuceedingProcess());
            processes.Add(new FailingProcess());

            ContinuousIntegrationClientProcess cp = new ContinuousIntegrationClientProcess(settings, fs, processes);

            ProcessResult rresult = cp.Start();

            Assert.IsNotNull(rresult);
        }

        [TestMethod]
        public void CleanUp()
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";
            settings.CleanUp = true;
            FakeFileSystem fs = new FakeFileSystem();

            List<BaseProcess> processes = new List<BaseProcess>();
            
            ContinuousIntegrationClientProcess cp = new ContinuousIntegrationClientProcess(settings, fs, processes);

            ProcessResult rresult = cp.Start();

            Assert.IsNotNull(rresult);
            Assert.IsTrue(fs.HasCleanedUp);
        }


        [TestMethod]
        public void NoCleanUp()
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";
            settings.CleanUp = false;

            FakeFileSystem fs = new FakeFileSystem();

            List<BaseProcess> processes = new List<BaseProcess>();

            ContinuousIntegrationClientProcess cp = new ContinuousIntegrationClientProcess(settings, fs, processes);

            ProcessResult rresult = cp.Start();

            Assert.IsNotNull(rresult);
            Assert.IsFalse(fs.HasCleanedUp);
        }


        [TestMethod]
        public void CreateNewSubdirName_ValidDate_()
        {
            DateTime dt = new DateTime(2010, 12, 11, 22, 45, 33);
            string expected = "20101211_224533";
            string subdir = ContinuousIntegrationClientProcess.CreateNewSubdirName(dt);
            Assert.AreEqual(expected, subdir);
        }

    }


    public class SuceedingProcess : BaseProcess
    {
        public SuceedingProcess() : base(null) { }

        public override ProcessResult Process()
        {
            return new ProcessResult() { ResultCode = ExitCode.Success };
        }
    }

    public class FailingProcess : BaseProcess
    {
        public FailingProcess() : base(null) { }

        public override ProcessResult Process()
        {
            return new ProcessResult() { ResultCode = ExitCode.Failure };
        }
    }


    public class FakeFileSystem : IFileSystem
    {
        public List<string> Directories { get; set; }
        public FakeFileSystem()
        {
            Directories = new List<string>();
            HasCleanedUp = false;
        }

        public bool DirectoryExists(string directoryPath)
        {
            return Directories.Contains(directoryPath);
        }
        public void CreateDirectory(string directoryPath)
        {
            Directories.Add(directoryPath);
        }

        public void DeleteDirectory(string directoryPath)
        {
            Directories.Remove(directoryPath);
            HasCleanedUp = true;
        }

        public bool HasCleanedUp { get; set; }
    }
}
