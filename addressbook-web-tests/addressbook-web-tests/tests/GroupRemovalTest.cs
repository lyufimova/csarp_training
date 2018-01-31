using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupRemovalTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[numberOfGroup];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(numberOfGroup);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }

    }
}
