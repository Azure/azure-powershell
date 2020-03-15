using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSDeviceSecurityGroup : PSResource
    {
        public IList<PSThresholdCustomAlertRule> ThresholdRules { get; set; }

        public IList<PSTimeWindowCustomAlertRule> TimeWindowRules { get; set; }

        public IList<PSAllowlistCustomAlertRule> AllowlistRules { get; set; }

        public IList<PSDenylistCustomAlertRule> DenylistRules { get; set; }
    }
}
