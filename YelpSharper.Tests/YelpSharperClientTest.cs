using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YelpSharper.Tests
{
    [TestClass]
    public class YelpSharperClientTest
    {
        private readonly YelpSharperClient _yelpSharperClient;

        public YelpSharperClientTest()
        {
            _yelpSharperClient = new YelpSharperClient();
            var token = _yelpSharperClient.GetToken("Your client id here", "Your client secret here");
            _yelpSharperClient.AccessToken = token.AccessToken;
        }

        [TestMethod]
        public void ValidTokenShouldReturn()
        {
            var response = _yelpSharperClient.GetToken("Your client id here", "Your client secret here");
            Assert.IsNotNull(response.AccessToken);
        }
        
        [TestMethod]
        public void SearchBusinessesShouldReturn()
        {
            var response =_yelpSharperClient.Search(new {term = "indian food", latitude = "40.581140", longitude = "-111.914184"});
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void SearchBusinessesByPhoneShouldReturn()
        {
            var response =_yelpSharperClient.SearchByPhone(new {phone = "+18014384823"});
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void GetBusinessByIdShouldReturn()
        {
            var response = _yelpSharperClient.GetBusiness("india-palace-south-jordan-2");
            Assert.IsNotNull(response.Id);
        }
        [TestMethod]
        public void GetBusinessReviewsByIdShouldReturn()
        {
            var response = _yelpSharperClient.GetBusinessReviews("india-palace-south-jordan-2");
            Assert.IsNotNull(response.Reviews);
        }

        [TestMethod]
        public void SearchBusinessesByTransactionTypeShouldReturn()
        {
            var response = _yelpSharperClient.SearchByTransaction("delivery", new { latitude = "40.581140", longitude = "-111.914184" });
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void AutocompleteShouldReturn()
        {
            var response = _yelpSharperClient.Autocomplete(new { text = "india", latitude = "40.581140", longitude = "-111.914184" });
            Assert.IsNotNull(response.Businesses);
        }
    }
}
