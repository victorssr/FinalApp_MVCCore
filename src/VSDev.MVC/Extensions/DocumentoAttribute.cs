using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using VSDev.Business.Models.Validations;

namespace VSDev.MVC.Extensions
{
    public class DocumentoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string documento = value.ToString();

            if (documento.Length <= 11)
            {
                if (!CpfValidation.Validar(documento))
                    return new ValidationResult("O CPF informado é inválido.");
            }
            else
            {
                if (!CnpjValidation.Validar(documento))
                    return new ValidationResult("O CNPJ informado é inválido.");
            }

            return ValidationResult.Success;
        }
    }

    public class DocumentoAttributeAdapter : AttributeAdapterBase<DocumentoAttribute>
    {
        public DocumentoAttributeAdapter(DocumentoAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-documento", GetErrorMessage(context));
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return "Documento inválido";
        }
    }

    public class DocumentoValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is DocumentoAttribute documentoAttribute)
                return new DocumentoAttributeAdapter(documentoAttribute, stringLocalizer);

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }

}
