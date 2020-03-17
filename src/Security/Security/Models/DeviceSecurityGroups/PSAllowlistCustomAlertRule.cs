using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSAllowlistCustomAlertRule : PSListCustomAlertRule
    {
        public IList<string> AllowlistValues { get; set; }
    }
}
