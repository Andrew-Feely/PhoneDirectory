using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPhoneApp
{
    public class DirectoryItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string phoneNumber;
        public string Dept { get; set; }
        public bool Active { get; set; }

        public DirectoryItem() { }

        public DirectoryItem(string fName, string lname, string phone, string dept)
        {
            FirstName = fName;
            LastName = lname;
            PhoneNumber = phone;
            Dept = dept;
            Active = true;
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
               if(value.Length < 10)
                {
                    //throw new FieldAccessException("Phone number must have 10 digits");
                    //throw new PhoneNumberException();
                    throw new PhoneNumberException("10 digits you must!");
                }
               else
                {
                    phoneNumber = value;
                }
            }
        }
        public override string ToString()
        {
            return string.Format("ID:{0} \t{1}, {2}  {3}  Department: {4}  Active: {5}",Id, FirstName,LastName, PhoneNumber, Dept, Active);
        }
    }
}
