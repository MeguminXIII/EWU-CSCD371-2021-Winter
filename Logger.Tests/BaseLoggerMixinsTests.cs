﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null!, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MethodInformation_WithNull_ThrowsExceptions()
        {
            BaseLoggerMixins.Information(null!, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MethodWarning_WithNull_ThrowsExceptions()
        {
            BaseLoggerMixins.Warning(null!, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MethodDebug_WithNull_ThrowsExceptions()
        {
            BaseLoggerMixins.Debug(null!, "");
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Message {0}", 42);

            // Assert
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Message {0}", 42);

            // Assert
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug("Message {0}", 42);

            // Assert
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }
    }

    public class TestLogger : BaseLogger
    {
        public override string ClassName { get; set; }

        public TestLogger()
        {
            this.ClassName = "testLogger";
        }

        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
