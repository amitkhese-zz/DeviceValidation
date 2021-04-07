using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class AlarmValidation : AbstractValidator<Alarm>
    {
        public AlarmValidation()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.School);
            RuleFor(x => x.Snooze);
            RuleFor(x => x.Title);
            RuleFor(x => x.Days).ValidateRepeatedDays();
        }
    }
}
