namespace YelpFusion.Client.Exceptions
{
    public class MultipleLocationsException : YelpFusionException
    {
        public MultipleLocationsException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}