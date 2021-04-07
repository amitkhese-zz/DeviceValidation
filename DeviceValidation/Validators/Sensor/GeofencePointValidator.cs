using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class GeofencePointValidator : AbstractValidator<GeofencePoint>
    {
        public GeofencePointValidator()
        {
            RuleFor(x => x.Latitude).ValidateLatitude();
            RuleFor(x => x.Longitude).ValidateLongitude();
        }
    }
}
