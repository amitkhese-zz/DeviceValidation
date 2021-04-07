using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class PresetMsgDataValidator : AbstractValidator<PresetMsgData>
    {
        public PresetMsgDataValidator()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Text);
        }
    }
}
