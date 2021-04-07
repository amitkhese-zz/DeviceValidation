using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class SoundSettingsValidatorTest : BaseValidatorTest
    {
        private readonly SoundSettingsValidator validator =
            new SoundSettingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateSoundSettings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(120, 3)]
        [InlineData(-1, -1)]
        public void InvalidSoundSettings(long invalidVolume, long invalidRingMode)
        {
            var model = CreateSoundSettings();

            model.Volume = invalidVolume;
            model.RingMode = invalidRingMode;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Volume");
            result.ShouldHaveValidationErrorFor("RingMode");
        }
    }
}
