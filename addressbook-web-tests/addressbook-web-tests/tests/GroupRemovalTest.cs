using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupRemovalTests : AuthTestBase
    {

        [Test]

        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            int numberOfGroup = 0;
            if (!app.Groups.IsGroupPresent(numberOfGroup))
            {
                GroupData group = new GroupData("GroupTest");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(numberOfGroup);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(numberOfGroup);
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
