using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace VSDev.MVC.Extensions.Attributes
{
    public class DecimalAttribute : ValidationAttribute
    {
        public bool AllowZero { get; set; } = false;
        public string Prefix { get; set; } = "";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string inputValue = value.ToString().Replace(Prefix, "");
                var testValue = Convert.ToDecimal(inputValue, new CultureInfo("pt-BR"));
            }
            catch
            {
                return new ValidationResult("Informe um valor decimal válido");
            }

            return ValidationResult.Success;
        }
    }

    public class DecimalAttributeAdapter : AttributeAdapterBase<DecimalAttribute>
    {
        private readonly bool _allowZero;
        private readonly string _prefix;

        public DecimalAttributeAdapter(DecimalAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
            _allowZero = attribute.AllowZero;
            _prefix = attribute.Prefix;
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-decimal", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-number", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-thousands", ".");
            MergeAttribute(context.Attributes, "data-decimal", ",");

            if (!string.IsNullOrEmpty(_prefix)) MergeAttribute(context.Attributes, "data-prefix", "R$ ");
            if (_allowZero) MergeAttribute(context.Attributes, "data-allow-zero", "true");
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return "Informe um valor decimal válido";
        }
    }

    public class DecimalValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _adapterProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is DecimalAttribute decimalAttribute)
            {
                return new DecimalAttributeAdapter(decimalAttribute, stringLocalizer);
            }

            return _adapterProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
