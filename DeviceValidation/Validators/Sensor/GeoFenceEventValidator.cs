using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class GeoFenceEventValidator : AbstractValidator<GeoFenceEvent>
    {
        public GeoFenceEventValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.GeofenceID);
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
