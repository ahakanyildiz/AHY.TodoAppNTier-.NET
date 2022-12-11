using AHY.ToDoAppNTier.Dtos.Abstract;


namespace AHY.ToDoAppNTier.Dtos.WorkDtos
{
    public class WorkUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
