namespace YelpFusion.Client.Exceptions
{
    public class InternalException : YelpFusionException
    {
        public InternalException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}