using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContinuousClientIntegration.Business.Config;

namespace ContinuousClientIntegration.Business.Tests
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void GettersAndSetters()
        {
            Settings settings = new Settings();
            settings.BasePath = @"c:\";
            settings.BuildLogFileName = "buildlog.log";
            settings.CleanUp = true;
            settings.CompileInterval = 2;

            Assert.AreEqual(@"c:\", settings.BasePath);
            Assert.AreEqual("buildlog.log", settings.BuildLogFileName);
            Assert.AreEqual(true, settings.CleanUp);
            Assert.AreEqual(2, settings.CompileInterval);
        }
    }
}
