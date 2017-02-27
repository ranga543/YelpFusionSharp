using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YelpFusion.Client.Models.Options;

namespace YelpFusion.Client.Tests
{
    [TestClass]
    public class YelpFusionClientTest
    {
        private readonly YelpFusionClient _yelpFusionClient;
        private static readonly string AppId = GetValue("AppId");
        private static readonly string AppSecret = GetValue("AppSecret");

        public YelpFusionClientTest()
        {
            _yelpFusionClient = new YelpFusionClient();
            var token = _yelpFusionClient.GetToken(AppId, AppSecret);
            _yelpFusionClient.AccessToken = token.AccessToken;
        }

        [TestMethod]
        public void ValidTokenShouldReturn()
        {
            var response = _yelpFusionClient.GetToken(AppId, AppSecret);
            Assert.IsNotNull(response.AccessToken);
        }
        
        [TestMethod]
        public void SearchBusinessesShouldReturn()
        {
            var response = _yelpFusionClient.Search(new BusinessSearchOptions
                {Term = "indian food", Latitude = 40.581140M, Longitude = -111.914184M});
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void SearchBusinessesByPhoneShouldReturn()
        {
            var response =_yelpFusionClient.SearchByPhone("+18015420124");
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void GetBusinessByIdShouldReturn()
        {
            var response = _yelpFusionClient.GetBusiness("india-palace-south-jordan-2");
            Assert.IsNotNull(response.Id);
        }
        [TestMethod]
        public void GetBusinessReviewsByIdShouldReturn()
        {
            var response = _yelpFusionClient.GetBusinessReviews("india-palace-south-jordan-2");
            Assert.IsNotNull(response.Reviews);
        }

        [TestMethod]
        public void SearchBusinessesByTransactionTypeShouldReturn()
        {
            var response = _yelpFusionClient.SearchByTransaction("delivery", new TransactionSearchOptions { Latitude = 40.581140M, Longitude = -111.914184M });
            Assert.IsNotNull(response.Businesses);
        }

        [TestMethod]
        public void AutocompleteShouldReturn()
        {
            var response = _yelpFusionClient.Autocomplete(new AutoCompleteOptions { Text = "india", Latitude = 40.581140M, Longitude = -111.914184M });
            Assert.IsNotNull(response.Businesses);
        }

        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
