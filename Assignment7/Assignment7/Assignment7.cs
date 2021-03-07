using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    class Assignment7
    {
        public static async Task<int> DownloadTextAsync(params string[] urls)
        {
            WebClient webClient = new();

            return await Task.Run(async () =>
            {
                int res = 0;
                foreach(string url in urls)
                {
                    res += await Task.Run(() => webClient.DownloadString(url).Length);
                }
                return res;
            });
        }

        public static async Task<int> DownloadTextRepeatedlyAsync(int repititions, ParallelOptions parallelOptions, IProgress<double> progressPercent,  params string[] urls)
        {

            if (repititions < 0) throw new AggregateException(nameof(repititions));
            if (progressPercent is null) throw new AggregateException(nameof(progressPercent));

            Task<int> intTask = Task.Run(() =>
           {
               int res = 0;

               Parallel.For(0, repititions, parallelOptions, index =>
               {
                   parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                   Interlocked.Add(ref res, DownloadTextAsync(urls).Result);

                   progressPercent.Report(((double)index + 1) / repititions);
               });
               return res;

           });
            return await intTask;
        }
    }
}
