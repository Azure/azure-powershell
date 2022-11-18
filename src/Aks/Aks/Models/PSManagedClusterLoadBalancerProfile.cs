// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Profile of the managed cluster load balancer
    /// </summary>
    public partial class PSManagedClusterLoadBalancerProfile
    {
        /// <summary>
        /// Gets or sets desired managed outbound IPs for the cluster load
        /// balancer.
        /// </summary>
        public PSManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIPs { get; set; }

        /// <summary>
        /// Gets or sets desired outbound IP Prefix resources for the cluster
        /// load balancer.
        /// </summary>
        public PSManagedClusterLoadBalancerProfileOutboundIPPrefixes OutboundIPPrefixes { get; set; }

        /// <summary>
        /// Gets or sets desired outbound IP resources for the cluster load
        /// balancer.
        /// </summary>
        public PSManagedClusterLoadBalancerProfileOutboundIPs OutboundIPs { get; set; }

        /// <summary>
        /// Gets or sets the effective outbound IP resources of the cluster
        /// load balancer.
        /// </summary>
        public IList<PSResourceReference> EffectiveOutboundIPs { get; set; }
		
		/// <summary>
        /// Gets or sets the desired number of allocated SNAT ports per VM.
        /// Allowed values are in the range of 0 to 64000 (inclusive). The
        /// default value is 0 which results in Azure dynamically allocating
        /// ports.
        /// </summary>
        public int? AllocatedOutboundPorts { get; set; }

        /// <summary>
        /// Gets or sets desired outbound flow idle timeout in minutes. Allowed
        /// values are in the range of 4 to 120 (inclusive). The default value
        /// is 30 minutes.
        /// </summary>
        public int? IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// Gets or sets enable multiple standard load balancers per AKS
        /// cluster or not.
        /// </summary>
        public bool? EnableMultipleStandardLoadBalancers { get; set; }
    }
}
