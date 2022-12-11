using System.Collections.Generic;

namespace AHY.ToDoAppNTier.Common.ResponseObjects
{
    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
