using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class FirmwareInformationValidatorTest : BaseValidatorTest
    {
        private readonly FirmwareInformationValidator validator =
            new FirmwareInformationValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateFirmwareInformation();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        //[Theory]
        //[InlineData("1.0.a")]
        //[InlineData("1.0.1(234)")]
        //[InlineData("1.0.2 (abs)")]
        //public void InvalidFirmwareData(string invalidVersion)
        //{
        //    var model = CreateFirmwareInformation();

        //    model.FirmwareVersion = invalidVersion; // InvalidSemanticVersion
        //    model.FirmwareTarget = invalidVersion; // InvalidSemanticVersion
        //    model.FirmwareAppliesTo = invalidVersion; // InvalidSemanticVersion
        //    model.FirmwareUrl = "firmware-version";

        //    var result = validator.TestValidate(model);

        //    result.ShouldHaveValidationErrorFor("FirmwareVersion");
        //    result.ShouldHaveValidationErrorFor("FirmwareTarget");
        //    result.ShouldHaveValidationErrorFor("FirmwareAppliesTo");
        //    result.ShouldHaveValidationErrorFor("FirmwareUrl");
        //}
    }
}
