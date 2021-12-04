using CurrencyConverter.DataModel;
using CurrencyConverter.Helper;
using System;
using System.Collections.Generic;

namespace CurrencyConverter
{
    public class Converter
    {
        private string ApiKey { get; }

        public Converter()
        {
        }

        public Converter(string apiKey)
        {
            ApiKey = apiKey;
        }

        public double Convert(string from, string to, double quantity)
        {
            return RequestHelper.ExchangeRate(from, to, ApiKey) * quantity;
        }

        public List<CurrencyHistory> GetHistoryRange(string from, string to, string startDate, string endDate)
        {
            return RequestHelper.GetHistoryRange(from, to, startDate, endDate, ApiKey);
        }
    }
}
