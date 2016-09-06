using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using YelpSharper.Models;

namespace YelpSharper
{
    public class YelpSharperClient
    {
        #region Constants
        private const string ApiUrl = "https://api.yelp.com/";
        private const string ApiVersion = "v3";
        private const string AuthPath = "oauth2/token";
        #endregion

        #region Properties
        public string AccessToken { get; set; }
        #endregion

        #region Constructors
        public YelpSharperClient() { }

        public YelpSharperClient(string accessToken)
        {
            AccessToken = accessToken;
        }
        #endregion

        #region Instance Yelp Api Methods
        public TokenResponse GetToken(string clientId, string clientSecret)
        {
            using (var client = GetHttpClient())
            {
                var response = client.PostAsync(AuthPath, new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                })).Result;

                var tokenResponse = response.Content.ReadAsAsync<TokenResponse>().Result;
                AccessToken = tokenResponse.AccessToken;
                return tokenResponse;
            }
        }

        public SearchResponse Search(object queryParams)
        {
            return Get<SearchResponse>("/businesses/search", queryParams);
        }

        public SearchResponse SearchByPhone(object queryParams)
        {
            return Get<SearchResponse>("/businesses/search/phone", queryParams);
        }

        public SearchResponse SearchByTransaction(string transactionType, object queryParams)
        {
            return Get<SearchResponse>($"/transactions/{transactionType}/search", queryParams);
        }

        public Business GetBusiness(string id)
        {
            return Get<Business>($"/businesses/{id}");
        }

        public ReviewResponse GetBusinessReviews(string id)
        {
            return Get<ReviewResponse>($"/businesses/{id}/reviews");
        }

        public AutoCompleteResponse Autocomplete(object queryParams)
        {
            return Get<AutoCompleteResponse>("/autocomplete", queryParams);
        }
        #endregion

        #region Instance Methods
        public T Get<T>(string endPoint, object queryParams = null)
        {
            if(string.IsNullOrEmpty(AccessToken))
                throw new Exception("AccessToken should not be null or empty");

            endPoint = string.Concat(ApiVersion, AppendQueryParameters(endPoint, queryParams));
            using (var client = GetHttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var response = client.GetAsync(endPoint).Result;
                return response.Content.ReadAsAsync<T>().Result;
            }
        }
        #endregion

        #region Private Methods
        private static string AppendQueryParameters(string endPoint, object parameters)
        {
            if (parameters == null)
            {
                return endPoint;
            }
            var dictionary = parameters as IDictionary<string, object>;
            var parms = string.Empty;
            var type = parameters.GetType();
            if (dictionary == null)
            {
                if (type.Name != "String")
                {
                    var queryParams =
                        type
                            .GetProperties()
                            .Where(x => x.CanRead)
                            .Select(x => x.Name + "=" + Uri.EscapeUriString(Convert.ToString(x.GetValue(parameters, null)))).ToArray();

                    parms = queryParams.Length > 0 ? string.Join("&", queryParams) : parameters.ToString();
                }
                else
                {
                    parms = Uri.EscapeUriString(parameters.ToString());
                }
            }
            else
            {
                var queryParams = dictionary.Select(x => x.Key + "=" + Uri.EscapeUriString(Convert.ToString(x.Value))).ToArray();
                if (queryParams.Length > 0)
                    parms = string.Join("&", queryParams);
            }
            if (endPoint.Contains("?"))
            {
                if (endPoint.EndsWith("?") || endPoint.EndsWith("&"))
                    endPoint = string.Concat(endPoint, parms);
                else
                    endPoint = string.Concat(endPoint, "&", parms);
            }
            else
            {
                endPoint = string.Concat(endPoint, "?", parms);
            }
            return endPoint;
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(ApiUrl)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        #endregion
    }
}
