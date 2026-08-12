using System;
using System.Collections.Generic;
using System.Text;

namespace Cpdhelpdesk.Shared
{
    public class HelpDeskEmail
    {
        public long id { get; set; }
        public string EmailType { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddresscc { get; set; }

        public string EmailAddresasinto { get; set; }
        public string TicketGuid { get; set; }
    }
}
