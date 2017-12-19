using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomepage();
            Login(new AccountData("admin", "secret")); 
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            FillGruopForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage(); 
        } 
    }
}
