using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSDevicesMetrics
    {
        //Michal TODO string or DateTime???
        public DateTime? Date { get; set; }

        public PSIoTSeverityMetrics DevicesMetrics { get; set; }
    }
}
