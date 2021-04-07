using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class HardwareInformationValidatorTest : BaseValidatorTest
    {
        private readonly HardwareInformationValidator validator =
            new HardwareInformationValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateHardwareInformation();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("lessLength")]
        [InlineData("12345667789012312")]
        [InlineData("123asdf-asdfaw=123100")]
        public void InvalidImei(string invalidImei)
        {
            var model = CreateHardwareInformation();
            model.Imei = invalidImei;
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Imei");
        }
    }
}
