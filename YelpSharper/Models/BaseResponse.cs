using Newtonsoft.Json;

namespace YelpSharper.Models
{
    public class BaseResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}