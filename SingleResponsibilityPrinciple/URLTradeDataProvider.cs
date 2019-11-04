using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
// ===============================
// AUTHOR      : Sumathilatha Myla
// CREATE DATE :11/03/2019
// PURPOSE     : Read the trades from a remote call to a web service
// ===============================

namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider : ITradeDataProvider
    {
        private readonly string  url;
        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }
        /// <summary>
        /// This method Reads data from webservice
        /// </summary>
        /// <returns>Trade data </returns>
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var urlData = client.OpenRead(url))
            using (var reader = new StreamReader(urlData))
            { 
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;

        }
    }
}
