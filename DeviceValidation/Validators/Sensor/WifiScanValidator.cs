using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class WifiScanValidator : AbstractValidator<WiFiScan>
    {
        public WifiScanValidator()
        {
            RuleFor(x => x.Bssid).Matches(StringValidatorRules.BSSIDRegex);
            RuleFor(x => x.Channel).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SignalStrength);
        }
    }
}
