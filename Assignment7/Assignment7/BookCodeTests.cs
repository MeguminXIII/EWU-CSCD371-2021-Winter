using AddisonWesley.Michaelis.EssentialCSharp.Chapter22.Listing22_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    [TestClass]
    public class BookCodeTests
    {
        [TestMethod]
        public void UnsynchronizedCodeTests_NotConsistent()
        {
            string[] strings = new string[1000000000];

            Assert.AreEqual<int>(0, UnsynchronizedCode.UnSynchedBookCode(strings));
        }

        [TestMethod]
        public void BookCodeWithInterLock_ShouldBeSynched()
        {
            string[] strings = new string[1000000000];

            Assert.AreEqual<int>(0, BookCodeWithInterLock.BookCodeInterLocked(strings));
        }

        [TestMethod]
        public void BookCodeWithLock_ShouldBeSynched()
        {
            string[] strings = new string[1000000000];

            Assert.AreEqual<int>(0, BookCodeWithLock.BookCodeLocked(strings));
        }
    }
}
