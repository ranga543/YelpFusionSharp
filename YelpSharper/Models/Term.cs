using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class Term
    {

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}