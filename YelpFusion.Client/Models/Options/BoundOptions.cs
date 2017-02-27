using YelpFusion.Client.Attributes;

namespace YelpFusion.Client.Models.Options
{
    public class BoundOptions
    {

        /// <summary>
        /// Required if location is not provided. Latitude of the location you want to search near by.
        /// </summary>
        [QueryParameter("latitude")]
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Required if location is not provided. Longitude of the location you want to search near by.
        /// </summary>
        [QueryParameter("longitude")]
        public decimal? Longitude { get; set; }

    }
}