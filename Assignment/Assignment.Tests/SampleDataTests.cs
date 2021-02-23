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

        [TestMethod]
        public void People_EqualToExpected()
        {
            SampleData sampleData = new();
            
            IEnumerable<IPerson> actual = sampleData.People;

            IEnumerable<IPerson> expected = sampleData.CsvRows.OrderBy(Address => Address).Select(line => line.Split(",")).OrderBy(line => line[6]).ThenBy(line => line[5]).ThenBy(line => line[7])
            .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

            IEnumerable<(IPerson, IPerson)> actualZippedWithExpectedOutput = actual.Zip(expected);

            Assert.IsTrue(actualZippedWithExpectedOutput
                .All(item => (item.Item1.FirstName == item.Item2.FirstName)));
            Assert.IsTrue(actualZippedWithExpectedOutput
                   .All(item => (item.Item1.LastName == item.Item2.LastName)));
            Assert.IsTrue(actualZippedWithExpectedOutput
               .All(item => (item.Item1.FirstName == item.Item2.FirstName)));

        }

        [TestMethod]
        public void FilterByEmailAddress_GivenAContainsGov_ReturnsTrue()
        {
            SampleData sampleData = new();

            IEnumerable<(string, string)> actual = sampleData.FilterByEmailAddress(item => item.Contains("gov"));

            Assert.IsTrue(actual.Any(item => item.Item1 == "Priscilla"));
            Assert.IsTrue(actual.Any(item => item.Item2 == "Jenyns"));
            Assert.IsFalse(actual.Any(item => item.Item2 == "Joder"));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_ActualEqualsExpected()
        {
            SampleData sampleData = new();

            string expected = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
