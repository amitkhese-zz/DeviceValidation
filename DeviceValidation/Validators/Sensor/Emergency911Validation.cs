using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class Emergency911Validation : AbstractValidator<Emergency911>
    {
        public Emergency911Validation()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
        }
    }
}
