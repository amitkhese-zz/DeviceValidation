using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class LightEventValidator : AbstractValidator<LightEvent>
    {
        public LightEventValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.LightChange).IsInEnum();
        }
    }
}
