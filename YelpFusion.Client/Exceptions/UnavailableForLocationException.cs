namespace YelpFusion.Client.Exceptions
{
    public class UnavailableForLocationException : YelpFusionException
    {
        public UnavailableForLocationException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}