namespace YelpFusion.Client.Exceptions
{
    public class ExceededReqsException : YelpFusionException
    {
        public ExceededReqsException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}