using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{ 
    [DataContract]
    sealed class ClusterResolutionResult
    {
        [DataMember(Name = "clusterFQDN")]
        public string ClusterFQDN { get; set; }

        [DataMember(Name = "coreServerName")]
        public string CoreServerName { get; set; }

        [DataMember(Name = "tenantId")]
        public string TenantId { get; set; }
    }
}
