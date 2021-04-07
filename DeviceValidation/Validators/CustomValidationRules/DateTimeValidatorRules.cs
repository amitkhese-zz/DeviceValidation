using System;
using System.Collections.Generic;
using DeviceV2.Util;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class DateTimeValidatorRules
    {
        public const long MaxUnixTimeStampMillis = 100000000000000; // Wed Nov 16 5138 09:46:40

        public static IRuleBuilderOptions<T, string> ValidateStringOptionalTimeStamp<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, stringTimestamp, context) =>
            {
                if (stringTimestamp == null || DateTime.TryParse(stringTimestamp, out var temp) == true)
                {
                    return true;
                }

                return false;
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be a valid timestamp.");
        }

        public static IRuleBuilderOptions<T, string> ValidateStringTimeStamp<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, stringTimestamp, context) =>
            {
                if (DateTime.TryParse(stringTimestamp, out var temp) == true)
                {
                    return true;
                }

                return false;
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be a valid timestamp.");
        }

        public static IRuleBuilderOptions<T, Dictionary<string, bool>>
            ValidateRepeatedDays<T>(this IRuleBuilder<T, Dictionary<string, bool>> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, days, context) =>
            {
                // Days is optional
                if (days == null)
                {
                    return true;
                }

                /*  Allowed Keys:
                    "1": true --Sunday
                    "2": true --Monday
                    "3": bool --Tuesday
                    "4": bool --Wednesday
                    "5": bool --Thursday
                    "6": bool --Friday
                    "7": true --Saturday
                */

                var allowedKeys = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
                var keys = new List<string>(days.Keys);

                context.MessageFormatter
                    .AppendArgument("AllowedKeys", allowedKeys.ConvertListToString(", "))
                    .AppendArgument("Keys", keys);

                if (keys.Count != allowedKeys.Count)
                {
                    return false;
                }

                foreach (var key in keys)
                {
                    if (!allowedKeys.Contains(key))
                    {
                        return false;
                    }
                }

                return true;
            }).WithMessage("[{PropertyName}] Dictionary must contain valid keys of [{AllowedKeys}], passed [{Keys}]");
        }

        public static IRuleBuilderOptions<T, long> ValidateMillisecTimestamp<T>(this IRuleBuilder<T, long> ruleBuilder)
        {
            return ruleBuilder.LessThanOrEqualTo(MaxUnixTimeStampMillis)
                .WithMessage("[{PropertyName}] of [{PropertyValue}] must be a valid timestamp.");
        }
    }
}
