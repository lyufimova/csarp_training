using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomepage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GoToAddNewPage();
            ContactData contact = new ContactData("Anna", "Ivanova");
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactForm();
            app.Navigator.GoToHomepage();
            app.Auth.Logout();
        }
    }
}
