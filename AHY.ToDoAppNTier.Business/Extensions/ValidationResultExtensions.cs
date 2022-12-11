using AHY.ToDoAppNTier.Common.ResponseObjects;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AHY.ToDoAppNTier.Business.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach(var item in validationResult.Errors)
            {
                errors.Add(new CustomValidationError { PropertyName = item.PropertyName, ErrorMessage = item.ErrorMessage });
            }
            return errors;
        }
    }
}
