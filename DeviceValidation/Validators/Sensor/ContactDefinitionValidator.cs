using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class ContactDefinitionValidator : AbstractValidator<ContactDefinition>
    {
        public ContactDefinitionValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Contacts).SetValidator(new ContactValidator());
        }
    }
}
