﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FileContentAttribute : ValidationAttribute, IClientModelValidator
    {
        string contentType;
        public FileContentAttribute(string contentType)
        {
            this.contentType = contentType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is IFormFile formFile)
            {
                if (formFile.ContentType.ToLower().Contains(contentType.ToLower()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Pole {validationContext.MemberName} není typu {contentType}.");
                }
            }
            else
            {
                throw new NotImplementedException($"Pole {nameof(FileContentAttribute)} nepodporuje typ: {value.GetType()}");
            }
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-filecontent", $"Pole {context.ModelMetadata.Name} není typu {contentType}.");
            context.Attributes.Add("data-val-filecontent-type", contentType);
        }
    }
}