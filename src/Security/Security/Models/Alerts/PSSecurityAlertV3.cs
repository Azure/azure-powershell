using Microsoft.Azure.Commands.Security.Models.Alerts;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.Alerts
{
    public class PSSecurityAlertV3
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AlertDisplayName { get; set; }

        public string CompromisedEntity { get; set; }

        public string Description { get; set; }

        public List<PSSecurityAlertEntity> Entities { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; set; }

        public List<string> RemediationSteps { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public string VendorName { get; set; }

        public string CorrelationKey { get; set; }

        public bool? IsIncident { get; set; }

        public string ProductName { get; set; }

        public DateTime? TimeGeneratedUtc { get; set; }

        public string AlertUri { get; set; }

        public List<IDictionary<string, string>> ExtendedLinks { get; set; }

        public List<ResourceIdentifier> ResourceIdentifiers { get; set; }

        public string Intent { get; set; }

        public string ProductComponentName { get; set; }

        public string SystemAlertId { get; set; }

        public string AlertType { get; set; }

        public DateTime? ProcessingEndTimeUtc { get; set; }

        public DateTime? EndTimeUtc { get; set; }

        public DateTime? StartTimeUtc { get; set; }
    }
}
