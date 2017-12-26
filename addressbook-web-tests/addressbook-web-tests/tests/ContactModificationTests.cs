using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            int numberOfElement = 1;
            if (app.Contacts.IsContactPresent(numberOfElement) == false)
            {
                ContactData contact = new ContactData("Contact", "Modify");
                app.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("Ira", "Petrova");
            app.Contacts.Modify(numberOfElement, newData);
        }
    }
}