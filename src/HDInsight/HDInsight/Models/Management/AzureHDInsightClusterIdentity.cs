using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightClusterIdentity
    {
        //
        // Summary:
        //     Initializes a new instance of the ClusterIdentity class.
        public AzureHDInsightClusterIdentity() { }

        public AzureHDInsightClusterIdentity(string principalId = null, string tenantId = null, string type = null, IDictionary<string, AzureHDInsightUserAssignedIdentity> userAssignedIdentities = null)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            Type = type;
            UserAssignedIdentities = userAssignedIdentities;
        }

        public AzureHDInsightClusterIdentity(ClusterIdentity clusterIdentity)
        {
            PrincipalId = clusterIdentity?.PrincipalId;
            TenantId = clusterIdentity?.TenantId;
            Type = clusterIdentity?.Type;
            UserAssignedIdentities =clusterIdentity?.UserAssignedIdentities != null ? new Dictionary<string, AzureHDInsightUserAssignedIdentity>() : null;
            if (UserAssignedIdentities != null)
            {
                foreach( var entry in clusterIdentity.UserAssignedIdentities)
                {
                    UserAssignedIdentities.Add(entry.Key, new AzureHDInsightUserAssignedIdentity(entry.Value));
                }
            }
        }


        public string PrincipalId { get; }

        public string TenantId { get; }

        public string Type { get; set; }
        public IDictionary<string, AzureHDInsightUserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}
