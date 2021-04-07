using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class ActivityLogValidator : AbstractValidator<ActivityLog>
    {
        public ActivityLogValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Results).SetValidator(new ResultValidator());
        }
    }
}
