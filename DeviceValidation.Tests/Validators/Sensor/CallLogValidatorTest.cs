using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class CallLogValidatorTest : BaseValidatorTest
    {
        private readonly CallLogValidator validator =
            new CallLogValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateCallLog();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(-1, "11232345678900001")]
        [InlineData(7, "a2345678901")]
        public void InvalidCallLogItem(long invalidType, string invalidMsisdn)
        {
            var model = CreateCallLog();
            var invalidLogItem = new CallLogItem()
            {
                Type = invalidType,
                Msisdn = invalidMsisdn // invalid MSISDN with extra digit
            };
            model.Log.Add(invalidLogItem);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Log[1].Type")
                .WithErrorMessage("[Type] of [" + invalidType + "] must be within allowed range of [0, 1, 2, 3, 4, 5, 6]");
            result.ShouldHaveValidationErrorFor("Log[1].Msisdn")
                .WithErrorMessage("[Msisdn] of [" + invalidMsisdn + "] must be valid Phone Number");
        }
    }
}
