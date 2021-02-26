using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class IEnumerableNodeTests
    {

        private Node<char> CreateANodeList(char a, char b, char c)
        {
            Node<char> nodeOne = new(a);
            Node<char> nodeTwo = nodeOne.Insert(b);
            Node<char> nodeThree = nodeTwo.Insert(c);
            return nodeOne;
        }

        [TestMethod]
        public void GetEnumerator_GivenNodes_ReturnsEnumerator()
        {
            Node<char> charNode = CreateANodeList('a', 'b', 'c');
            IEnumerator<char> enumerator = charNode.GetEnumerator();
            foreach(char chara in charNode)
            {
                enumerator.MoveNext();
                Assert.AreEqual<char>(chara, enumerator.Current);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndexNeg1_throwsArgumentOutOfRangeException()
        {
            string val = "";
            Node<char> charNodes = CreateANodeList('a', 'b', 'c');
            IEnumerable<char> childItem = charNodes.ChildItems(-1);
            foreach (char item in childItem)
            {
                val += item + " ";
            }
            Assert.AreEqual<string>("a b c", val);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndex20_throwsArgumentOutOfRangeException()
        {
            string val = "";
            Node<char> charNodes = CreateANodeList('a', 'b', 'c');
            IEnumerable<char> childItem = charNodes.ChildItems(20);
            foreach (char item in childItem)
            {
                val += item + " ";
            }
            Assert.AreEqual<string>("a b c", val);
        }


        [TestMethod]
        public void ChildItems_Given3Nodes_IndexAt2_EqualsExpectedOutcome()
        {
            Node<char> charNodes = CreateANodeList('a', 'b', 'c');
            string val = "";
            IEnumerable<char> childItem = charNodes.ChildItems(2);
            foreach(char item in childItem)
                val += item + " ";
            Assert.AreEqual<string>("a b ", val);
        }
    }
}
