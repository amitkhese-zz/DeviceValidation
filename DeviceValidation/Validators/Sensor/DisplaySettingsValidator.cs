using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class DisplaySettingsValidator : AbstractValidator<DisplaySettings>
    {
        public DisplaySettingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
        }
    }
}
