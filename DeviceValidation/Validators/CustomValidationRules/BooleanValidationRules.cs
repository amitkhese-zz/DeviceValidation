using System;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class BooleanValidationRules
    {
        public static IRuleBuilderOptions<T, bool?> IsBoolean<T>(this IRuleBuilderInitial<T, bool?> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, boolenVal, context) =>
            {
                if (boolenVal is bool)
                {
                    return true;
                }

                return false;
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be boolean.");
        }
    }
}
