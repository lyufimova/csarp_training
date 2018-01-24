using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }


        public string Title { get; set; }
        public string Company { get; set; }
        public string Fax { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string SecondHomePhone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string HomePage { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone) + CleanUpPhone(SecondHomePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }


        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string firstName;

                    if (FirstName == null || FirstName == "")
                        firstName = "";
                    else firstName = FirstName + " ";

                    string middleName;

                    if (MiddleName == null || MiddleName == "")
                        middleName = "";
                    else middleName = MiddleName + " ";

                    string homePhone;

                    if (HomePhone == null || HomePhone == "")
                        homePhone = "";
                    else homePhone = "H: " + CleanUp(HomePhone);

                    string mobilePhone;

                    if (MobilePhone == null || MobilePhone == "")
                        mobilePhone = "";
                    else mobilePhone = "M: " + CleanUp(MobilePhone);

                    string workPhone;

                    if (WorkPhone == null || WorkPhone == "")
                        workPhone = "";
                    else workPhone = "W: " + CleanUp(WorkPhone);

                    string fax;

                    if (Fax == null || Fax == "")
                        fax = "";
                    else fax = "F: " + CleanUp(Fax);

                    string secondHomePhone;

                    if (SecondHomePhone == null || SecondHomePhone == "")
                        secondHomePhone = "";
                    else secondHomePhone = "P: " + CleanUp(SecondHomePhone);

                    string homePage;

                    if (HomePage == null || HomePage == "")
                        homePage = "";
                    else homePage = "Homepage:\r\n" + CleanUp(HomePage);


                    return (
                       CleanUp(firstName + middleName + LastName) +
                       CleanUp(NickName) +
                       CleanUp(Title) +
                       CleanUp(Company) +
                       CleanUp(Address) + "\r\n" +
                       CleanUp(homePhone + mobilePhone + workPhone + fax) +
                       AllEmails + "\r\n" +
                       homePage + "\r\n\r\n\r\n" +
                       secondHomePhone


                        ).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            //return phone.Replace(" ","").Replace("-","").Replace("(","").Replace(")", "")+ "\r\n";
        }



        private string CleanUp(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            return value + "\r\n";
            //return phone.Replace(" ","").Replace("-","").Replace("(","").Replace(")", "")+ "\r\n";
        }


        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            return (FirstName.GetHashCode()) + (LastName.GetHashCode());
        }

        public override string ToString()
        {
            return "firstName=" + FirstName + " lastName=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) != 0)
            {
                return LastName.CompareTo(other.LastName);
            }

            return FirstName.CompareTo(other.FirstName);
        }



    }

}
