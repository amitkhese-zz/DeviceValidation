using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class TemperatureSettingsValidatorTest : BaseValidatorTest
    {
        private readonly TemperatureSettingsValidator validator =
            new TemperatureSettingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateTemperatureSettings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
