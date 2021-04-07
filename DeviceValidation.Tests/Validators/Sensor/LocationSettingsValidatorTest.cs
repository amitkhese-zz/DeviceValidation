using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LocationSettingsValidatorTest : BaseValidatorTest
    {
        private readonly LocationSettingsValidator validator =
            new LocationSettingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateLocationSettings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
