namespace YelpFusion.Client.Exceptions
{
    public class SslRequiredException : YelpFusionException
    {
        public SslRequiredException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}