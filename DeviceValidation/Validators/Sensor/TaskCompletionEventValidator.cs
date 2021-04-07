using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class TaskCompletionEventValidator : AbstractValidator<TaskCompletionEvent>
    {
        public TaskCompletionEventValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.TaskCompletionStatus).IsInEnum();
            RuleFor(x => x.TaskId);
        }
    }
}
