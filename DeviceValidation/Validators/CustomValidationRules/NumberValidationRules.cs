using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class NumberValidationRules
    {
        private const int MinimumAllowedMsisdnLength = 10;
        private const int MaximumAllowedMsisdnLength = 15;

        public static IRuleBuilderOptions<T, string> ValidateMSISDN<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must((rootObject, msisdn, context) =>
                {
                    var strippedMsisdn = Regex.Replace(
                        msisdn, StringValidatorRules.AllowedPhoneNumberSpecialCharsRegex, string.Empty);
                    var hasOnlyNumbers = Regex.Match(strippedMsisdn, StringValidatorRules.NumbersOnlyRegex);

                    if (!hasOnlyNumbers.Success)
                    {
                        return false;
                    }

                    if (strippedMsisdn.Length < MinimumAllowedMsisdnLength)
                    {
                        return false;
                    }

                    if (strippedMsisdn.Length > MaximumAllowedMsisdnLength)
                    {
                        return false;
                    }

                    return true;
                })
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be valid Phone Number");
        }

        public static IRuleBuilderOptions<T, string> ValidateStringParseToInt<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, strNumber, context) =>
                    int.TryParse(strNumber, out var number))
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be number string.");
        }
    }
}
