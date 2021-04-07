using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class CellTowerScanValidator : AbstractValidator<CellTowerScan>
    {
        public CellTowerScanValidator()
        {
            RuleFor(x => x.CellTowerId);
            RuleFor(x => x.LocationAreaCode);
            RuleFor(x => x.SignalStrength);
            RuleFor(x => x.MobileCountryCode).Length(3).ValidateStringParseToInt();
            RuleFor(x => x.MobileNetworkCode).ValidateStringParseToInt();
        }
    }
}
