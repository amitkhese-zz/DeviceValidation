using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class SoundSettingsValidator : AbstractValidator<SoundSettings>
    {
        public SoundSettingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.CallRingTone);
            RuleFor(x => x.Sound);
            RuleFor(x => x.NotificationTone);

            /*
                Sound Only = 0
                Sound + Vibration = 1
                Vibration Only = 2
             */
            RuleFor(x => x.RingMode).GreaterThanOrEqualTo(0).LessThanOrEqualTo(2);

            // Volume level of sound as a percentage. Low to High (- +) – 0 - 100
            RuleFor(x => x.Volume).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
