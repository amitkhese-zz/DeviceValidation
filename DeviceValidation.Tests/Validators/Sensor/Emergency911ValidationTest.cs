using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class Emergency911ValidationTest : BaseValidatorTest
    {
        private readonly Emergency911Validation validator =
            new Emergency911Validation();

        [Fact]
        public void HappyPath()
        {
            var model = CreateEmergency911();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
