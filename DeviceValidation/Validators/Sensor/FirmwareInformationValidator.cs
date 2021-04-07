using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class FirmwareInformationValidator : AbstractValidator<FirmwareInformation>
    {
        public FirmwareInformationValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.FirmwareFailureCode);
            RuleFor(x => x.FirmwareInstallationCode);
            RuleFor(x => x.FirmwareState);
            RuleFor(x => x.FirmwareUrl);
            RuleFor(x => x.FirmwareVersion);
            RuleFor(x => x.FirmwareTarget);
            RuleFor(x => x.FirmwareAppliesTo);
        }
    }
}
