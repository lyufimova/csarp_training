using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager menager) 
            : base(menager)
        {
            this.baseURL = manager.BaseURL;
        }
        public void GoToHomepage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToGroupPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
    }
}
