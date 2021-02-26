using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SampleDataTests
    {
        private readonly SampleData SampleData = new();

        [TestMethod]
        public void CsvRows_UsingForEach_IteratesThroughDataCorrectly()
        {
            int numOfRows = SampleData.CsvRows.Count();

            Assert.AreEqual<int>(50, numOfRows);
        }

        [TestMethod]
        public void GetUniquSortedListOfStatesGivenCsvRows_ReturnsUnique()
        {

            IEnumerable<string> data = SampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(data.SequenceEqual(data.Distinct().OrderBy(item => item)));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardCodedValues_IsSortedAlphabetically()
        {
            Assert.AreEqual<string>(
                "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", 
                SampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }


        [TestMethod]
        public void People_EqualToExpected()
        {
            
            IEnumerable<IPerson> actual = SampleData.People;

            IEnumerable<IPerson> expected = SampleData.CsvRows.
                OrderBy(Address => Address).
                Select(line => line.Split(",")).
                OrderBy(line => line[SampleData.StateColumn]).
                ThenBy(line => line[SampleData.CityColumn]).
                ThenBy(line => line[SampleData.ZipColumn]).
                Select(record =>
                new Person(
                    record[SampleData.FirstNameColumn], 
                    record[SampleData.LastNameColum],
                    new Address(
                        record[SampleData.StreetAddressColumn], 
                        record[SampleData.CityColumn], 
                        record[SampleData.StateColumn], 
                        record[SampleData.ZipColumn]),
                    record[SampleData.EmailColumn]));

            IEnumerable<(IPerson actual, IPerson expected)> actualZippedWithExpectedOutput = actual.Zip(expected);

            Assert.IsTrue(actualZippedWithExpectedOutput
                .All(item => (item.actual.FirstName == item.expected.FirstName)));
            Assert.IsTrue(actualZippedWithExpectedOutput
                   .All(item => (item.actual.LastName == item.expected.LastName)));

        }

        [TestMethod]
        public void FilterByEmailAddress_GivenAContains_ReturnsCorrectly()
        {
            IEnumerable<(string, string)> actual = SampleData.FilterByEmailAddress(item => item.Contains("gov"));

            //Priscilla Jenyns has a .gov email while Joder does not
            Assert.IsTrue(actual.Any(item => item.Item1 == "Priscilla"));
            Assert.IsTrue(actual.Any(item => item.Item2 == "Jenyns"));
            Assert.IsFalse(actual.Any(item => item.Item2 == "Joder"));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_ActualEqualsExpected()
        {
            string expected = SampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string actual = SampleData.GetAggregateListOfStatesGivenPeopleCollection(SampleData.People);

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
