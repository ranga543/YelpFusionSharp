namespace YelpFusion.Client.Exceptions
{
    public class MissingParameterException : YelpFusionException
    {
        public MissingParameterException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}