using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class ActivityLogValidatorTest : BaseValidatorTest
    {
        private readonly ActivityLogValidator validator =
            new ActivityLogValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateActivityLog();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NegativeStepsNotAllowed(int invalidCount)
        {
            var model = CreateActivityLog();
            var invalidActivity = new Results()
            {
                Count = invalidCount,
                EndTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                StartTime = DateTimeOffset.Now.AddSeconds(-12500).ToUnixTimeMilliseconds()
            };
            model.Results.Add(invalidActivity);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Results[1].Count");
        }


        [Theory]
        [InlineData(1608701330476, 1608688830476)]
        [InlineData(-1608701330476, -1608688830476)]
        public void InvalidStartEndTimeTest(long invalidStartTime, long invalidEndTime)
        {
            var model = CreateActivityLog();
            var invalidActivity = new Results()
            {
                Count = 10,
                EndTime = invalidEndTime,
                StartTime = invalidStartTime
            };

            model.Results.Add(invalidActivity);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Results[1].StartTime");
            result.ShouldHaveValidationErrorFor("Results[1].EndTime");
        }
    }
}
