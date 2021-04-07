using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class CellReadingsValidator : AbstractValidator<CellTowerReadings>
    {
        public CellReadingsValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.Network).ValidateCellNetworkTypes();
            RuleForEach(x => x.Scan).SetValidator(new CellTowerScanValidator());
        }
    }
}
