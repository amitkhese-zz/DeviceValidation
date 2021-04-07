using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class CallLogItemValidator : AbstractValidator<CallLogItem>
    {
        public CallLogItemValidator()
        {
            RuleFor(x => x.Type).TransformToNotNullableLong().ValidateCallType();
            RuleFor(x => x.Duration);
            RuleFor(x => x.Msisdn).ValidateMSISDN();
            RuleFor(x => x.ContactId);
            RuleFor(x => x.Timestamp)
                .TransformToNotNullableLong()
                .ValidateMillisecTimestamp();
        }
    }
}
