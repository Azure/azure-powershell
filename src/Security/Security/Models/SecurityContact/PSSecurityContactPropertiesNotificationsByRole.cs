using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.SecurityContact
{
    public class PSSecurityContactPropertiesNotificationsByRole
    {
        public string State { get; set; }
        public IList<string> Roles { get; set; }
    }
}
