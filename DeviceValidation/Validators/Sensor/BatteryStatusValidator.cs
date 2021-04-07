using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class BatteryStatusValidator : AbstractValidator<BatteryStatus>
    {
        public BatteryStatusValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
