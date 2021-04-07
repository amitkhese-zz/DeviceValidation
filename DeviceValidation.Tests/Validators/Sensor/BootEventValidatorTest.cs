using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class BootEventValidatorTest : BaseValidatorTest
    {
        private readonly BootEventValidator validator =
            new BootEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateBootEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
