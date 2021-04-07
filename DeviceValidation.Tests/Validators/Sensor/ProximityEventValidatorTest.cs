using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class ProximityEventValidatorTest : BaseValidatorTest
    {
        private readonly ProximityEventValidator validator =
            new ProximityEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateProximityEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
