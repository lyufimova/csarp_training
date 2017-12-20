﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
           
            ContactData contact = new ContactData("Anna", "Ivanova");
            app.Contacts.Create(contact);
               
            app.Navigator.GoToHomepage();
            app.Auth.Logout();
        }
    }
}
