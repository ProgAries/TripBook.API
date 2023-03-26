using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBook.Mailer.IL.Messages
{
    public class MailMessenger
    {
        public string Subject()
        {
            return "We are pleased to inform you that your TripBook membership has been a success.";
        }
        
        public string Content()
        {
            return "Confirm your registration to officially become a member of the traveler community. To confirm click on the link below: ";
        }
    }
}
