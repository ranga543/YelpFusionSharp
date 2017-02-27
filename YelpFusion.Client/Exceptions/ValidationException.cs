namespace YelpFusion.Client.Exceptions
{
    public class ValidationException : YelpFusionException
    {
        public ValidationException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}