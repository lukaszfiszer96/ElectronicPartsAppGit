using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.Domain.Validation
{
    class ValidatePrice : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var electronicPart = (ElectronicPart)validationContext.ObjectInstance;

            if (electronicPart.Price <= 0)
                return new ValidationResult("Cena musi być liczbą dodatnią");
            else if (electronicPart.Price == null)
                return new ValidationResult("Wprowadz cenę");
            else
                return ValidationResult.Success;
        }
    }
}
