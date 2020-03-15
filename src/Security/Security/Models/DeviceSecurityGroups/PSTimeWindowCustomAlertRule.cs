using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSTimeWindowCustomAlertRule : PSThresholdCustomAlertRule
    {
        public TimeSpan TimeWindowSize { get; set; }
    }
}
