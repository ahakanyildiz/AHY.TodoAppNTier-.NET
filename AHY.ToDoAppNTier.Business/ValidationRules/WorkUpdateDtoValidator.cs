using AHY.ToDoAppNTier.Dtos.WorkDtos;
using FluentValidation;


namespace AHY.ToDoAppNTier.Business.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş geçilemez.");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition boş geçilemez");
        }
    }
}
