using Azure.Core;
using Azure.ResourceManager.Models;
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

        public AzureHDInsightClusterIdentity(ManagedServiceIdentity clusterIdentity)
        {
            PrincipalId = clusterIdentity?.PrincipalId.ToString();
            TenantId = clusterIdentity?.TenantId.ToString();
            Type = clusterIdentity.ManagedServiceIdentityType.ToString();
            UserAssignedIdentities =clusterIdentity?.UserAssignedIdentities != null ? new Dictionary<string, AzureHDInsightUserAssignedIdentity>() : null;
            if (UserAssignedIdentities != null)
            {
                foreach( var entry in clusterIdentity.UserAssignedIdentities)
                {
                    UserAssignedIdentities.Add(entry.Key.ToString(), new AzureHDInsightUserAssignedIdentity(entry.Value));
                }
            }
        }


        public string PrincipalId { get; }

        public string TenantId { get; }

        public string Type { get; set; }
        public IDictionary<string, AzureHDInsightUserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}
