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

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);
            }
        }
    }
}

