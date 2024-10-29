using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(string url, ILogger logger)
        {
            this.url = url;
            this.logger = logger;
        }

        public IEnumerable<string> GetTradeData()
        {
            //throw new NotImplementedException();
            var tradeData = new List<string>();
            logger.LogInfo("Reading trade file from URL: " + url);
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        // method variables
        string url;
        ILogger logger;
    }
}
