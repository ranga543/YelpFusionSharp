# YelpFusion.Client
YelpSharper is a .NET wrapper for the Yelp REST API v3 developer preview. The library is written in C#.

For more information, visit the [Yelp REST API](https://www.yelp.com/developers/v3/preview)

## Installing 
In most cases, you're going to want to install the YelpSharp NuGet package.  Open up the Package Manager Console in Visual Studio, and run this command:

```
PM> Install-Package YelpFusion.Client -Version 1.0.2
```

# How to Use
```C#
//Create client instance
var yelpFusionClient = new YelpFusionClient();

//Get accesstoken using app client id & client secret
var tokenResponse = yelpFusionClient.GetToken("Your client id here", "Your client secret here");

//Assign token to make further API calls to Yelp
yelpFusionClient.AccessToken = tokenResponse.AccessToken;

//Search
var searchResponse = yelpFusionClient.Search(new BusinessSearchOptions{Term = "indian food", Latitude = 40.581140M, Longitude = -111.914184M});

//Search by phone
var searchByPhoneResponse = yelpFusionClient.SearchByPhone("+18014384823");

//Get business by id
var businessResponse = yelpFusionClient.GetBusiness("india-palace-south-jordan-2");

//Get business reviews
var reviewsResponse = yelpFusionClient.GetBusinessReviews("india-palace-south-jordan-2");

//Search by transaction type
var searchTransactionResponse = yelpFusionClient.SearchByTransaction("delivery", new TransactionSearchOptions { Latitude = 40.581140M, Longitude = -111.914184M });

//Autocomplete
var autocompleteResponse = yelpFusionClient.Autocomplete(new AutoCompleteOptions { Text = "india", Latitude = 40.581140M, Longitude = -111.914184M });
```
## Building the Source
If you want to build the source, clone the repository, and open up YelpSharp.sln.  

```
git clone https://github.com/ranga543/YelpFusionSharp.git
explorer YelpFusionSharp\YelpFusionSharp.sln
```

## Supported Platforms
YelpSharp targets .NET >=4.0.  If you would like support for other platforms, let me know.  


## Questions?
Feel free to submit an issue on the repository.
