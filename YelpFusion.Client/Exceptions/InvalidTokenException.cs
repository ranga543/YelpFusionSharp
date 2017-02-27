namespace YelpFusion.Client.Exceptions
{
    public class InvalidTokenException : YelpFusionException
    {
        public InvalidTokenException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}