using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSTopDevice
    {
        public string DeviceId { get; set; }

        public long? AlertsCount { get; set; }

        public string LastOccurrence { get; set; }
    }
}
