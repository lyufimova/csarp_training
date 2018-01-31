using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)

                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupModificationTest(GroupData newData)
        {
            {
                app.Navigator.GoToGroupPage();
                int numberOfGroup = 0;
                if (app.Groups.IsGroupPresent(numberOfGroup) == false)
                {
                    GroupData group = new GroupData("GroupTest");
                    app.Groups.Create(group);
                }

                List<GroupData> oldGroups = GroupData.GetAll();
                GroupData toBeModify = oldGroups[numberOfGroup];

                app.Groups.Modify(toBeModify, newData);

                Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

                List<GroupData> newGroups = GroupData.GetAll();
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

