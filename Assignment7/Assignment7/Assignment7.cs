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

        public static async Task<int> DownloadTextRepeatedlyAsync(int repititions, CancellationToken cancellationToken, IProgress<double> progressPercent,  params string[] urls)
        {

            if (repititions < 0) throw new AggregateException(nameof(repititions));
            if (progressPercent is null) throw new AggregateException(nameof(progressPercent));
            int counter = 0;
            int res = 0;
            for(int i = 0; i<repititions && !cancellationToken.IsCancellationRequested; i++)
            {
                res += await DownloadTextAsync(urls);
                if (progressPercent is not null)
                    progressPercent.Report(counter++/repititions);
            }
            return res;
            
        }
    }
}
