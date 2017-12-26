using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            {
                app.Navigator.GoToGroupPage();
                int numberOfGroup = 1;
                if (app.Groups.IsGroupPresent(numberOfGroup) == false)
                {
                    GroupData group = new GroupData("GroupTest");
                    app.Groups.Create(group);
                }


                GroupData newData = new GroupData("123");
                newData.Header = null;
                newData.Footer = null;

                app.Groups.Modify(numberOfGroup, newData);
            }
        }
    }
}

