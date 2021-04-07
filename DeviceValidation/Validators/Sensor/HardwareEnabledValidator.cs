using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class HardwareEnabledValidator : AbstractValidator<HardwareEnabled>
    {
        public HardwareEnabledValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.AirplaneMode);
            RuleFor(x => x.Camera);
            RuleFor(x => x.CameraOrientation)
                .Must(v => StringValidatorRules.AllowedCameraOrientation.Contains(v));
            RuleFor(x => x.LightSensor);
            RuleFor(x => x.SilentMode);
            RuleFor(x => x.TemperatureSensor);
        }
    }
}
