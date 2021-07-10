using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Util
{
    public class NotAllowedIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("El no valor puede ser nulo");
            }

            int IdProhibido = int.Parse(value.ToString());
            return IdProhibido == 0 ? new ValidationResult("El elemento prohibido no puede ser seleccionado")
                : ValidationResult.Success;
        }
    }
}
