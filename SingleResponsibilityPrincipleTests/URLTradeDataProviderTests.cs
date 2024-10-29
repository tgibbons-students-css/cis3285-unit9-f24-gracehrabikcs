using Microsoft.Data.SqlClient;
using SingleResponsibilityPrinciple.Contracts;
using SingleResponsibilityPrinciple;
using System.Diagnostics;

namespace SingleResponsibilityPrinciple.Tests
{
    [TestClass()]
    public class URLTradeDataProviderTests
    {
        private int countStrings(IEnumerable<string> collectionOfStrings)
        {
            // count the trades
            int count = 0;
            foreach (var trade in collectionOfStrings)
            {
                count++;
            }
            return count;
        }


        [TestMethod()]
        public void TestSize1()
        {
            //Arrange
            ILogger logger = new ConsoleLogger();
            string tradeURL = "http://faculty.css.edu/tgibbons/trades4.txt";

            ITradeDataProvider tradeProvider = new URLTradeDataProvider(tradeURL, logger);

            //Act
            //var trades = tradeProvider.GetTradeData();
            IEnumerable<string> trades = tradeProvider.GetTradeData();


            //Assert

            Assert.AreEqual(countStrings(trades), 4);
        }
    }
}