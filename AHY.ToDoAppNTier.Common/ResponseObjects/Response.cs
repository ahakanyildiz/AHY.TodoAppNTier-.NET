namespace AHY.ToDoAppNTier.Common.ResponseObjects
{
    public class Response : IResponse //Genelde result olarak kullanılır, ben Response demeyi tercih ettim.
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType,string message)
        {
            ResponseType = responseType;
            Message = message;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}
