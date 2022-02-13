using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightUserAssignedIdentity
    {
        public AzureHDInsightUserAssignedIdentity() { }

        public AzureHDInsightUserAssignedIdentity(string principalId = null, string clientId = null, string tenantId = null)
        {
            PrincipalId = principalId;
            ClientId = clientId;
            TenantId = tenantId;
        }

        public AzureHDInsightUserAssignedIdentity(UserAssignedIdentity userAssignedIdentity)
        {
            PrincipalId = userAssignedIdentity?.PrincipalId;
            ClientId = userAssignedIdentity?.ClientId;
            TenantId = userAssignedIdentity?.TenantId;
        }

        public string PrincipalId { get; }

        public string ClientId { get; }

        public string TenantId { get; set; }
    }
}
