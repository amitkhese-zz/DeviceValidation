using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class SmsLogValidator : AbstractValidator<SmsLog>
    {
        public SmsLogValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Log).SetValidator(new SmsLogItemValidator());
        }
    }
}
