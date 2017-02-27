namespace YelpFusion.Client.Exceptions
{
    public class UnspecifiedLocationException : YelpFusionException
    {
        public UnspecifiedLocationException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}