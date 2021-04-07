using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LocationValidatorTest : BaseValidatorTest
    {
        private readonly LocationValidator validator =
            new LocationValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateLocation();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(181, 91, 500)]
        [InlineData(-181, -91, 500.00001)]
        public void InvalidLocationData(
            decimal invalidLongitude,
            decimal invalidLatitude,
            decimal invalidRadius)
        {
            var model = CreateLocation();

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
