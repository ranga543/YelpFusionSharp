namespace YelpFusion.Client.Exceptions
{
    public class UnExpectedFusionException : YelpFusionException
    {
        public UnExpectedFusionException(int responseCode, string responseMessage) 
            : base(responseCode, responseMessage)
        {
            
        }

        public UnExpectedFusionException(int responseCode, string responseMessage, Error error) 
            : base(responseCode, responseMessage, error)
        {

        }
    }
}