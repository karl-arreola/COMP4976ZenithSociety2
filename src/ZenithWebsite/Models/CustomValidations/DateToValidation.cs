using System;
using System.ComponentModel.DataAnnotations;

namespace ZenithWebsite.Models.CutomValidations
{
    class DateToValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentEvent = (Models.Event)validationContext.ObjectInstance;
            DateTime dateTo = Convert.ToDateTime(value);
            DateTime dateFrom = Convert.ToDateTime(currentEvent.DateFrom);

            if (dateTo > dateFrom)
            {
                return ValidationResult.Success;
            }
            else
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
        }
    }
}
