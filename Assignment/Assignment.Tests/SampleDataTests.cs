using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_UsingForEach_IteratesThroughDataCorrectly()
        {
            SampleData sampleData = new();
            int numOfRows = 0;
            foreach (string item in sampleData.CsvRows)
            {
                numOfRows++;
            }

            Assert.AreEqual<int>(50, numOfRows);
        }

        [TestMethod]
        public void GetUniquSortedListOfStatesGivenCsvRows_ReturnsUnique()
        {
            SampleData sampleData = new();

            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            bool result = data.SequenceEqual(data.Distinct().OrderBy(item => item));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetUniquSortedListOfStatesGivenCsvRows_IsSortedAlphabetically()
        {
            SampleData sampleData = new();

            Assert.AreEqual<string>(
                "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", 
                sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }

       
    }
}
