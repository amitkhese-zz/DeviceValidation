using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class TemperatureSettingsValidator : AbstractValidator<TemperatureSettings>
    {
        public TemperatureSettingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.LowerBoundThresholdTemperature);
            RuleFor(x => x.MaximumOperatingTemperature);
            RuleFor(x => x.MinimumOperatingTemperature);
            RuleFor(x => x.UpperBoundThresholdTemperature);
        }
    }
}
