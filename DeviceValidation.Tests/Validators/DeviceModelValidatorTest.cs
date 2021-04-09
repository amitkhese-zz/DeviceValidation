using System;
using System.Collections.Generic;
using DeviceV2.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators
{
    public class DeviceModelValidatorTest : BaseValidatorTest
    {
        private DeviceValidator validator;

        [Fact]
        public void DeviceModel_WithValidData_HappyPath()
        {

            // Given
            validator = new DeviceValidator("Other");
            var device = CreateDeviceData();

            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(99)]
        [InlineData(10)]
        public void DeviceModel_WithValidTrackerData_HappyPath(decimal invalidRadius)
        {

            // Given
            validator = new DeviceValidator("TRACKER");
            var device = CreateDeviceData();
            device.Location.Accuracy = invalidRadius;
            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(100.00001)]
        public void DeviceModel_WithInValidTrackerData_ShouldHaveValidationErrorFor(decimal invalidRadius)
        {

            // Given
            validator = new DeviceValidator("TRACKER");
            var device = CreateDeviceData();
            device.Location.Accuracy = invalidRadius;
            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldHaveValidationErrorFor("Location.Accuracy");
        }
    }
}
