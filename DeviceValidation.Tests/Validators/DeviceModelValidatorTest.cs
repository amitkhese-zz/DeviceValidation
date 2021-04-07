using System;
using System.Collections.Generic;
using DeviceV2.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators
{
    public class DeviceModelValidatorTest : BaseValidatorTest
    {
        private readonly DeviceValidator validator =
            new DeviceValidator();

        [Fact]
        public void DeviceModel_WithValidData_HappyPath()
        {
            // Given
            var device = CreateDeviceData();

            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
