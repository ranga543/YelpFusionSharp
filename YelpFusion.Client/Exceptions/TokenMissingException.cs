namespace YelpFusion.Client.Exceptions
{
    public class TokenMissingException : YelpFusionException
    {
        public TokenMissingException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}