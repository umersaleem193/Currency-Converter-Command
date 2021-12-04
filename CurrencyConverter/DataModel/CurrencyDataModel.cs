using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DataModel
{
    public class CurrencyDataModel
    {
        public CurrencyDataModel() { }
        public CurrencyDataModel(string from, string to, double quantity) => (CurrencyFrom, CurrencyTo, Quantity) = (from, to, quantity);
        public CurrencyDataModel(string from, string to, string fromdate, string todate) => (CurrencyFrom, CurrencyTo, FromDate, ToDate) = (from, to, fromdate, todate);


        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public string ToDate {get; set;}
        public string FromDate { get; set; } 
        public double Average { get; set; }

        public List<CurrencyDataModel> CurrencyDataModelList = new();

    }

    public class CurrencyHistory
    {
        public string Date { get; set; }
        public double ExchangeRate { get; set; }
    }

}
