using AHY.ToDoAppNTier.Dtos.WorkDtos;
using FluentValidation;


namespace AHY.ToDoAppNTier.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition boş olamaz.");
        }
    }
}
