using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class AlarmsDefinitionValidationTest : BaseValidatorTest
    {
        private readonly AlarmsDefinitionValidation validator =
            new AlarmsDefinitionValidation();

        [Fact]
        public void HappyPath()
        {
            var model = CreateAlarmsDefinition();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidAlarmObject()
        {
            var model = CreateAlarmsDefinition();
            var invalidAlarm = new Alarm()
            {
                Days = new Dictionary<string, bool>() { { "8", false } },
                Date = "2021-02-13",
                Time = "13:15:00",
                Duration = 1700
            };
            model.Alarm.Add(invalidAlarm);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Alarm[1].Days");
        }
    }
}
