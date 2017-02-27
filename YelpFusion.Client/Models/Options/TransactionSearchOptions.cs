using YelpFusion.Client.Attributes;

namespace YelpFusion.Client.Models.Options
{
    public class TransactionSearchOptions : BoundOptions
    {
        /// <summary>
        /// Required if either latitude or longitude is not provided. 
        /// Specifies the combination of "address, neighborhood, city, state or zip, optional country" 
        /// to be used when searching for businesses.
        /// </summary>
        [QueryParameter("location")]
        public string Location { get; set; }
    }
}