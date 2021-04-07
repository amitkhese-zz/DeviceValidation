using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class TasksDefinitionValidatorTest : BaseValidatorTest
    {
        private readonly TasksDefinitionValidator validator =
            new TasksDefinitionValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateTaskDefinition();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidDeviceTask()
        {
            var model = CreateTaskDefinition();
            var invalidDeviceTask = new DeviceTask()
            {
                Days = new Dictionary<string, bool>()
                    {
                        { "-1", true },
                        { "0", true },
                        { "8", true }
                    },
                Date = "2021-02-13",
                Time = "13:15:00",
                Duration = 1700
            };

            model.Task.Add(invalidDeviceTask);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Task[1].Days");
        }
    }
}
