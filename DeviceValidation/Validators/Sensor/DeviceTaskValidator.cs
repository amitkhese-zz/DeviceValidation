using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class DeviceTaskValidator : AbstractValidator<DeviceTask>
    {
        public DeviceTaskValidator()
        {
            RuleFor(x => x.Id);

            // TODO: This value needs to be updated on OpenAPI to be long according to confluence
            // and check as millisec value
            RuleFor(x => x.Date);
            RuleFor(x => x.Days).ValidateRepeatedDays();
            RuleFor(x => x.Message);
            RuleFor(x => x.Reminder);
            RuleFor(x => x.RewardId);
            RuleFor(x => x.Silent);
            RuleFor(x => x.Title);
        }
    }
}
