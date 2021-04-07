using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class WifiReadingsValidatorTest : BaseValidatorTest
    {
        private readonly WifiReadingsValidator validator =
            new WifiReadingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateWiFiReadings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("FF:FF:FF:FF:FF:GH", -1)]
        [InlineData("SomeRandomString", -100)]
        public void InvalidWiFiScan(string invalidBssid, long invalidChannel)
        {
            var model = CreateWiFiReadings();
            var invalidWifiScan = new WiFiScan()
            {
                Bssid = invalidBssid,
                Channel = invalidChannel
            };

            model.Scan.Add(invalidWifiScan);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Scan[1].Bssid");
            result.ShouldHaveValidationErrorFor("Scan[1].Channel");
        }
    }
}
