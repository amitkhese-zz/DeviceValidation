using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class BatteryStatusValidatorTest : BaseValidatorTest
    {
        private readonly BatteryStatusValidator validator =
            new BatteryStatusValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateBatteryStatus();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
