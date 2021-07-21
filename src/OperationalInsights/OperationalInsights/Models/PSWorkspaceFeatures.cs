using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspaceFeatures
    {
        public PSWorkspaceFeatures(WorkspaceFeatures featues)
        {
            AdditionalProperties = featues.AdditionalProperties;
            ClusterResourceId = featues.ClusterResourceId;
            DisableLocalAuth = featues.DisableLocalAuth;
            EnableDataExport = featues.EnableDataExport;
            EnableLogAccessUsingOnlyResourcePermissions = featues.EnableLogAccessUsingOnlyResourcePermissions;
            ImmediatePurgeDataOn30Days = featues.ImmediatePurgeDataOn30Days;
        }
        public IDictionary<string, object> AdditionalProperties { get; set; }
        public string ClusterResourceId { get; set; }
        public bool? DisableLocalAuth { get; set; }
        public bool? EnableDataExport  { get; set; }
        public bool? EnableLogAccessUsingOnlyResourcePermissions  { get; set; }
        public bool? ImmediatePurgeDataOn30Days { get; set; }
    }
}
