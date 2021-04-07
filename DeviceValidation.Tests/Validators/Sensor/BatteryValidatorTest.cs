using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class BatteryValidatorTest : BaseValidatorTest
    {
        private readonly BatteryValidator validator =
            new BatteryValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateBattery();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void InvalidBatteryLevelObject(int invalidBatteryLevel)
        {
            var model = CreateBattery();
            model.BatteryLevel = invalidBatteryLevel;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("BatteryLevel")
                .WithErrorMessage("Battery Level must be within [0 - 100] ");
        }
    }
}
