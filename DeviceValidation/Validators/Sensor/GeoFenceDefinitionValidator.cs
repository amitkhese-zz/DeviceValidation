using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class GeoFenceDefinitionValidator : AbstractValidator<GeoFenceDefinition>
    {
        public GeoFenceDefinitionValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.GeoFen).SetValidator(new GeofenceValidator());
        }
    }
}
