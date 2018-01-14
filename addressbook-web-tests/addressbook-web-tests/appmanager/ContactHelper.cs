﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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
            string xpath = "(//img[@title='Edit'])[" + (v + 1) + "]";
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper RemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v + 1) + "]")).Click();
            return this;
        }

        public bool IsContactPresent(int v)
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][" + (v + 1) + "]"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomepage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IWebElement lastName = element.FindElement(By.XPath("td[2]"));
                    IWebElement firstName = element.FindElement(By.XPath("td[3]"));
                    contactCache.Add(new ContactData(firstName.Text, lastName.Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }
    }
}


 
       
            
            
              
               
               
    