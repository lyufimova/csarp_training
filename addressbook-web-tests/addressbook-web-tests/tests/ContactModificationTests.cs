using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]

        public void ContactModificationTest(ContactData newData)
        {
            int numberOfElement = 0;
            if (app.Contacts.IsContactPresent(numberOfElement) == false)
            {
                ContactData contact = new ContactData("Contact", "Modify");
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

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