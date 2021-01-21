using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CheckingFilePath()
        {
            //Arrange
            
            //Act
            FileLogger logger = new FileLogger("TestFile.txt");

            //Assert
            Assert.AreEqual("TestFile.txt", logger.GetFilePath());
        }

        [TestMethod]
        public void FileLogger_CheckingClassName()
        {
            //Arrange
            
            //Act
            FileLogger logger = new FileLogger("testFile.txt");

            //Assert
            Assert.AreEqual("FileLogger", logger.ClassName);
        }

        [TestMethod]
        public void FileLogger_InputMatchesWithLog()
        {
            
            FileLogger logger = new FileLogger("testFile.txt");

            logger.Log(LogLevel.Error, "The message is that this is a test");
            string[]? testFileLines = File.ReadAllLines("testFile.txt");

            Assert.AreEqual(logger.ClassName, testFileLines[1]);

        }
    }
}
