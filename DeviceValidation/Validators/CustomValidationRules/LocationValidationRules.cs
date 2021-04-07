using System;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class LocationValidationRules
    {
        public const decimal FarNorth = 90;
        public const decimal FarSouth = -90;
        public const decimal FarWest = 180;
        public const decimal FarEast = -180;
        public const decimal AccuracyMaxLevel = 500.0M;

        public static IRuleBuilderOptions<T, decimal>
            ValidateLatitude<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder
                .LessThanOrEqualTo(FarNorth)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be less than or equal to [" + FarNorth + "]")
                .GreaterThanOrEqualTo(FarSouth)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be greater than or equal to [" + FarSouth + "]");
        }

        public static IRuleBuilderOptions<T, decimal>
            ValidateLongitude<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder
                .LessThanOrEqualTo(FarWest)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be less than or equal to [" + FarWest + "]")
                .GreaterThanOrEqualTo(FarEast)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be greater than or equal to [" + FarEast + "]");
        }

        public static IRuleBuilderOptions<T, decimal>
            ValidateRadius<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder.LessThan(AccuracyMaxLevel)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] cannot be greater than [" + AccuracyMaxLevel + "].");
        }
    }
}
