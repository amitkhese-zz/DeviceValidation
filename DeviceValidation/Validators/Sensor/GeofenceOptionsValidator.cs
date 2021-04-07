using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class GeofenceOptionsValidator : AbstractValidator<GeofenceOptions>
    {
        public GeofenceOptionsValidator()
        {
            RuleFor(x => x.Days).ValidateRepeatedDays();
        }
    }
}
