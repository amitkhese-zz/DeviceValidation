using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class HardwareInformationValidator : AbstractValidator<HardwareInformation>
    {
        public HardwareInformationValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.HardwareVersion);
            RuleFor(x => x.Imei).MinimumLength(14).MaximumLength(16);
            RuleFor(x => x.Manufacturer);
            RuleFor(x => x.Model);
            RuleFor(x => x.Simulated);
        }
    }
}
