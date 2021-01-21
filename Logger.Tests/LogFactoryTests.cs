using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void Test_ConfigureFileLogger_SetsFilePath()
        {
            LogFactory logFactory = new LogFactory();
            FileLogger logger = (FileLogger)logFactory.CreateLogger("FileLogger");

            Assert.AreEqual(logger.GetFilePath(), "testFile.txt");
        }

        [TestMethod]
        public void TestCreateLogger_CheckingClassName()
        {
            LogFactory logFactory = new LogFactory();
            BaseLogger logger = logFactory.CreateLogger("FileLogger");

            Assert.AreEqual(logger.ClassName, "FileLogger");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_PassingNullToCreateLogger_ShouldThrowException()
        {
            LogFactory logFactory = new LogFactory();
            _ = logFactory.CreateLogger(null!);
        }
    }
}
