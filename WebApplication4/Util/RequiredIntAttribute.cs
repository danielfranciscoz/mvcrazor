using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Util
{
    public class RequiredIntAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var inputValue = int.Parse(value.ToString());

            
            return inputValue != 0?ValidationResult.Success:new ValidationResult("Error");

        }
    }
}

