using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class SosEventValidator : AbstractValidator<SosEvent>
    {
        public SosEventValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
        }
    }
}
