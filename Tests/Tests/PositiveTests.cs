using NUnit.Framework;
using Realstaq.API;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tests.Tests
{
    public class PositiveTests
    {
        private readonly HousesApi _housesApi = new HousesApi();

        [Test]
        //send valid parameters and validates that filtered houses are within desired range
        public void TestHousesApi_SendAllParameters()
        {
            double price_gte = 450000;
            double price_lte = 666000;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_gte, price_lte, city);
            if (response.Count==0)
            {
                Assert.Fail();
            }
            else
            {
                List<double> prices = new List<double>();
                foreach (var house in response)
                {
                    prices.Add(house.Price);
                    Assert.GreaterOrEqual(house.Price, price_gte);
                    Assert.LessOrEqual(house.Price, price_lte);
                    Assert.AreEqual(city, house.City);
                }
            }
                
        }

        [Test]  
        //Validate that zero is a valid value for price lower limit
        public void TestHousesApi_NullPrice_gte()
        {
            double price_lte = 666000;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_lte: price_lte, city:city);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                List<double> prices = new List<double>();
                foreach (var house in response)
                {
                    prices.Add(house.Price);
                    Assert.LessOrEqual(house.Price, price_lte);
                    Assert.AreEqual(city, house.City);
                }
            }

        }

        [Test]
        //validates response for equal values of lower and upper price limits
        public void TestHousesApi_PriceGteEquals_PriceLte()
        {
            double price_gte = 450000;
            double price_lte = price_gte;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_gte, price_lte, city);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                List<double> prices = new List<double>();
                foreach (var house in response)
                {
                    prices.Add(house.Price);
                    Assert.AreEqual(house.Price, price_gte);
                    Assert.AreEqual(city, house.City);
                }
            }

        }

        [Test]
        //validates that price limits work with decimal values(dot separated)
        public void TestHousesApi_DecimalPrices()
        {
            double price_gte = 450000.5;
            double price_lte = 900500.45;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_gte, price_lte, city);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                List<double> prices = new List<double>();
                foreach (var house in response)
                {
                    prices.Add(house.Price);
                    Assert.GreaterOrEqual(house.Price, price_gte);
                    Assert.LessOrEqual(house.Price, price_lte);
                    Assert.AreEqual(city, house.City);
                }
            }

        }

        [Test]
        //validate response for valid price string values
        public void TestHousesApi_SendPriceAsValidString()
        {
            string price_gte = "450000.5";
            string price_lte = "666000";
            string city = "Austin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            double.TryParse(price_gte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceGteAsNumber);
            double.TryParse(price_lte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceLteAsNumber);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                foreach (var house in response)
                {
                    Assert.GreaterOrEqual(house.Price, priceGteAsNumber);
                    Assert.LessOrEqual(house.Price, priceLteAsNumber);
                    Assert.AreEqual(city, house.City);
                }
            }

        }

        [Test]
        //validates that price limit can contain long string values
        public void TestHousesApi_LongStringAsUpperPrice()
        {
            string price_gte = "450000";
            string price_lte = "66600000000000000000000000000000000000000000000000000000";
            string city = "Austin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Pass();
            }

        }

        [Test]
        //validate that space can be part of city name
        public void TestHousesApi_SpaceAsPartOfCityName()
        {
            string price_gte = "0";
            string price_lte = "2000000";
            string city = "E. New York";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                foreach (var house in response)
                {                                        
                    Assert.AreEqual(city, house.City);
                }
            }
        }

        [Test]
        //validates response for price limits beginning with zero
        public void TestHousesApi_PriceBeginningWithZero()
        {
            string price_gte = "0450000";
            string price_lte = "02000000";
            string city = "E. New York";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            double.TryParse(price_gte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceGteAsNumber);
            double.TryParse(price_lte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceLteAsNumber);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                foreach (var house in response)
                {
                    Assert.GreaterOrEqual(house.Price, priceGteAsNumber);
                    Assert.LessOrEqual(house.Price, priceLteAsNumber);
                    Assert.AreEqual(city, house.City);
                }
            }
        }

        [Test]
        //validates that lower price limit can have negative values
        public void TestHousesApi_NegativeLowerPrice()
        {
            string price_gte = "-700";
            string price_lte = "2000000";
            string city = "E. New York";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            double.TryParse(price_gte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceGteAsNumber);
            double.TryParse(price_lte, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceLteAsNumber);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                foreach (var house in response)
                {
                    Assert.GreaterOrEqual(house.Price, priceGteAsNumber);
                    Assert.LessOrEqual(house.Price, priceLteAsNumber);
                    Assert.AreEqual(city, house.City);
                }
            }
        }

        [Test]
        //validates that there are no duplicate objects in response
        public void TestHousesApi_ValidateHousesUniqueness()
        {
            string price_gte = "700";
            string price_lte = "2000000";
            string city = "E. New York";
            List<string> uniqueIds = new List<string>();
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                foreach (var house in response)
                {
                    uniqueIds.Add(house.Id); 
                }         
            }
            if (!(uniqueIds.Distinct().Count() == uniqueIds.Count()))
                Assert.Fail();
            else
                Assert.Pass();
        }
    }
}
