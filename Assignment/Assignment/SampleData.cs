using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public const int FirstNameColumn = 1;
        public const int LastNameColum = 2;
        public const int EmailColumn = 3;
        public const int StreetAddressColumn = 4;
        public const int CityColumn = 5;
        public const int StateColumn = 6;
        public const int ZipColumn = 7;
        private const string FileName = "People.csv";

        // 1.
        public IEnumerable<string> CsvRows =>
            File.ReadAllLines(FileName).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(line=>line.Split(",")[StateColumn]).OrderBy(state => state).Distinct();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().Select(state => state).ToArray());

        // 4.
        public IEnumerable<IPerson> People 
            => CsvRows.OrderBy(Address => Address).
            Select(line => line.Split(",")).
            OrderBy(line => line[StateColumn]).
            ThenBy(line => line[CityColumn]).
            ThenBy(line => line[ZipColumn])
            .Select(record => 
            new Person(record[FirstNameColumn], record[LastNameColum], 
                new Address(record[StreetAddressColumn], record[CityColumn], record[StateColumn], record[ZipColumn]), 
                record[EmailColumn]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) 
            => People.Where(item => filter(item.EmailAddress)).
            Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) 
            => people.Select(item => item.Address.State).Distinct().
            Aggregate((result, next) => result + ", " + next);
    }
}
