using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            int numberOfContact = 0;
            ContactData fromTable = app.Contacts.GetContactInformstionFromTable(numberOfContact);
            ContactData fromForm = app.Contacts.GetContactInformstionFromEditForm(numberOfContact);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
    }

}
