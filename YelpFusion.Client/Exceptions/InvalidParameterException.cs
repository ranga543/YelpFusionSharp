namespace YelpFusion.Client.Exceptions
{
    public class InvalidParameterException : YelpFusionException
    {
        public InvalidParameterException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}