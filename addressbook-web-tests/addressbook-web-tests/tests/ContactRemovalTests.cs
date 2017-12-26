using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase
    {

        [Test]

        public void ContactRemovalTest()
        {
            int numberOfElement = 1;
            if (app.Contacts.IsContactPresent(numberOfElement) == false)
            {
                ContactData contact = new ContactData("Contact", "Remove");
                app.Contacts.Create(contact);
            }

            app.Contacts.Remove(numberOfElement);
        }

    }
}