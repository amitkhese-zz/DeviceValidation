using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class RewardDefinitionValidatorTest : BaseValidatorTest
    {
        private readonly RewardDefinitionValidator validator =
            new RewardDefinitionValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateRewardDefinition();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidReward()
        {
            var model = CreateRewardDefinition();
            var invalidReward = new Reward()
            {
                RewardId = "ahhThisRewardIsInvalid",
                RewardMessage = "Unlucky!!! You cannot get this invalid reward",
                RewardType = RewardType.MESSAGE,
                RewardValue = 1,
                RewardUrl = "htps://someNoMakesensurl/rewards/ahhThisRewardIsInvalid"
            };
            model.Rewards.Add(invalidReward);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Rewards[1].RewardUrl");
        }
    }
}
