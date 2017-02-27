using System;

namespace YelpFusion.Client.Exceptions
{
    public abstract class YelpFusionException : Exception
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Error Error { get; set; }
        public override string Message
            => !string.IsNullOrEmpty(Error?.Description) ? Error.Description : ResponseMessage;

        protected YelpFusionException(int responseCode, string responseMessage)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }

        protected YelpFusionException(int responseCode, string responseMessage, Error error)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            Error = error;
        }
    }
}