using CurrencyConverter;
using System;
using CurrencyConverter.DataModel;
using System.Collections.Generic;

namespace CurrencyConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = args[0];
                var fileName = filePath.Split("\\")[^1];

                if (fileName.ToLower().Contains("historical"))
                {
                    CurrenciesWithHistory(filePath);
                }
                else
                {
                    ConvertCurrencies(filePath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ConvertCurrencies(string filePath)
        {
            var currenciesList = CSVOperations.ReadCurrenciesData(filePath);
            var converter = new Converter("b298fc2865de5cd55b40");
            for (int i=0;i<currenciesList.Count;i++)
            {
                currenciesList[i].Amount = converter.Convert(currenciesList[i].CurrencyFrom, currenciesList[i].CurrencyTo, currenciesList[i].Quantity);
            }
            CSVOperations.WriteCurrenciesToCSV(currenciesList, GetOutputPath(filePath));
        }

        public static void CurrenciesWithHistory(string filePath)
        {
            var currenciesList = CSVOperations.ReadCurrenciesHistoricalData(filePath);
            var converter = new Converter("b298fc2865de5cd55b40");
            for (int i = 0; i < currenciesList.Count; i++)
            {
                double sum = 0.0;
                var listResponse = converter.GetHistoryRange(currenciesList[i].CurrencyFrom, currenciesList[i].CurrencyTo, currenciesList[i].FromDate, currenciesList[i].ToDate);
                for(int j=0;j<listResponse.Count;j++)
                {
                    sum += listResponse[j].ExchangeRate; 
                }
                currenciesList[i].Average = (sum / listResponse.Count);
            }
            CSVOperations.WriteCurrenciesHistoricalToCSV(currenciesList, GetOutputPath(filePath));
        }

        public static string GetOutputPath(string filePath)
        {
            string outputPath = filePath.Replace(filePath.Split("\\")[^1], "");

            return outputPath;
        }
    }
}
