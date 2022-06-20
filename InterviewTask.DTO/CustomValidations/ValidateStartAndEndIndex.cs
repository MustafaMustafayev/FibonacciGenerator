using System.ComponentModel.DataAnnotations;
using InterviewTask.DTO.FibonaccDTOs;

namespace InterviewTask.Core.CustomFilters
{
    public class ValidateStartAndEndIndex : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            FibonacciGeneratorDTO fibonacciGeneratorDTO = (FibonacciGeneratorDTO)validationContext.ObjectInstance;
            if (fibonacciGeneratorDTO.StartIndex < Convert.ToInt32(value))
            {
                return new ValidationResult("invalid end index");
            }

            return base.IsValid(value, validationContext);
        }
    }
}