using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class RewardValidation : AbstractValidator<Reward>
    {
        public RewardValidation()
        {
            RuleFor(x => x.RewardId);
            RuleFor(x => x.RewardMessage);
            RuleFor(x => x.RewardType).IsInEnum();
            RuleFor(x => x.RewardValue);
            RuleFor(x => x.RewardUrl).ValidateURLString();
        }
    }
}
