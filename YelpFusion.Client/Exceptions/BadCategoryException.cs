namespace YelpFusion.Client.Exceptions
{
    public class BadCategoryException : YelpFusionException
    {
        public BadCategoryException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}