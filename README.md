# YelpSharper
YelpSharper is a .NET wrapper for the Yelp REST API. The library is written in C#.
# Code Example
```C#
//Create client instance
var yelpSharperClient = new YelpSharperClient();

//Get accesstoken using app client id & client secret
var tokenResponse = yelpSharperClient.GetToken("Your client id here", "Your client secret here");

//Assign token to make further API calls to Yelp
yelpSharperClient.AccessToken = tokenResponse.AccessToken;

//Search
var searchResponse = yelpSharperClient.Search(new {term = "indian food", latitude = "40.581140", longitude = "-111.914184"});

//Search by phone
var searchByPhoneResponse = yelpSharperClient.SearchByPhone(new {phone = "+18014384823"});

//Get business by id
var businessResponse = yelpSharperClient.GetBusiness("india-palace-south-jordan-2");

//Get business reviews
var reviewsResponse = yelpSharperClient.GetBusinessReviews("india-palace-south-jordan-2");

//Search by transaction type
var searchTransactionResponse = yelpSharperClient.SearchByTransaction("delivery", new { latitude = "40.581140", longitude = "-111.914184" });

//Autocomplete
var autocompleteResponse = yelpSharperClient.Autocomplete(new { text = "india", latitude = "40.581140", longitude = "-111.914184" });
```
