using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
            OpenHomepage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            ContactData contact = new ContactData("Anna", "Ivanova");
            FillContactForm(contact);
            SubmitContactForm();
            GoToHomepage();
            Logout();
        }
    }
}
