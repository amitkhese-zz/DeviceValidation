using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class LocationSettingsValidator : AbstractValidator<LocationSettings>
    {
        public LocationSettingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.EndLiveTimestamp);
            RuleFor(x => x.Frequency);
            RuleFor(x => x.GatherDuration);
            RuleFor(x => x.LiveDuration);
            RuleFor(x => x.LiveFrequency);
            RuleFor(x => x.LiveGatherDuration);
            RuleFor(x => x.LiveSendDuration);
            RuleFor(x => x.LocalGeoFence);
            RuleFor(x => x.SendDuration);
            RuleFor(x => x.State).IsInEnum();
        }
    }
}
