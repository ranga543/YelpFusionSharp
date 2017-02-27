using System.Collections.Generic;
using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class AutoCompleteResponse
    {
        [JsonProperty("terms")]
        public IList<Term> Terms { get; set; }

        [JsonProperty("businesses")]
        public IList<Business> Businesses { get; set; }

        [JsonProperty("categories")]
        public IList<Category> Categories { get; set; }
    }


}
