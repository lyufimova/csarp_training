using NUnit.Framework;
using System.Collections.Generic;

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
                int numberOfGroup = 0;
                if (app.Groups.IsGroupPresent(numberOfGroup) == false)
                {
                    GroupData group = new GroupData("GroupTest");
                    app.Groups.Create(group);
                }


                GroupData newData = new GroupData("123");
                newData.Header = null;
                newData.Footer = null;

                List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Modify(numberOfGroup, newData);

                Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups[numberOfGroup].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    if (group.Id == oldGroups[numberOfGroup].Id)
                    {
                        Assert.AreEqual(newData.Name, group.Name);
                    }
                }
            }
        }
    }
}

