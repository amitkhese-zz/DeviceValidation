using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class SosEventValidatorTest : BaseValidatorTest
    {
        private readonly SosEventValidator validator =
            new SosEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateSosEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
