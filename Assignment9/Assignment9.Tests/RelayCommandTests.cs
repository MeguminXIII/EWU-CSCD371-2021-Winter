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
        [ExpectedException(typeof(ArgumentNullException))]
        public void RelayCommand_PassInNullValues_ThrowNullArgumentException()
        {
            RelayCommand relayCommand = new(null, null);
        }
    }
}
