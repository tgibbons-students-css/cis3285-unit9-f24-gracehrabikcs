using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class RestfulTradeDataProvider : ITradeDataProvider
    {
        public RestfulTradeDataProvider(string url, ILogger logger)
        {
            this.url = url;
            this.logger = logger;
        }


        // This method requires NuGet packages System.Net.Http.Formatting.Extension and Newtonsoft.Json
        async Task<List<string>> GetProductAsync()
        {
            logger.LogInfo("Connecting the Restful server using HTTP");
            List<string> tradesString = null;
            HttpResponseMessage response = await client.GetAsync(url);
            //var task = Task.Run(() => client.GetAsync(url));
            //task.Wait();
            //HttpResponseMessage response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                tradesString = await response.Content.ReadAsAsync<List<string>>();
                logger.LogInfo("Received trade strings of length = " + tradesString.Count);

            }
            return tradesString;
        }

        public IEnumerable<string> GetTradeData()
        {
            var task = Task.Run(() => GetProductAsync());
            task.Wait();

            List<string> tradeList = task.Result;
            return tradeList;
        }

        private string url;
        HttpClient client = new HttpClient();
        private readonly ILogger logger;

    }
}
