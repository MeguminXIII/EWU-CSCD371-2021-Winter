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
    public class InverseBooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void Convert_ConvertsFalseToVisible()
        {
            InverseBooleanToVisibilityConverter inverse = new();
            Visibility visible = (Visibility)inverse.Convert(false, null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Visible, visible);
        }

        [TestMethod]
        public void Convert_ConvertsTrueToCollapsed()
        {
            InverseBooleanToVisibilityConverter inverse = new();
            Visibility visible = (Visibility)inverse.Convert(true, null, null, null);
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);
        }

        [TestMethod]
        public void ConvertBack_ConvertsVisibleToFalse()
        {
            InverseBooleanToVisibilityConverter inverse = new();
            bool visible = (bool)inverse.ConvertBack(Visibility.Visible, null, null, null);
            Assert.AreEqual<bool>(visible, false);
        }

        [TestMethod]
        public void ConvertBack_ConvertsCollapsedToTrue()
        {
            InverseBooleanToVisibilityConverter inverse = new();
            bool visible = (bool)inverse.ConvertBack(Visibility.Collapsed, null, null, null);
            Assert.AreEqual<bool>(visible, true);
        }
    }
}
