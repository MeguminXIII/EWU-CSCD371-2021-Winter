using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(line=>line.Split(",")[6]).OrderBy(state => state).Distinct();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().Select(state => state).ToArray());

        // 4.
        public IEnumerable<IPerson> People => CsvRows.OrderBy(Address => Address).Select(line => line.Split(",")).OrderBy(line => line[6]).ThenBy(line => line[5]).ThenBy(line => line[7])
            .Select(record => new Person(record[1], record[2], new Address(record[4], record[5], record[6], record[7]), record[3]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(item => item.Address.State).Distinct().Aggregate((result, next) => result + ", " + next);
    }
}
