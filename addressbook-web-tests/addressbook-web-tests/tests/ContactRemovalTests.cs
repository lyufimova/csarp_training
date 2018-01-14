using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase
    {

        [Test]

        public void ContactRemovalTest()
        {
            int numberOfElement = 0;
            if (app.Contacts.IsContactPresent(numberOfElement) == false)
            {
                ContactData contact = new ContactData("Contact", "Remove");
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(numberOfElement);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(numberOfElement);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}