using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class SmsLogItemValidator : AbstractValidator<SmsLogItem>
    {
        public SmsLogItemValidator()
        {
            RuleFor(x => x.Direction)
                .TransformToNotNullableLong()
                .ValidateMessageDirection();
            RuleFor(x => x.From).ValidateMSISDN();
            RuleForEach(x => x.To).ValidateMSISDN();
            RuleFor(x => x.Timestamp)
                .TransformToNotNullableLong()
                .ValidateMillisecTimestamp();
            RuleFor(x => x.Type)
                .TransformToNotNullableLong()
                .ValidateMessageType();
        }
    }
}
