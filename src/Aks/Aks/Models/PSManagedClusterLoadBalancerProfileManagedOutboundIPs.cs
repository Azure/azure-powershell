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

using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Desired managed outbound IPs for the cluster load balancer.
    /// </summary>
    public partial class PSManagedClusterLoadBalancerProfileManagedOutboundIPs
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ManagedClusterLoadBalancerProfileManagedOutboundIPs class.
        /// </summary>
        public PSManagedClusterLoadBalancerProfileManagedOutboundIPs()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ManagedClusterLoadBalancerProfileManagedOutboundIPs class.
        /// </summary>
        /// <param name="count">Desired number of outbound IP created/managed
        /// by Azure for the cluster load balancer. Allowed values must be in
        /// the range of 1 to 100 (inclusive). The default value is 1. </param>
        public PSManagedClusterLoadBalancerProfileManagedOutboundIPs(int? count = default(int?))
        {
            Count = count;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets desired number of outbound IP created/managed by Azure
        /// for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        public int? Count { get; set; }
    }
}
