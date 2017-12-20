using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager menager) : base(menager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroup(v);
            RemovalGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SelectGroup(int v)
        {
            string xpath = "(//input[@name='selected[]'])[" + v + "]";
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public GroupHelper RemovalGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    }
}
