using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityAlertedDevice
    {
        public string DeviceId { get; set; }

        public int? AlertsCount { get; set; }
    }
}
