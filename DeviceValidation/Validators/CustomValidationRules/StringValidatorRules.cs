using System;
using System.Collections.Generic;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class StringValidatorRules
    {
        public const string NameValidatorRegex = @"\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+";
        public const string SemanticVersioningRegex = @"^(0|[1-9]\d*)(\.(0|[1-9]\d*)){0,3}$";
        public const string BSSIDRegex = @"(?:[A-Fa-f0-9]{2}[:-]){5}(?:[A-Fa-f0-9]{2})";
        public const string InternationalPhoneNumberRegex = @"(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})";
        public const string AllowedPhoneNumberSpecialCharsRegex = @"[+\s\(\)\.\-]";
        public const string NumbersOnlyRegex = @"^[0-9]*$";

        public static readonly IList<string> AllowedCameraOrientation = new List<string> { "0", "90", "180", "270" };

        public static IRuleBuilderOptions<T, string> ValidateURLString<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, urlString, context) =>
                Uri.TryCreate(urlString, UriKind.Absolute, out var uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be valid URL string.");
        }
    }
}
