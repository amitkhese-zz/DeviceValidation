using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class ContactDefinitionValidatorTest : BaseValidatorTest
    {
        private readonly ContactDefinitionValidator validator =
            new ContactDefinitionValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateContactDefinition();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("someInvalidURL", "SomeRandomStringInsteadOfMsisdn")]
        [InlineData("https:/invalidurlinvalidendpoint", "a1231323123")]
        public void InvalidContactObject(string invalidIconUrl, string invalidMsisdn)
        {
            var model = CreateContactDefinition();
            var invalidContactModel = new Contact()
            {
                Type = ContactType.ADMIN,
                Msisdn = invalidMsisdn,
                IconUrl = invalidIconUrl
            };
            model.Contacts.Add(invalidContactModel);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Contacts[1].Msisdn");
            result.ShouldHaveValidationErrorFor("Contacts[1].IconUrl");
        }

        [Fact]
        public void InvalidContact_Emergency_Null()
        {
            var model = CreateContactDefinition();
            model.Contacts[0].Emergency = null;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Contacts[0].Emergency");
        }
    }
}
