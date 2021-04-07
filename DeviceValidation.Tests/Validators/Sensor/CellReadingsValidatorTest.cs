using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class CellReadingsValidatorTest : BaseValidatorTest
    {
        private readonly CellReadingsValidator validator =
            new CellReadingsValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateCellReadings();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidCellTowerScan()
        {
            var model = CreateCellReadings();
            var invalidCellTowerScanModel = new CellTowerScan()
            {
                MobileCountryCode = "1234", // Length must be less than 3
                MobileNetworkCode = "Not parsable string to int"
            };
            model.Scan.Add(invalidCellTowerScanModel);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Scan[1].MobileCountryCode")
                .WithErrorMessage("'Mobile Country Code' must be 3 characters in length. You entered 4 characters.");
            result.ShouldHaveValidationErrorFor("Scan[1].MobileNetworkCode")
                .WithErrorMessage("[Mobile Network Code] of [Not parsable string to int] must be number string.");
        }

        [Fact]
        public void InvalidNetworkType()
        {
            var model = CreateCellReadings();
            model.Network = "Invalid Network Type";

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Network")
                .WithErrorMessage("[Network] of [Invalid Network Type] must be within allowed range of [GSM, GPRS, CDMA, MOBITEX, EDGE]");
        }
    }
}
