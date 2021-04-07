using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class TemperatureValidatorTest : BaseValidatorTest
    {
        private readonly TemperatureValidator validator =
            new TemperatureValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateTemperature();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
