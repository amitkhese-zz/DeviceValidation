using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class ResultValidator : AbstractValidator<Results>
    {
        public ResultValidator()
        {
            RuleFor(x => x.Count).GreaterThan(0); // Count cannot be negative 
            RuleFor(x => x.StartTime)
                .TransformToNotNullableLong()
                .GreaterThan(0)
                .LessThan(x => x.EndTime)
                .ValidateMillisecTimestamp();
            RuleFor(x => x.EndTime)
                .TransformToNotNullableLong()
                .GreaterThan(0)
                .GreaterThan(x => x.StartTime)
                .ValidateMillisecTimestamp();
        }
    }
}
