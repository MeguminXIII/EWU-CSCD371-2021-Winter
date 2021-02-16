using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqStuff.Tests
{
    //public static class ArrayEx
    //{
    //    public static IEnumerable<T> Where<T>(this IEnumerable<T> array, Func<T, bool> filter)
    //    {
    //        foreach(T item in array)
    //        {
    //            // return this item;
    //        }
    //        return default;
    //    }
    //}

#if false // Covariance/Contravariance
            IThingOut<string> stringData = IThing<object> 
            IThingIn<object> objectData = IThing<string> // Data is of type string
            objectData.Add(Guid.NewGuid());
            string text = (object)IThing.Data;
#endif

    record Thing(int number);


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] array = new string[]{ "first", "second", "third" };
            int[] numbers = default;
            // What is the count of the items
            // Sort all the items
            // Search for specific items
            // Add/remove items
            // Rearrange items?
            // Project out the collection:
            //      To create different types of items
            //      Filter the items
            // Distinct
            // Aggregate
            // GroupBy

            IEnumerable<int> even = numbers.Where<int>(item => (item % 2) == 0);

            IEnumerable<string> itemsContainLetterd = array.Where(
                item => item.Contains('d')
                );

            IEnumerable<Thing> numbersAsText = numbers.Select(item => new Thing(item));
            IEnumerable<(int,int)> tuples = numbers.Select(item => (item, item));
            tuples.Count();
            itemsContainLetterd.Sum(item => item.Length);
            numbers = even.ToArray();

            IEnumerator<string> enumerator = itemsContainLetterd.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            foreach(string item in itemsContainLetterd)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void DefferedExecution()
        {
            int executionCount = 0;
            IEnumerable<string> methods = typeof(string).GetMembers().Select(item => item.Name);
            Assert.IsTrue(methods.Contains("Trim"));
            
            methods = methods.Where(item =>
            {
                executionCount++;
                return item.StartsWith("G");
            });
            methods = methods.Where(item => item.Length > 4);
            Assert.IsTrue(methods.Count() > 0);
            Assert.AreEqual<int>(8, methods.Count());
            Assert.AreEqual<int>(332, executionCount);
            Assert.AreEqual<int>(8, methods.Count());
            Assert.AreEqual<int>(498, executionCount);
            methods = methods.AsEnumerable();
            List<string> list = methods.ToList();
            Assert.AreEqual<int>(664, executionCount);
            foreach (string text in list) { }
            Assert.AreEqual<int>(664, executionCount);
            
        }

        [TestMethod]
        public void LinqMethods()
        {
            IEnumerable<string> methods = typeof(string).GetMembers().Select(item => item.Name);

            // Are there any items that match the predicate
            Assert.IsTrue(methods.Any(item => item.StartsWith('G')));

            // Projection
            IEnumerable<int> lengthsQuery = methods.Select(item => item.Length);

            // Filter
            IEnumerable<string> filterdQuery = methods.Where(item => item.StartsWith('G')).ToList();

            // Project and filter
            lengthsQuery = methods.Where(item => item.StartsWith('G')).Select(item => item.Length);

            List<int> list = methods
                .Where(
                    item => item.StartsWith('G'))
                .Select(
                    item => item.Length)
                .ToList();



        }
    }
}
