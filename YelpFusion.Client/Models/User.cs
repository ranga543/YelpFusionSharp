using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class User
    {

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}