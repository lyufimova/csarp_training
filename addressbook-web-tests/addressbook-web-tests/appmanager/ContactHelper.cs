using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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


        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomepage();
            SelectContact(contact.Id);
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

        public ContactHelper ShowContactDetails(int v)
        {
            string xpath = "(//img[@title='Details'])[" + (v + 1) + "]";
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

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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

        public ContactData GetContactInformstionFromTable(int index)
        {
            manager.Navigator.GoToHomepage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;


            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformstionFromEditForm(int index)
        {
            manager.Navigator.GoToHomepage();
            EditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");


            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                NickName = nickName,
                Title = title,
                Company = company,
                Address = address,
                Fax = fax,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                SecondHomePhone = secondHomePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = homePage
              
            };
        }

        public ContactData GetContactInformstionFromDetail(int index)
        {
            manager.Navigator.GoToHomepage();
            ShowContactDetails(index);
            string content = driver.FindElement(By.Id("content")).Text;


            return new ContactData("", "")
            {
                AllDetails = content,
            };
        }


        public int GetNumberOfReserchResults()
        {
            manager.Navigator.GoToHomepage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomepage();
            CleanGroupFilteter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CleanGroupFilteter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

     

    
    }
}
