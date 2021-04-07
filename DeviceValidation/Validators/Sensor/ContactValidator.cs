using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.IconUrl)
                .ValidateURLString()
                .When(x => !string.IsNullOrWhiteSpace(x.IconUrl));

            RuleFor(x => x.Msisdn).ValidateMSISDN();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Emergency).IsBoolean();
        }
    }
}
