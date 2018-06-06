using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fias.Infrastructure.Attributes
{
    public class RussianRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = (string) value;
            if (str.Any(l => l < 127 && l > 58))
            {
                return new ValidationResult($"Поле \"{validationContext.DisplayName}\" не должно содержать латинские символы");
            }
            return ValidationResult.Success;
        }
    }
}
