using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSDenylistCustomAlertRule : PSListCustomAlertRule
    {
        public IList<string> DenylistValues { get; set; }
    }
}
