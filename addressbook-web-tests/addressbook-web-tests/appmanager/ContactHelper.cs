using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager menager)
            : base(menager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToGroupPage();

            GoToAddNewPage();
            FillContactForm(contact);
            SubmitContactForm();
            return this;
        }
        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }
        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
