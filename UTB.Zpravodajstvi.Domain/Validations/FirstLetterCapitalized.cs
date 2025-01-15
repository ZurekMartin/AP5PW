using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UTB.Zpravodajstvi.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FirstLetterCapitalizedCZAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is string text)
            {
                if (text == String.Empty)
                    return ValidationResult.Success;

                if (text.First() >= 'A' && text.First() <= 'Z'
                 || text.First() == 'Š' || text.First() == 'Č' || text.First() == 'Ř' || text.First() == 'Ž'
                 || text.First() == 'Ý' || text.First() == 'Á' || text.First() == 'Í' || text.First() == 'É'
                 || text.First() == 'Ú' || text.First() == 'Ď' || text.First() == 'Ň' || text.First() == 'Ó'
                 || text.First() == 'Ť' || text.First() == 'Ě' || text.First() == 'Ů')
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Pole {validationContext.MemberName} musí začínat velkým písmenem.");
                }
            }
            else
            {
                throw new NotImplementedException($"Pole {nameof(FirstLetterCapitalizedCZAttribute)} nepodporuje typ: {value.GetType()}");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-firstlettercapcz", $"Pole {context.ModelMetadata.Name} musí začínat velkým písmenem.");
        }
    }
}