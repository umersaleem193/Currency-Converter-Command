using CurrencyConverter;
using NUnit.Framework;

namespace CurrencyConverterUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConversionOfCurrency_ReturnsExpectedValue() 
        {
            //Arrange
            var converter = new Converter("b298fc2865de5cd55b40");
            double Amount = 0;

            //Act
            Amount = converter.Convert("USD", "PKR", 200);

            //Assert
            Assert.IsNotNull(Amount);
        }

        [Test]
        public void ConversionOfCurrency_InDateRange_ReturnsExpectedResult()
        {
            //Arrange
            var converter = new Converter("b298fc2865de5cd55b40");
            double exchangeRate = 0;

            //Act
            var exchangeData = converter.GetHistoryRange("USD", "PKR", "2021-08-10", "2021-08-12");
            
            //Assert
            for(int i=0;i< exchangeData.Count;i++)
            {
                Assert.IsNotNull(exchangeData[i].ExchangeRate);
            }
        }
    }
}