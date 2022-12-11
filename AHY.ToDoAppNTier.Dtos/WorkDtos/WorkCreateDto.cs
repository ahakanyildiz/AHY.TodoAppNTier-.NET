using AHY.ToDoAppNTier.Dtos.Abstract;

namespace AHY.ToDoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto : IDto
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }

}
