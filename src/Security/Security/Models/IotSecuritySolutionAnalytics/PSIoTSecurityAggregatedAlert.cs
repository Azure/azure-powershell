using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityAggregatedAlert
    {
        public string AlertType { get; set; }

        public string AlertDisplayName { get; set; }

        public DateTime? AggregatedDateUtc { get; set; }

        public string VendorName { get; set; }

        public string ReportedSeverity { get; set; }

        public string RemediationSteps { get; set; }

        public string Description { get; set; }

        public long? Count { get; set; }

        public string EffectedResourceType { get; set; }

        public string SystemSource { get; set; }

        public string ActionTaken { get; set; }

        public string LogAnalyticsQuery { get; set; }

        public IList<PSTopDevice> TopDevicesList { get; set; }

        public IDictionary<string, string> Tags { get; set; }
        
        public string Type { get; set; }
        
        public string Name { get; set; }
       
        public string Id { get; set; }
    }
}
