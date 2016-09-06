using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Location
    {

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
    }
}