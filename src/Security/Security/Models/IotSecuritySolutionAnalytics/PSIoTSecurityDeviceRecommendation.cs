using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityDeviceRecommendation
    {
        public string RecommendationDisplayName { get; set; }

        public string ReportedSeverity { get; set; }

        public int? DevicesCount { get; set; }
    }
}
