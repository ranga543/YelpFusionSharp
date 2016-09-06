using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Category
    {

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}