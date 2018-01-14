using System;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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
            return (FirstName == other.firstName)&&(LastName == other.lastName);
        }

        public override int GetHashCode()
        {
            return (FirstName.GetHashCode())+(LastName.GetHashCode());
        }

        public override string ToString()
        {
            return "firstName=" + firstName + " lastName=" + lastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (lastName.CompareTo(other.lastName) != 0)
            {
                return lastName.CompareTo(other.lastName);
            }

            return firstName.CompareTo(other.firstName);
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
    }
  
}
