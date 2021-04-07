using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class SmsLogValidatorTest : BaseValidatorTest
    {
        private readonly SmsLogValidator validator =
            new SmsLogValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateSmsLog();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidSmsLogItem()
        {
            var model = CreateSmsLog();
            var invalidSmsLogItem = new SmsLogItem()
            {
                Direction = 3, // unkown, only allowed [0: incoming, 1: outgoing]
                Type = 4, // unkown, allowed [0: MMS with attachment, 1: MMS Group message, 2: Regular message]
                From = "unparsableNumber",
                To = new List<string>()
                {
                    "1231231312aa"
                }
            };
            model.Log.Add(invalidSmsLogItem);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Log[1].Direction");
            result.ShouldHaveValidationErrorFor("Log[1].Type");
            result.ShouldHaveValidationErrorFor("Log[1].From");
            result.ShouldHaveValidationErrorFor("Log[1].To[0]");
        }
    }
}
