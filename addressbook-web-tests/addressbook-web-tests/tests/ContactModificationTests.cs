using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            int numberOfElement = 0;
            if (app.Contacts.IsContactPresent(numberOfElement) == false)
            {
                ContactData contact = new ContactData("Contact", "Modify");
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newData = new ContactData("Ira", "Petrova");
            app.Contacts.Modify(numberOfElement, newData);
            //Добавлен переход на страницу, так как страница не успевает открыться
            app.Navigator.GoToHomepage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}