using System.Collections.Generic;
using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class ReviewResponse
    {
        [JsonProperty("reviews")]
        public IList<Review> Reviews { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

}
