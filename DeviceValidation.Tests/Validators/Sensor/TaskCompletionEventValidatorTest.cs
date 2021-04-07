using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class TaskCompletionEventValidatorTest : BaseValidatorTest
    {
        private readonly TaskCompletionEventValidator validator =
            new TaskCompletionEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateTaskCompletionEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
