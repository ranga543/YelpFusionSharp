using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class SearchResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("businesses")]
        public IList<Business> Businesses { get; set; }
    }
}
