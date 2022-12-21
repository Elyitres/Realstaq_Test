using NUnit.Framework;
using Realstaq.API;

namespace Tests.Tests
{
    public class NegativeTests
    {
        private readonly HousesApi _housesApi = new HousesApi();   

        [Test]
        //validates empty response for null/zero parameter values
        public void EmptyResponse_NullQueryParameters()
        {
            var response = _housesApi.GetHouses();
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates that upper limit price can't be less than lower limit price
        public void TestHousesApi_PriceLte_LessThanPriceGte()
        {
            int price_gte = 450000;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_gte, city: city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }

        }

        [Test]
        //validates that response is empty for null/zero price limits
        public void TestHousesApi_ZeroPrices()
        {
            string city = "Austin";
            var response = _housesApi.GetHouses(city: city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates empty response for null city parameter
        public void TestHousesApi_NullCity()
        {
            double price_gte = 450000;
            double price_lte = 666000;
            var response = _housesApi.GetHouses(price_gte, price_lte);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates empty response for non existing city parameter
        public void TestHousesApi_NonExistingCity()
        {
            double price_gte = 450000;
            double price_lte = 666000;
            string city = "Random City Name";
            var response = _housesApi.GetHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates empty response for non existing price range
        public void TestHousesApi_NonExistingPriceRange()
        {
            double price_gte = 2000000;
            double price_lte = 3000000;
            string city = "Austin";
            var response = _housesApi.GetHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates empty response for letters as price limit parameters
        public void TestHousesApi_SendPriceAsInvalidString()
        {
            string price_gte = "lower price";
            string price_lte = "upper price";
            string city = "Austin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates empty response for numbers as city parameter
        public void TestHousesApi_NumbersAsCityValue()
        {
            string price_gte = "450000";
            string price_lte = "666000";
            string city = "121546";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates that special characters aren't supported
        public void TestHousesApi_SpecialCharacters()
        {
            string price_gte = "10#";
            string price_lte = "6660000$";
            string city = "New%York";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates that comma separated prices are not supported
        public void TestHousesApi_CommaSeparatedPrices()
        {
            string price_gte = "450,000";
            string price_lte = "666,000";
            string city = "Austin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validates that city name is case sensitive
        public void TestHousesApi_CheckWhetherCityIsCaseSensitive()
        {
            string price_gte = "450000";
            string price_lte = "666000";
            string city = "AuStIN";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }

        }

        [Test]
        //validates that typo among city name is not supported
        public void TestHousesApi_CheckTypoAsPartOfCityName()
        {
            string price_gte = "450000";
            string price_lte = "666000";
            string city = "Ausdin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        //validate that upper limit price can't be negative
        public void TestHousesApi_NegativeUpperPrice()
        {
            string price_gte = "450000";
            string price_lte = "-666000";
            string city = "Austin";
            var response = _housesApi.FilterHouses(price_gte, price_lte, city);
            if (response.Count != 0)
            {
                Assert.Fail();
            }
        }

        #region Private Methods


        #endregion

    }
}
