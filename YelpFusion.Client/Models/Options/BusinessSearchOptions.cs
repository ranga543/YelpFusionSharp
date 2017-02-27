using System.Collections.Generic;
using YelpFusion.Client.Attributes;

namespace YelpFusion.Client.Models.Options
{
    public class BusinessSearchOptions : BoundOptions
    {
        /// <summary>
        /// Optional. Search term (e.g. "food", "restaurants"). If term isn’t included we search everything. 
        /// The term keyword also accepts business names such as "Starbucks".
        /// </summary>
        [QueryParameter("term")]
        public string Term { get; set; }

        
        /// <summary>
        /// Optional. Search radius in meters. 
        /// If the value is too large, a AREA_TOO_LARGE error may be returned. 
        /// The max value is 40000 meters (25 miles).
        /// </summary>
        [QueryParameter("radius")]
        public int? Radius { get; set; }

        /// <summary>
        /// Optional. Categories to filter the search results with. See the list of supported categories
        /// </summary>
        //[QueryParameter("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Optional. Specify the locale to return the business information in. See the list of supported locales.
        /// </summary>
        [QueryParameter("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Optional. Number of business results to return. By default, it will return 20. Maximum is 50.
        /// </summary>
        [QueryParameter("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Optional. Offset the list of returned business results by this amount.
        /// </summary>
        [QueryParameter("offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Optional. Sort the results by one of the these modes: best_match, rating, review_count or distance.
        /// By default it's best_match. 
        /// The rating sort is not strictly sorted by the rating value, 
        /// but by an adjusted rating value that takes into account the number of ratings, 
        /// similar to a bayesian average. This is so a business with 1 rating of 5 stars doesn’t immediately jump to the top
        /// </summary>
        [QueryParameter("sort_by")]
        public string SortBy { get; set; }

        /// <summary>
        /// Optional. Pricing levels to filter the search result with: 1 = $, 2 = $$, 3 = $$$, 4 = $$$$. 
        /// The price filter can be a list of comma delimited pricing levels. 
        /// For example, "1, 2, 3" will filter the results to show the ones that are $, $$, or $$$.
        /// </summary>
        [QueryParameter("price")]
        public string Price { get; set; }

        /// <summary>
        /// Optional. Default to false. When set to true, only return the businesses open now. 
        /// Notice that open_at and open_now cannot be used together.
        /// </summary>
        [QueryParameter("open_now")]
        public bool? OpenNow { get; set; }

        /// <summary>
        /// Optional. An integer represending the Unix time in the same timezone of the search location. 
        /// If specified, it will return business open at the given time. 
        /// Notice that open_at and open_now cannot be used together.
        /// </summary>
        [QueryParameter("open_at")]
        public int? OpenAt { get; set; }

        /// <summary>
        /// Optional. Additional filters to restrict search results. Possible values are:
        /// hot_and_new - Hot and New businesses
        /// request_a_quote - Businesses that have the Request a Quote feature
        /// waitlist_reservation - Businesses that have an online waitlist
        /// cashback - Businesses that offer Cash Back
        /// deals - Businesses that offer Deals
        /// </summary>
        //[QueryParameter("attributes")]
        public List<string> Attributes { get; set; }

        /// <summary>
        /// Required if either latitude or longitude is not provided. 
        /// Specifies the combination of "address, neighborhood, city, state or zip, optional country" 
        /// to be used when searching for businesses.
        /// </summary>
        [QueryParameter("location")]
        public string Location { get; set; }

        [QueryParameter("attributes")]
        internal string GetAttributes
        {
            get
            {
                if (Attributes != null && Attributes.Count > 0)
                {
                    return string.Join(",", Attributes);
                }
                return string.Empty;
            }
        }

        [QueryParameter("categories")]
        internal string GetCategories
        {
            get
            {
                if (Categories != null && Categories.Count > 0)
                {
                    return string.Join(",", Categories);
                }
                return string.Empty;
            }
        }
    }
}