using Assignment4.SetWriterNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Tests
{
    namespace SetWriterTestsNamespace
    {
        [TestClass]
        public class SetWriterTests
        {

            [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void SetWriter_NullFilePath_NullExceptionThrown()
            {
                string? path = null;

                NumSet one = new(1, 2, 3, 5, 6);

                SetWriter setWriter = new SetWriter(path!);
                setWriter.WriteSetToFile(one);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Constructor_PassingInNull_ThrowsNullException()
            {
                SetWriter sw = new(null!);
            }

            [TestMethod]
            public void WriteSetToFile_WritesElementsToFile()
            {

                string path = Path.GetTempFileName();

                NumSet one = new(1, 2, 3, 5, 6);

                using (SetWriter setWriter = new SetWriter(path))
                    setWriter.WriteSetToFile(one);

                string lastLineInFile = File.ReadLines(path).Last();

                Assert.AreEqual(lastLineInFile, "{1, 2, 3, 5, 6, }");

            }
        }
    }
}
