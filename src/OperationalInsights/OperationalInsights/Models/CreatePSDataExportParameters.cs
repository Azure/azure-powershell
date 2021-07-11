using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class CreatePSDataExportParameters : OperationalInsightsParametersBase
    {
        public string DataExportName { get; set; }
        public string[] TableNames { get; set; } 
        public string DestinationResourceId { get; set; }
        public string EventHubName { get; set; } 
        public bool? Enable { get; set; } 
    }
}
