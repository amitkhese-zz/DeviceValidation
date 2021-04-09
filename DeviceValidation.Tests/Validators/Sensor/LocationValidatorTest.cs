using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LocationValidatorTest : BaseValidatorTest
    {
        private LocationValidator validator;
            
        [Fact]
        public void HappyPath()
        {
            validator = new LocationValidator("Product1");
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
            validator = new LocationValidator("Product1");
            var model = CreateLocation();

            model.Accuracy = invalidRadius;
            model.Latitude = invalidLatitude;
            model.Longitude = invalidLongitude;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Accuracy");
            result.ShouldHaveValidationErrorFor("Latitude");
            result.ShouldHaveValidationErrorFor("Longitude");
        }

        [Fact]
        public void validLocationAccuracyData_WithTrackerProduct_ShouldNotHaveAnyValidationErrors()
        {
            validator = new LocationValidator("TRACKER");
            var model = CreateLocation();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void validLocationAccuracyData_WithNullProduct_ShouldNotHaveAnyValidationErrors()
        {
            validator = new LocationValidator(null);
            var model = CreateLocation();

            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void validLocationAccuracyData_WithEmptyProduct_ShouldNotHaveAnyValidationErrors()
        {
            validator = new LocationValidator(string.Empty);
            var model = CreateLocation();

            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(100.00001)]
        public void InvalidLocationAccuracyData_WithTrackerProduct_ShouldHaveValidationError(decimal invalidRadius)
        {
            validator = new LocationValidator("TRACKER");
            var model = CreateLocation();

            model.Accuracy = invalidRadius;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Accuracy");
        }

        [Fact]
        public void validLocationAccuracyData_WithProduct2_ShouldNotHaveAnyValidationErrors()
        {
            validator = new LocationValidator("Product2");
            var model = CreateLocation();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(200)]
        [InlineData(200.00001)]
        public void InvalidLocationAccuracyData_WithProduct2_ShouldHaveValidationError(decimal invalidRadius)
        {
            validator = new LocationValidator("Product2");
            var model = CreateLocation();

            model.Accuracy = invalidRadius;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Accuracy");
        }
    }
}
