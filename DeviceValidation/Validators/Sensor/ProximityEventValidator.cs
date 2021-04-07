using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class ProximityEventValidator : AbstractValidator<ProximityEvent>
    {
        public ProximityEventValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.CloseToObject);
        }
    }
}
