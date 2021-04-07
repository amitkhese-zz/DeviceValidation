using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class GeofenceValidator : AbstractValidator<Geofence>
    {
        public GeofenceValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Options).SetValidator(new GeofenceOptionsValidator());
            RuleForEach(x => x.Points).SetValidator(new GeofencePointValidator());
        }
    }
}
