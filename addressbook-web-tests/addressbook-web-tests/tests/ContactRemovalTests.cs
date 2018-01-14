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
            //Добавлен переход на страницу, так как страница не успевает открыться
            app.Navigator.GoToHomepage();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(numberOfElement);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}