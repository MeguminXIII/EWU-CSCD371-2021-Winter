using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment4.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NumSet_NullParameters_ArgumentNullExceptionExpected()
        {
            NumSet numSet = new NumSet(null!);
        }

        [TestMethod]
        public void Constructor_PassesArray_assingsArrayToHashSet()
        {
            int[] array = new int[] { 1, 2, 3, 12 };

            NumSet numSet = new NumSet(array);

            Assert.IsNotNull(numSet.Set);
        }

        [TestMethod]
        public void ReturnArray_WhenCalled_ReturnsAnArray()
        {
            int[] array = new int[] { 1, 2, 3, 12 };

            NumSet arraySet = new NumSet(array);

            Assert.IsNotNull(arraySet.ReturnArray());
        }

        [TestMethod]
        public void Equals_ReturnsValidValue()
        {
            NumSet one = new(1, 2, 3, 5, 6);
            NumSet two = new(1, 2, 3, 5, 6);
            NumSet three = new(9, 10, 11, 12);

            Assert.IsTrue(one.Equals(two));
            Assert.IsFalse(one.Equals(three));
            Assert.IsTrue(one.Equals(one));
        }

        [TestMethod]
        public void EqualsOperator_TestingIfStatements()
        {
            NumSet? one = null;
            NumSet? two = null;
            NumSet three = new(1, 2);

            Assert.IsTrue(one! == two!);
            Assert.IsFalse(one! == three!);
        }

        [TestMethod]
        public void GetHashCode_ReturnsAnInt()
        {
            NumSet one = new(1, 2, 3, 5, 6);

            int res = one.GetHashCode();

            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void EqualsOperator_ReturnsValidValue()
        {
            NumSet one = new(1, 2, 3, 5, 6);
            NumSet two = new(1, 2, 3, 5, 6);
            NumSet three = new(9, 10, 11, 12);

            Assert.IsTrue(one == two);
            Assert.IsFalse(one == three);
        }

        [TestMethod]
        public void NotEqualsOperator_ReturnsValidValue()
        {
            NumSet one = new(1, 2, 3, 5, 6);
            NumSet two = new(1, 2, 3, 5, 6);
            NumSet three = new(9, 10, 11, 12);

            Assert.IsTrue(one != three);
        }

        [TestMethod]
        public void ToString_OutputMatchesExpectation()
        {
            NumSet one = new(1, 2, 3, 5, 6);

            Assert.AreEqual("{1, 2, 3, 5, 6, }", one.ToString());
        }
    }
}
