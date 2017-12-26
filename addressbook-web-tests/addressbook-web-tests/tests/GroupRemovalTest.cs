using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupRemovalTests : AuthTestBase
    {

        [Test]

        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            int numberOfGroup = 1;
            if (app.Groups.IsGroupPresent(numberOfGroup) == false)
            {
                GroupData group = new GroupData("GroupTest");
                app.Groups.Create(group);
            }

            app.Groups.Remove(numberOfGroup);
        }

    }
}
