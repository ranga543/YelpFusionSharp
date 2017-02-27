using YelpFusion.Client.Attributes;

namespace YelpFusion.Client.Models.Options
{
    public class AutoCompleteOptions : BoundOptions
    {
        /// <summary>
        /// Required. Text to return autocomplete suggestions for.
        /// </summary>
        [QueryParameter("text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. Specify the locale to return the autocomplete suggestions in. See the list of supported locales.
        /// </summary>
        [QueryParameter("locale")]
        public string Locale { get; set; }
    }
}