namespace YelpFusion.Client.Exceptions
{
    public class BusinessUnavailablException : YelpFusionException
    {
        public BusinessUnavailablException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}