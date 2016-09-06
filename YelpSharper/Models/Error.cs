using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Error
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}