using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroup()
        {

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count == 0)
            {
                ContactData newContact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(newContact, group);
                oldList = group.GetContacts();
                //oldList.Add(newContact);
            }
            ContactData contact = oldList[0];

            //action
            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }


    }
}
