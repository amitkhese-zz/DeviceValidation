using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class PresetMessagesValidator : AbstractValidator<PresetMessages>
    {
        public PresetMessagesValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.PresetMsgs).SetValidator(new PresetMsgDataValidator());
        }
    }
}
