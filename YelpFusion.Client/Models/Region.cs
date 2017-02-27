using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace YelpFusion.Client.Models
{
    public class Region
    {
        [JsonProperty("center")]
        public Coordinates Center { get; set; }
    }
}
