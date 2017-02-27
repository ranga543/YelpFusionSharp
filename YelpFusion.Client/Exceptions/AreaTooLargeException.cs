namespace YelpFusion.Client.Exceptions
{
    public class AreaTooLargeException : YelpFusionException
    {
        public AreaTooLargeException(int responseCode, string responseMessage, Error error) 
            : base(responseCode, responseMessage, error)
        {

        }
    }
}