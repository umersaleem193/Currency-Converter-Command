using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.DataModel;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter.Helper
{
    public static class RequestHelper
    {
        public const string FreeBaseUrl = "https://free.currconv.com/api/v7/";

        public static double ExchangeRate(string from, string to, string apiKey = "b298fc2865de5cd55b40")
        {
            string url;

            url = FreeBaseUrl + "convert?q=" + from + "_" + to + "&compact=y&apiKey=" + apiKey;

            var jsonString = GetResponse(url);
            return JObject.Parse(jsonString).First.First["val"].ToObject<double>();
        }

        public static List<CurrencyHistory> GetHistoryRange(string from, string to, string startDate, string endDate, string apiKey = "b298fc2865de5cd55b40")
        {
            string url;
            url = FreeBaseUrl + "convert?q=" + from + "_" + to + "&compact=ultra&date=" + startDate + "&endDate=" + endDate + "&apiKey=" + apiKey;

            var jsonString = GetResponse(url);
            var data = JObject.Parse(jsonString).First.ToArray();
            return (from item in data
                    let obj = (JObject)item
                    from prop in obj.Properties()
                    select new CurrencyHistory
                    {
                        Date = prop.Name,
                        ExchangeRate = item[prop.Name].ToObject<double>()
                    }).ToList();
        }

        private static string GetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Error, BadRequest");
            }
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }
    }

}
