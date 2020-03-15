using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public class PSThresholdCustomAlertRule : PSCustomAlertRule
    {
        public int MinThreshold { get; set; }

        public int MaxThreshold { get; set; }
    }
}
