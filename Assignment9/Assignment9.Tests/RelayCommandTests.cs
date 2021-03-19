using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9.Tests
{
    [TestClass]
    public class RelayCommandTests
    {
        [TestMethod]
        public void CanExecuteDelegate_CanExecuteReturnsFalseWhenNotAbleToExecute()
        {
            RelayCommand relay = new(() => System.Console.WriteLine("Hello World"), () => false);
            Assert.IsFalse(relay.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteDelegate_CanExecuteReturnsTrueWhenAbleToExecute()
        {
            RelayCommand relay = new(() => System.Console.WriteLine("Hello World"), () => true);
            Assert.IsTrue(relay.CanExecute(null));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RelayCommand_PassInNullValues_ThrowNullArgumentException()
        {
            RelayCommand relayCommand = new(null, null);
        }
    }
}
