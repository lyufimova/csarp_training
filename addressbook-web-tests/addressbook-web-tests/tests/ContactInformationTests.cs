using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationTableForm()
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

        [Test]
        public void TestContactInformationFormDetail()
        {
            int numberOfContact = 0;
            ContactData fromDetail = app.Contacts.GetContactInformstionFromDetail(numberOfContact);
            ContactData fromForm = app.Contacts.GetContactInformstionFromEditForm(numberOfContact);

            Assert.AreEqual(fromDetail.AllDetails, fromForm.AllDetails);

        }


    }

}
