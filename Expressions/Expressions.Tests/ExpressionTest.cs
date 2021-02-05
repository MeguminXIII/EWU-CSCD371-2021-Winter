using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Expressions.Tests
{
    [TestClass]
    public class ExpressionTest
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
        public void LambdaStatement()
        {
            Func<string> lambdaStatement = () =>
            {
                return "Inigo Montoya";
            };
            Assert.AreEqual<string>("Inigo Montoya", lambdaStatement());
        }

        [TestMethod]
        public void LambdaStatement_GivenFunc()
        {
            Func<string, int> lambdaStatement = text =>
            {
                return text.Length;
            };
            Assert.AreEqual<int>("Inigo Montoya".Length, lambdaStatement("Inigo Montoya"));
        }

        [TestMethod]
        public void LambdaStatement_GivenFuncAsParameter()
        {
            int? number = null;
            Func<Action> lambdaStatement = () =>
            {
                return () => number = 42;
            };
            Action action = lambdaStatement();
            action();
            //lambdaStatement()();
            Assert.AreEqual<int?>(42, number);
        }

    }
}
