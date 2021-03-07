using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    [TestClass]
    public class Assignment7Tests
    {

        [TestMethod]
        public void DownloadTextAsync_GoogleParam_LargeNumOfUrls()
        {
            Assert.IsTrue(Assignment7.DownloadTextAsync("https://google.com").Result > 1000);
        }

        [TestMethod]
        public void DownloadTextAsync_NothingInParams_LenghtOfZeroExpected()
        {
            Assert.AreEqual<int>(0, Assignment7.DownloadTextAsync().Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextAsync_NullValueInserted_ExceptionExpected()
        {
            Console.WriteLine(Assignment7.DownloadTextAsync(null!).Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_GoogleParam_LargeNumOfUrls()
        {
            int rep = 10;
            int res = 0;
            res = Assignment7.DownloadTextRepeatedlyAsync(rep, new ParallelOptions(), new Progress<double>(bar => Console.WriteLine(bar)), "https://google.com").Result;
            Assert.IsTrue(res > 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NegRepititions_ExceptionExpected()
        {
            Assert.AreEqual<int>(0, Assignment7.DownloadTextRepeatedlyAsync(-100, new ParallelOptions(), new Progress<double>(bar => Console.WriteLine(bar)), "https://google.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NullProgress_ExceptionExpected()
        {
            Assert.AreEqual<int>(0, Assignment7.DownloadTextRepeatedlyAsync(100, new ParallelOptions(), null!, "https://google.com").Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_Cancel_GetsCancelled()
        {
            ParallelOptions parallelOptions = new();
            CancellationTokenSource source = new();
            parallelOptions.CancellationToken = source.Token;
            bool wasCancelled = false;
            Task task = Task.Run(() =>
            {
                source.Cancel();
            });
            try
            {
                int res = Assignment7.DownloadTextRepeatedlyAsync(100, parallelOptions, new Progress<double>(bar => Console.WriteLine($"Progress: {bar * 100 }%")), "https://google.com").Result;
            }
            catch(AggregateException aggregateException)
            {
                aggregateException.Handle(exception =>
                {
                    if (exception is OperationCanceledException)
                        wasCancelled = true;
                    return true;
                });
            }
            Assert.IsTrue(wasCancelled);

        }
    }
}
