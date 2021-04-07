using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class PresetMessagesValidatorTest : BaseValidatorTest
    {
        private readonly PresetMessagesValidator validator =
            new PresetMessagesValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreatePresentMessages();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
