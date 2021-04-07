using System;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class TransformationRules
    {
        public static IRuleBuilder<T, long> TransformToNotNullableLong<T>(this IRuleBuilderInitial<T, long?> ruleBuilder)
        {
            return ruleBuilder.Transform(value => value.GetValueOrDefault());
        }

        public static IRuleBuilder<T, decimal> TransformToNotNullableDecimal<T>(this IRuleBuilderInitial<T, decimal?> ruleBuilder)
        {
            return ruleBuilder.Transform(value => value.GetValueOrDefault());
        }
    }
}
