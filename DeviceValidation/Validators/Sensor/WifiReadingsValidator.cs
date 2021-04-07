using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class WifiReadingsValidator : AbstractValidator<WiFiReadings>
    {
        public WifiReadingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Scan).SetValidator(new WifiScanValidator());
        }
    }
}
