using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Coordinates
    {

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}