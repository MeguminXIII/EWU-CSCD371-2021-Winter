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
                int i = 0;
                foreach(string url in urls)
                {
                    i += await Task.Run(() => webClient.DownloadString(url).Length);
                }
                return i;
            });
        }

        public static async Task<int> DownloadTextRepeatedlyAsync(int repititions, CancellationToken cancellationToken, IProgress<double> progressPercent,  params string[] urls)
        {

            if (repititions < 0) throw new AggregateException(nameof(repititions));
            if (progressPercent is null) throw new AggregateException(nameof(progressPercent));
            int counter = 0;
            int i = 0;
            for(int j = 0; j<repititions && !cancellationToken.IsCancellationRequested; j++)
            {
                i += await DownloadTextAsync(urls);
                if (progressPercent is not null)
                    progressPercent.Report(counter++/repititions);
            }
            return i;
            
        }
    }
}
