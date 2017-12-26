using System;
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
            manager.Navigator.GoToHomepage();
            GoToAddNewPage();
            FillContactForm(contact);
            SubmitContactForm();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHomepage();
            EditContact(v);
            FillContactForm(newData);
            UpdateContactForm();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomepage();
            SelectContact(v);
            RemovalContact();
            ConfirmRemoval();
            return this;
        }

        public ContactHelper UpdateContactForm()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper EditContact(int v)
        {
            string xpath = "(//img[@title='Edit'])[" + v + "]";
            driver.FindElement(By.XPath(xpath)).Click();
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

        public ContactHelper ConfirmRemoval()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            string xpath = "(//input[@name='selected[]'])[" + v + "]";
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public bool IsContactPresent(int v)
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][" + v + "]"));
        }

    }
}
