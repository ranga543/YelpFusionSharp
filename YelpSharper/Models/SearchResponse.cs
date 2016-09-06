using System.Collections.Generic;
using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class SearchResponse : BaseResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("businesses")]
        public IList<Business> Businesses { get; set; }
    }


}
