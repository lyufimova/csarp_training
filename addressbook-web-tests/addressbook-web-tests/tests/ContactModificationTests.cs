using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ira", "Petrova");

            app.Contacts.Modify(1, newData);
        }
    }
}