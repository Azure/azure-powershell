using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSCustomAlertRule
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public string RuleType { get; set; }
    }
}
