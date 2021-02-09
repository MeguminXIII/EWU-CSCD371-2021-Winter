using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void NodeConstructor_ValueIsSet_AssertIsCorrect()
        {
            Node<string> one = new("Inigo Montoya");
            Node<int> two = new(42);
            Node<char> three = new('c');
            Node<double> four = new(1.123);

            Assert.AreEqual<string>("Inigo Montoya", one.Data);
            Assert.AreEqual<int>(42, two.Data);
            Assert.AreEqual<char>('c', three.Data);
            Assert.AreEqual<double>(1.123, four.Data);
        }

        [TestMethod]
        public void Node_ToStringWorks_ReturnsCorrectValue()
        {
            Node<string> one = new("Inigo Montoya");
            Node<int> two = new(42);
            Node<char> three = new('c');
            Node<double> four = new(1.123);

            Assert.AreEqual<string>("Inigo Montoya", one.ToString());
            Assert.AreEqual<string>("42", two.ToString());
            Assert.AreEqual<string>("c", three.ToString());
            Assert.AreEqual<string>("1.123", four.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Node_PassingNullToToString_ReturnsArgumentNullException()
        {
            Node<string> nullNode = new(null!);
            nullNode.ToString();
        }

        [TestMethod]
        public void Node_TestNextToVerify_NextShouldPointToNextNodeInList()
        {
            Node<string> one = new("Inigo_Montoya");
            Node<string> nodeRef = one.Next;
            Assert.AreEqual<Node<string>>(nodeRef, one);
            //Also shows that the list is circular when there is one node.
        }

        [TestMethod]
        public void Node_TestMakingNewNodeSameAsNext_ShouldReturnFalse()
        {
            Node<string> one = new("Inigo_Montoya");
            Node<string> two = new("Inigo_Montoya");

            Assert.AreNotEqual<Node<string>>(one, two);
            Assert.AreNotEqual<Node<string>>(one.Next, two);
            Assert.AreNotEqual<Node<string>>(one, two.Next);
        }

        [TestMethod]
        public void Node_TestingInsert_ListShouldStillBeCircular()
        {
            Node<string> one = new("Inigo_Montoya");
            one.Insert("Red");

            Assert.AreEqual<string>("Red", one.Next.ToString());
            Assert.AreEqual<string>("Inigo_Montoya", one.Next.Next.ToString());
            Assert.AreEqual<string>("Red", one.Next.Next.Next.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Node_TestingInsertWithNullValue_ShouldReturnNullException()
        {
            Node<string> one = new("Inigo_Montoya");
            one.Insert(null!);
        }

        [TestMethod]
        public void Node_TestingClear_ShouldEmptyListAfterCurrentNode()
        {
            Node<string> one = new("Inigo_Montoya");
            one.Insert(new("42"));
            one.Insert(new("c"));
            one.Insert(new("Red"));

            one.Clear();
            Assert.AreEqual<Node<string>>(one, one.Next);

        }


    }
}
