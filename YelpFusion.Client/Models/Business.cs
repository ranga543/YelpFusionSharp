using System.Collections.Generic;
using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class Business
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("review_count")]
        public int ReviewCount { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("photos")]
        public IList<string> Photos { get; set; }

        [JsonProperty("hours")]
        public IList<Hour> Hours { get; set; }

        [JsonProperty("categories")]
        public IList<Category> Categories { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("display_phone")]
        public string DisplayPhone { get; set; }

        [JsonProperty("is_claimed")]
        public bool IsClaimed { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("cross_streets")]
        public string CrossStreets { get; set; }
    }
}