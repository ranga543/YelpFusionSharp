using System.Collections.Generic;
using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class AutoCompleteResponse : BaseResponse
    {
        [JsonProperty("terms")]
        public IList<Term> Terms { get; set; }

        [JsonProperty("businesses")]
        public IList<Business> Businesses { get; set; }

        [JsonProperty("categories")]
        public IList<Category> Categories { get; set; }
    }


}
