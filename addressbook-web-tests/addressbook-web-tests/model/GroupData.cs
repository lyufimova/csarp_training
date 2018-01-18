using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
     

        public GroupData(string name)
        {
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
            // то же самое, что и return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name +"\nheader= " + Header + "\nfooter= " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }


        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
        /*
         public string Name
          {
             get
             {
                 return name;
             }
             set
             {
                 name = value;
             }
         }

         public string Header
         {
             get
             {
                 return header;
             }
             set
             {
                 header = value;
             }
         }

         public string Footer
         {
             get
             {
                 return footer;
             }
             set
             {
                 footer = value;
             }
         }

     */


    }
}
