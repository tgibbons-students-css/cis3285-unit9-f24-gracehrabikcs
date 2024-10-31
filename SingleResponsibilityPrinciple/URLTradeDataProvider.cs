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

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    // log error and throw an exception if the URL fails
                    logger.LogInfo("Failed to retrieve trades from URL: " + url);
                    throw new HttpRequestException("Unable to retrieve data from the specified URL.");

                }
                // set up a Stream and StreamReader to access the data
                using (Stream stream = response.Content.ReadAsStreamAsync().Result)
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Read each line of the text file using reader.ReadLine()
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        tradeData.Add(line);
                    }
       

                        // Read until the reader returns a null line
                        // Add each line to the tradeData list
                }
            }

            //var client = new WebClient();
            //using (var stream = client.OpenRead(url))
            //using (var reader = new StreamReader(stream))
            //{
            //string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //tradeData.Add(line);
            //}
            //}

            return tradeData;
        }

        // method variables
        string url;
        ILogger logger;
    }
}
