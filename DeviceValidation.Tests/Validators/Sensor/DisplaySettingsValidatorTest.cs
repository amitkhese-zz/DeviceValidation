using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class DisplaySettingsValidatorTest : BaseValidatorTest
    {
        private readonly DisplaySettingsValidator validator =
            new DisplaySettingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateDisplaySettings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
