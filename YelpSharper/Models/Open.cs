using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Open
    {

        [JsonProperty("is_overnight")]
        public bool IsOvernight { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }
    }
}