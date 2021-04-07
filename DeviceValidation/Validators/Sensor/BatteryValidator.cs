using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class BatteryValidator : AbstractValidator<Battery>
    {
        public const long MaxBatteryLevel = 100;
        public const long MinBatteryLevel = 0;

        public BatteryValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.BatteryLevel).InclusiveBetween(MinBatteryLevel, MaxBatteryLevel)
                .WithMessage("{PropertyName} must be within [" + MinBatteryLevel + " - " + MaxBatteryLevel + "] ");
        }
    }
}
