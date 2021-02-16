using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericStuff.Tests
{
    [TestClass]
    public class ThreepleTests
    {
        [TestMethod]
        public void CreateThreeple()
        {
            _ = new Threeple<int,string,Guid>(42, "Inigo", Guid.NewGuid());
            _ = new Threeple<string, Guid, int>("Inigo", Guid.NewGuid(), 42);
        }

        [TestMethod]
        public void VerifyProperties()
        {
            Threeple<int, string, Guid> threeple = new (42, "Inigo", Guid.NewGuid());
            Assert.AreEqual<int>(42, threeple.First);
        }

        [TestMethod]
        public void GivenThreeple_ItemsAreInOrder()
        {
            ThreepleDescription<SampleCanDoDescription, string, Guid> threeple =
                new (new SampleCanDoDescription(), "Inigo", Guid.NewGuid());
            Assert.IsTrue(threeple.Description.Length > 0);
            Assert.AreEqual<string>("First: 42; Second: Inigo; Third: ;", threeple.Description);

            int? number = 42;
            number = null;
            Nullable<int> number2 = null;
            number = number2;
            Tuple<int, string> referenceTuple = default;
            ValueTuple<int, string> valueTuple = default;
        }


    }
}
