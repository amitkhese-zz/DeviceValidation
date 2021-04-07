using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class MetaDataValidator : AbstractValidator<Metadata>
    {
        public MetaDataValidator()
        {
            RuleFor(x => x.LastUpdated)
                .TransformToNotNullableLong()
                .NotNull()
                .ValidateMillisecTimestamp();
            RuleFor(x => x.Version).NotNull();
            RuleFor(x => x.Source).NotNull();
        }
    }
}
