using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class TasksDefinitionValidator : AbstractValidator<TasksDefinition>
    {
        public TasksDefinitionValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Task).SetValidator(new DeviceTaskValidator());
        }
    }
}
