using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment9.Tests
{
    [TestClass]
    public class EmptyStringVisibilityConverterTests
    {
        [TestMethod]
        public void Convert_PassInNullConvertsToCollapsed()
        {
            EmptyStringVisibilityConverter convert = new();
            Visibility visible = (Visibility)convert.Convert(null, null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);
        }

        [TestMethod]
        public void Convert_PassInEmptyConvertsToCollapsed()
        {
            EmptyStringVisibilityConverter convert = new();
            Visibility visible = (Visibility)convert.Convert("", null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);
        }

        [TestMethod]
        public void Convert_PassInStuffConvertsToVisible()
        {
            EmptyStringVisibilityConverter convert = new();
            Visibility visible = (Visibility)convert.Convert("Stuff", null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Visible, visible);
        }

        [TestMethod]
        public void Convert_PassInWhiteSpaceConvertsToCollapsed()
        {
            EmptyStringVisibilityConverter convert = new();
            Visibility visible = (Visibility)convert.Convert("  ", null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);
        }

        [TestMethod]
        public void Convert_PassInStuffWithWhiteSpaceConvertsToVisible()
        {
            EmptyStringVisibilityConverter convert = new();
            Visibility visible = (Visibility)convert.Convert("Stuff and more stuff like this", null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Visible, visible);
        }

    }
}
