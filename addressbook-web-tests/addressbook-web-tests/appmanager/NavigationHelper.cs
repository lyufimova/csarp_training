using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) 
            : base(driver)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }
        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }
    }
}
