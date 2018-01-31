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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[numberOfElement];

            app.Contacts.Remove(toBeRemoved);
            app.Navigator.GoToHomepage();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Remove(toBeRemoved);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}


