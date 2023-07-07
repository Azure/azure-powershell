using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightUserAssignedIdentity
    {
        public AzureHDInsightUserAssignedIdentity() { }

        public AzureHDInsightUserAssignedIdentity(string principalId = null, string clientId = null, string tenantId = null)
        {
            PrincipalId = principalId;
            ClientId = clientId;
        }

        public AzureHDInsightUserAssignedIdentity(UserAssignedIdentity userAssignedIdentity)
        {
            PrincipalId = userAssignedIdentity?.PrincipalId.ToString();
            ClientId = userAssignedIdentity?.ClientId.ToString();
        }

        public string PrincipalId { get; }

        public string ClientId { get; }

        public string TenantId { get; set; }
    }
}
