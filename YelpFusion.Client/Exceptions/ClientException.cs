namespace YelpFusion.Client.Exceptions
{
    public class ClientException : YelpFusionException
    {
        public ClientException(int responseCode, string responseMessage, Error error)
            : base(responseCode, responseMessage, error)
        {

        }
    }
}