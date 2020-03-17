using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityDeviceAlert
    {
        public string AlertDisplayName { get; set; }

        public string ReportedSeverity { get; set; }

        public int? AlertsCount { get; set; }
    }
}
