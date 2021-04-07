using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class HardwareEnabledValidatorTest : BaseValidatorTest
    {
        private readonly HardwareEnabledValidator validator =
            new HardwareEnabledValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateHardwareEnabled();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("-90")]
        [InlineData("361")]
        [InlineData("271")]
        [InlineData("91")]
        public void InvalidCameraOrientation(string invalidCamOrientation)
        {
            var model = CreateHardwareEnabled();
            model.CameraOrientation = invalidCamOrientation;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("CameraOrientation");
        }
    }
}
