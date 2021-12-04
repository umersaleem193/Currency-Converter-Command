using CurrencyConverter.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace CurrencyConverter
{
    public static class CSVOperations
    {

        public static List<CurrencyDataModel> ReadCurrenciesData(string filePath)
        {
            var currencyConversionList = new List<CSVCurrenciesColumns>();
            var currencyModel = new List<CurrencyDataModel>();

            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using (var csv = new CsvReader(reader, conf))
                {
                    csv.Context.RegisterClassMap<MapCurrenciesData>();
                    currencyConversionList = csv.GetRecords<CSVCurrenciesColumns>().ToList();
                }
            }

            for(int i=0; i< currencyConversionList.Count;i++)
            {
                currencyModel.AddRange(new List<CurrencyDataModel>
                {
                    new CurrencyDataModel(currencyConversionList[i].from, currencyConversionList[i].to,  currencyConversionList[i].quantity)
                });

            }

            return currencyModel;
        }

        public static void WriteCurrenciesToCSV(List<CurrencyDataModel> CurrencyDataModelList, string outputPath)
        {
            List<CSVCurrenciesColumns> CSVColumnsList = new List<CSVCurrenciesColumns>();

            for(int i=0;i<CurrencyDataModelList.Count;i++)
            {
                CSVColumnsList.AddRange(new List<CSVCurrenciesColumns>
                {
                    new CSVCurrenciesColumns(CurrencyDataModelList[i].CurrencyFrom, CurrencyDataModelList[i].CurrencyTo,  CurrencyDataModelList[i].Quantity, CurrencyDataModelList[i].Amount)
                });
            }

            var writer = new StreamWriter(outputPath + "currencies_output.csv");
            var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvwriter.WriteRecords(CSVColumnsList);
            csvwriter.Dispose();
            writer.Dispose();
        }

        public static List<CurrencyDataModel> ReadCurrenciesHistoricalData(string filePath)
        {
            var currencyHistoryList = new List<CSVCurrenciesHistoricalColumns>();
            var currencyModel = new List<CurrencyDataModel>();

            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using (var csv = new CsvReader(reader, conf))
                {
                    csv.Context.RegisterClassMap<MapCurrenciesHistoricalData>();
                    currencyHistoryList = csv.GetRecords<CSVCurrenciesHistoricalColumns>().ToList();
                }
            }

            for (int i = 0; i < currencyHistoryList.Count; i++)
            {
                currencyModel.AddRange(new List<CurrencyDataModel>
                {
                    new CurrencyDataModel(currencyHistoryList[i].from, currencyHistoryList[i].to,  currencyHistoryList[i].from_date, currencyHistoryList[i].to_date)
                });

            }

            return currencyModel;
        }

        public static void WriteCurrenciesHistoricalToCSV(List<CurrencyDataModel> CurrencyDataModelList, string outputPath)
        {
            List<CSVCurrenciesHistoricalColumns> CSVColumnsList = new List<CSVCurrenciesHistoricalColumns>();

            for (int i = 0; i < CurrencyDataModelList.Count; i++)
            {
                CSVColumnsList.AddRange(new List<CSVCurrenciesHistoricalColumns>
                {
                    new CSVCurrenciesHistoricalColumns(CurrencyDataModelList[i].CurrencyFrom, CurrencyDataModelList[i].CurrencyTo,  CurrencyDataModelList[i].FromDate,  CurrencyDataModelList[i].ToDate, CurrencyDataModelList[i].Average)
                });
            }

            var writer = new StreamWriter(outputPath + "currencies_historical_output.csv");
            var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvwriter.WriteRecords(CSVColumnsList);
            csvwriter.Dispose();
            writer.Dispose();
        }
    }

    public class CSVCurrenciesColumns
    {
        public CSVCurrenciesColumns() { }
        public CSVCurrenciesColumns(string fromCurrency, string toCurrency, double currencyQuantity, double Amount) => (from, to, quantity, amount) = (fromCurrency, toCurrency, currencyQuantity, Amount);
        public string from { get; set; }
        public string to { get; set; }
        public double quantity { get; set; }
        public double amount { get; set; }
    }

    public class CSVCurrenciesHistoricalColumns
    {
        public CSVCurrenciesHistoricalColumns() {  }
        public CSVCurrenciesHistoricalColumns(string fromCurrency, string toCurrency, string fromDate, string toDate, double Average) => (from, to, from_date, to_date, average) = (fromCurrency, toCurrency, fromDate, toDate, Average);
        public string from { get; set; }
        public string to { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public double average { get; set; }
    }

    sealed class MapCurrenciesData : ClassMap<CSVCurrenciesColumns>
    {
        public MapCurrenciesData()
        {
            Map(m => m.from).Name("from");
            Map(m => m.to).Name("to");
            Map(m => m.quantity).Name("quantity");
            Map(m => m.amount).Name("amount");
        }
    }

    sealed class MapCurrenciesHistoricalData : ClassMap<CSVCurrenciesHistoricalColumns>
    {
        public MapCurrenciesHistoricalData()
        {
            Map(m => m.from).Name("from");
            Map(m => m.to).Name("to");
            Map(m => m.from_date).Name("from_date");
            Map(m => m.to_date).Name("to_date");
            Map(m => m.average).Name("average");
        }
    }
}
