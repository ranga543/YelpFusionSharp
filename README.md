# YelpSharper
YelpSharper is a .NET wrapper for the Yelp REST API v3 developer preview. The library is written in C#.

For more information, visit the [Yelp REST API](https://www.yelp.com/developers/v3/preview)

## Installing 
In most cases, you're going to want to install the YelpSharp NuGet package.  Open up the Package Manager Console in Visual Studio, and run this command:

```
PM> Install-Package YelpSharper
```

# How to Use
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
## Building the Source
If you want to build the source, clone the repository, and open up YelpSharp.sln.  

```
git clone https://github.com/ranga543/YelpSharper.git
explorer YelpSharper\YelpSharper.sln
```

## Supported Platforms
YelpSharp targets .NET >=4.0.  If you would like support for other platforms, let me know.  


## Questions?
Feel free to submit an issue on the repository.
