namespace AHY.ToDoAppNTier.Common.ResponseObjects
{
    public interface IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
