using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LightEventValidatorTest : BaseValidatorTest
    {
        private readonly LightEventValidator validator =
            new LightEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateLightEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
