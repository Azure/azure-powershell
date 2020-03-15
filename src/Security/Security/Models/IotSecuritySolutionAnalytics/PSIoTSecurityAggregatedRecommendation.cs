using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityAggregatedRecommendation
    {
        public string RecommendationName { get; set; }

        public string RecommendationDisplayName { get; set; }

        public string Description { get; set; }

        public string RecommendationTypeId { get; set; }

        public string DetectedBy { get; set; }

        public string RemediationSteps { get; set; }

        public string ReportedSeverity { get; set; }

        public long? HealthyDevices { get; set; }

        public long? UnhealthyDeviceCount { get; set; }

        public string LogAnalyticsQuery { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public IDictionary<string, string> Tags { get; set; }
    }
}
