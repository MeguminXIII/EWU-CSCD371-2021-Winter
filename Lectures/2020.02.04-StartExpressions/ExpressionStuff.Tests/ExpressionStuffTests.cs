using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExpressionStuff.Tests
{
    [TestClass]
    public class ExpressionStuffTests
    {
        public int Method(string text) => 42;

        [TestMethod]
        public void Function_PointsToMethod_Success()
        {
            Func<string, int> method = Method;
            Assert.AreEqual<int>(42, method("Inigo Montoya"));
        }

        [TestMethod]
        public void Function_GivenSimpleExpression_Success()
        {
            Func<int> method = () => 42;
            Assert.AreEqual<int>(42, method());
        }

        [TestMethod]
        public void Function_GivenLessSimpleExpression_Success()
        {
            Func<string, int> method = (string text) => text.Length;
            Assert.AreEqual<int>("Inigo Montoya".Length, method("Inigo Montoya"));
        }

        [TestMethod]
        public void Action_GivenLessSimpleExpression_Success()
        {
            int? number = null;
            Action<string> method = (string text) => number = 42;
            method(null);
            Assert.AreEqual<int?>(42, number);
        }

        Lazy<string> Lazy = new Lazy<string>(
            () => "Inigo Montoya");

        [TestMethod]
        public void LazyInitialization()
        {
            Assert.AreEqual<string>("Inigo Montoya", Lazy.Value);
        }

        [TestMethod]
        public void LamdaStatement_GivenFunc()
        {
            Func<string, int> lamdaStatement = text =>
            {
                return text.Length;
            };
            Assert.AreEqual<int>("Inigo Montoya".Length, lamdaStatement("Inigo Montoya"));
        }

        [TestMethod]
        public void LamdaStatement_GivenFuncAsParameter()
        {
            int? number = null;
            Func<Action> lamdaStatement = () =>
            {
                return () => number = 42;
            };
            Action action = lamdaStatement();
            action();
            //lamdaStatement()();
            Assert.AreEqual<int?>(42, number);
        }
    }
}
