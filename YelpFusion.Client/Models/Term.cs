using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class Term
    {

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}