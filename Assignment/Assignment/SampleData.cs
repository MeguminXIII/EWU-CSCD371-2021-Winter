using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.FullName, "Assignment", "People.csv")).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.OrderBy(state => state).Distinct().Select(line=>line.Split(",")[6]);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().Select(state => state).ToArray());

        // 4.
        public IEnumerable<IPerson> People => CsvRows.OrderBy(Address => Address).Select(line => line.Split(",")).OrderBy(State => State).ThenBy(City => City).ThenBy(Zip => Zip)
            .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(item => item.Address.State).Distinct().Aggregate((state, item) => state + ", " + item);
    }
}
