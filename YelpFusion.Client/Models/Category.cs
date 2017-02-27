using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class Category
    {

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}