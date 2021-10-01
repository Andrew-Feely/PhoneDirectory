using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPhoneApp
{
    public class PhoneNumberException : Exception
    {
        public PhoneNumberException() : base("Phone number must be 10 digits.") { }

        public PhoneNumberException(string message) : base(message) { }
    }
}
