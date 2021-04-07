using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LocationOverrideByWifiValidatorTest : BaseValidatorTest
    {
        private readonly LocationOverrideByWifiValidator validator =
            new LocationOverrideByWifiValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateLocationOverrideByWifi();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(181, 91, 500)]
        [InlineData(-181, -91, 500)]
        public void InvalidLocationData(
            decimal invalidLongitude,
            decimal invalidLatitude,
            decimal invalidRadius)
        {
            var model = CreateLocationOverrideByWifi();

            model.Accuracy = invalidRadius;
            model.Latitude = invalidLatitude;
            model.Longitude = invalidLongitude;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Accuracy");
            result.ShouldHaveValidationErrorFor("Latitude");
            result.ShouldHaveValidationErrorFor("Longitude");
        }
    }
}
