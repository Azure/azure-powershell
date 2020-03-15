using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIotSecuritySolutionAnalytics
    {
        public PSIoTSeverityMetrics Metrics {get; set;}

        public int? UnhealthyDeviceCount { get; set; }

        public IList<PSDevicesMetrics> DevicesMetrics { get; set; }

        public IList<PSIoTSecurityAlertedDevice> TopAlertedDevices { get; set; }

        public IList<PSIoTSecurityDeviceAlert> MostPrevalentDeviceAlerts { get; set; }

        public IList<PSIoTSecurityDeviceRecommendation> MostPrevalentDeviceRecommendations { get; set; }

    }
}
