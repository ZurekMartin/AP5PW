using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UTB.Zpravodajstvi.Domain.Validations
{
    public class StrongPasswordAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string password = value.ToString();
            
            if (password.Length < 8)
                return new ValidationResult("Heslo musí být dlouhé minimálně 8 znaků");

            if (!password.Any(char.IsUpper))
                return new ValidationResult("Heslo musí obsahovat alespoň jedno velké písmeno");

            if (!password.Any(char.IsLower))
                return new ValidationResult("Heslo musí obsahovat alespoň jedno malé písmeno");

            if (!password.Any(char.IsDigit))
                return new ValidationResult("Heslo musí obsahovat alespoň jednu číslici");

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-strongpassword", "Heslo nesplňuje požadavky na bezpečnost");
        }
    }

    public class CzechPhoneAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string phone = value.ToString();
            if (!Regex.IsMatch(phone, @"^(\+420)?\s?[1-9][0-9]{2}\s?[0-9]{3}\s?[0-9]{3}$"))
                return new ValidationResult("Telefonní číslo musí být ve formátu +420 XXX XXX XXX nebo XXX XXX XXX");

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-czechphone", "Neplatný formát telefonního čísla");
        }
    }

    public class ValidUsernameAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string username = value.ToString();
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_-]+$"))
                return new ValidationResult("Uživatelské jméno může obsahovat pouze písmena, čísla, pomlčky a podtržítka");

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-validusername", "Neplatný formát uživatelského jména");
        }
    }
} 