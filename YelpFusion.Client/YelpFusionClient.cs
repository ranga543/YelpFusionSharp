using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YelpFusion.Client.Exceptions;
using YelpFusion.Client.Models;
using YelpFusion.Client.Extensions;
using YelpFusion.Client.Models.Options;

namespace YelpFusion.Client
{
    public class YelpFusionClient
    {
        #region Constants
        private const string ApiUrl = "https://api.yelp.com/";
        private const string ApiVersion = "v3";
        private const string AuthPath = "oauth2/token";

        private const string AutocompletePath = "/autocomplete";
        private const string BusinessesSearchPhonePath = "/businesses/search/phone";
        private const string BusinessesSearchPath = "/businesses/search";
        private const string TransactionSearchPath = "/transactions/{0}/search";
        private const string BusinessPath = "/businesses/{0}";
        private const string BusinessReviewPath = "/businesses/{0}/reviews";
        #endregion

        #region Properties
        public string AccessToken { get; set; }
        #endregion

        #region Constructors
        public YelpFusionClient() { }

        public YelpFusionClient(string accessToken)
        {
            AccessToken = accessToken;
        }
        #endregion

        #region Instance Yelp Api Methods
        public Task<TokenResponse> GetAsyncToken(string appId, string appSecret)
        {
            if (string.IsNullOrEmpty(appId)) throw new ArgumentNullException(nameof(appId));
            if (string.IsNullOrEmpty(appSecret)) throw new ArgumentNullException(nameof(appSecret));

            var client = GetHttpClient();
            var tcs = new TaskCompletionSource<TokenResponse>();

            var responseTask = client.PostAsync(AuthPath, new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", appId),
                    new KeyValuePair<string, string>("client_secret", appSecret)
                }));
            ResponseHandle(responseTask, tcs);
            DisposeHttpClient(tcs, client);
            return tcs.Task;
        }

        public TokenResponse GetToken(string clientId, string clientSecret)
        {
            return GetAsyncToken(clientId, clientSecret).Result;
        }

        public Task<SearchResponse> SearchAsync(BusinessSearchOptions businessSearchOptions,
            Dictionary<string, string> optionalParameters = null)
        {
            return GetAsync<SearchResponse>(GetBusinessesSearchPath(businessSearchOptions, optionalParameters));
        }

        public Task<SearchResponse> SearchByPhoneAsync(string phone)
        {
            return GetAsync<SearchResponse>(GetBusinessesSearchPhonePath(phone));
        }

        public Task<SearchResponse> SearchByTransactionAsync(string transactionType, TransactionSearchOptions searchOptions,
            Dictionary<string, string> optionalParams = null)
        {
            return GetAsync<SearchResponse>(GetTransactionSearchPath(transactionType, searchOptions, optionalParams));
        }

        public Task<Business> GetBusinessAsync(string id)
        {
            return GetAsync<Business>(string.Format(BusinessPath, id));
        }

        public Task<ReviewResponse> GetBusinessReviewsAsync(string id, Dictionary<string, string> optionalParams = null)
        {
            return GetAsync<ReviewResponse>(GetBusinessReviewPath(id, optionalParams));
        }

        public Task<AutoCompleteResponse> AutocompleteAsync(AutoCompleteOptions autoCompleteOptions,
            Dictionary<string, string> optionalParams = null)
        {
            return GetAsync<AutoCompleteResponse>(GetAutocompletePath(autoCompleteOptions, optionalParams));
        }

        public SearchResponse Search(BusinessSearchOptions businessSearchOptions, 
            Dictionary<string, string> optionalParameters = null)
        {
            return Get<SearchResponse>(GetBusinessesSearchPath(businessSearchOptions, optionalParameters));
        }

        public SearchResponse SearchByPhone(string phone)
        {
            return Get<SearchResponse>(GetBusinessesSearchPhonePath(phone));
        }

        public SearchResponse SearchByTransaction(string transactionType, TransactionSearchOptions searchOptions, 
            Dictionary<string, string> optionalParams = null)
        {
            return Get<SearchResponse>(GetTransactionSearchPath(transactionType, searchOptions, optionalParams));
        }

        public Business GetBusiness(string id)
        {
            return Get<Business>(string.Format(BusinessPath, id));
        }

        public ReviewResponse GetBusinessReviews(string id, Dictionary<string, string> optionalParams = null)
        {
            return Get<ReviewResponse>(GetBusinessReviewPath(id, optionalParams));
        }

        public AutoCompleteResponse Autocomplete(AutoCompleteOptions autoCompleteOptions,
            Dictionary<string, string> optionalParams = null)
        {
            return Get<AutoCompleteResponse>(GetAutocompletePath(autoCompleteOptions, optionalParams));
        }
        #endregion

        #region Private Methods
        private Task<T> GetAsync<T>(string endPoint)
        {
            if (string.IsNullOrEmpty(AccessToken))
                throw new Exception("AccessToken should not be null or empty");

            endPoint = string.Concat(ApiVersion, endPoint);
            var client = GetHttpClient();

            var tcs = new TaskCompletionSource<T>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var responseTask = client.GetAsync(endPoint);
            ResponseHandle(responseTask, tcs);
            DisposeHttpClient(tcs, client);
            return tcs.Task;
        }

        private T Get<T>(string endPoint)
        {
            return GetAsync<T>(endPoint).Result;
        }

        private static string GetBusinessesSearchPath(BusinessSearchOptions businessSearchOptions,
            Dictionary<string, string> optionalParameters = null)
        {
            if (businessSearchOptions == null) throw new ArgumentNullException(nameof(businessSearchOptions));
            var searchQueryString = businessSearchOptions.GetQueryParamters();
            if (optionalParameters != null)
                searchQueryString = $"{searchQueryString}&{optionalParameters.GetQueryParameters()}";

            return $"{BusinessesSearchPath}?{searchQueryString}";
        }

        private static string GetBusinessesSearchPhonePath(string phone)
        {
            if (string.IsNullOrEmpty(phone)) throw new ArgumentException(nameof(phone));
            if (!phone.StartsWith("+"))
                throw new ArgumentException("Should start with +", nameof(phone));

            return $"{BusinessesSearchPhonePath}?phone=${phone}";
        }

        private static string GetTransactionSearchPath(string transactionType, TransactionSearchOptions searchOptions,
            Dictionary<string, string> optionalParams = null)
        {
            if (searchOptions == null) throw new ArgumentNullException(nameof(searchOptions));
            var queryString = searchOptions.GetQueryParamters();
            if (optionalParams != null && optionalParams.Count > 0)
                queryString = $"{queryString}&{optionalParams.GetQueryParameters()}";
            return $"{string.Format(TransactionSearchPath, transactionType)}?{queryString}";
        }

        private static string GetBusinessReviewPath(string id, Dictionary<string, string> optionalParams = null)
        {
            string queryParams = string.Empty;
            if (optionalParams != null && optionalParams.Count > 0)
            {
                queryParams = optionalParams.GetQueryParameters();
                if (!string.IsNullOrEmpty(queryParams)) queryParams = $"?{queryParams}";
            }
            return $"{string.Format(BusinessReviewPath, id)}{queryParams}";
        }

        private static string GetAutocompletePath(AutoCompleteOptions autoCompleteOptions,
            Dictionary<string, string> optionalParams = null)
        {
            if (autoCompleteOptions == null) throw new ArgumentNullException(nameof(autoCompleteOptions));

            var queryString = autoCompleteOptions.GetQueryParamters();
            if (optionalParams != null && optionalParams.Count > 0)
                queryString = $"{queryString}&{optionalParams.GetQueryParameters()}";

            return $"{AutocompletePath}?{queryString}";
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(ApiUrl)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static void ResponseHandle<T>(Task<HttpResponseMessage> responseTask, TaskCompletionSource<T> tcs)
        {
            responseTask.ContinueWith((responseAction) =>
            {
                var response = responseAction.Result;
                if (!response.IsSuccessStatusCode)
                {
                    response.Content.ReadAsStringAsync()
                   .ContinueWith((content) =>
                   {
                       throw ParseException((int)response.StatusCode, response.ReasonPhrase, content.Result);
                   });
                }
                response.Content.ReadAsStringAsync()
                    .ContinueWith((content) =>
                    {
                        try
                        {
                            tcs.SetResult(JsonConvert.DeserializeObject<T>(content.Result));
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }

                    });
            });
        }

        private static void DisposeHttpClient<T>(TaskCompletionSource<T> tcs, HttpClient client)
        {
            if (tcs.Task.IsCompleted)
            {
                client.Dispose();
            }
        }

        private static YelpFusionException ParseException(int code, string message, string responseBody)
        {
            if (responseBody == null)
            {
                return new UnExpectedFusionException(code, message);
            }

            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
            if (errorResponse?.Error == null)
            {
                return new UnExpectedFusionException(code, message);
            }

            var error = errorResponse.Error;
            switch (error.Code)
            {
                case "AREA_TOO_LARGE":
                    return new AreaTooLargeException(code, message, error);
                case "BAD_CATEGORY":
                    return new BadCategoryException(code, message, error);
                case "BUSINESS_UNAVAILABLE":
                    return new BusinessUnavailablException(code, message, error);
                case "EXCEEDED_REQS":
                    return new ExceededReqsException(code, message, error);
                case "INTERNAL_ERROR":
                    return new InternalException(code, message, error);
                case "VALIDATION_ERROR":
                    return new ValidationException(code, message, error);
                case "CLIENT_ERROR":
                    return new ClientException(code, message, error);
                case "TOKEN_MISSING":
                    return new TokenMissingException(code, message, error);
                case "INVALID_TOKEN":
                    return new InvalidTokenException(code, message, error);
                case "INVALID_PARAMETER":
                    return new InvalidParameterException(code, message, error);
                case "MISSING_PARAMETER":
                    return new MissingParameterException(code, message, error);
                case "MULTIPLE_LOCATIONS":
                    return new MultipleLocationsException(code, message, error);
                case "SSL_REQUIRED":
                    return new SslRequiredException(code, message, error);
                case "UNAVAILABLE_FOR_LOCATION":
                    return new UnavailableForLocationException(code, message, error);
                case "UNSPECIFIED_LOCATION":
                    return new UnspecifiedLocationException(code, message, error);
                default:
                    return new UnExpectedFusionException(code, message, error);
            }
        }
        #endregion
    }
}
