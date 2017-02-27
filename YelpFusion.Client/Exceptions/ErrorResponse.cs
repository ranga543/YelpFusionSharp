using Newtonsoft.Json;

namespace YelpFusion.Client.Exceptions
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}