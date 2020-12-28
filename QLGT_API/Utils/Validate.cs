using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QLGT_API.Utils
{
    public class Validate
    {
        public static int ValidateEmail(string email)
        {
            try
            {
                MailAddress e = new MailAddress(email);
                return 1;
            }
            catch (FormatException)
            {
                return 0;
            }
        }
    }
}
