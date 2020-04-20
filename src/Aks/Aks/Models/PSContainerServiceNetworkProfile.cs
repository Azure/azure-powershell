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

namespace Microsoft.Azure.Commands.Aks.Models
{
    public class PSContainerServiceNetworkProfile
    {
        /// <summary>
        /// Gets or sets network plugin used for building Kubernetes network.
        /// Possible values include: 'azure', 'kubenet'
        /// </summary>
        public string NetworkPlugin { get; set; }

        /// <summary>
        /// Gets or sets network policy used for building Kubernetes network.
        /// Possible values include: 'calico', 'azure'
        /// </summary>
        public string NetworkPolicy { get; set; }

        /// <summary>
        /// Gets or sets a CIDR notation IP range from which to assign pod IPs
        /// when kubenet is used.
        /// </summary>
        public string PodCidr { get; set; }

        /// <summary>
        /// Gets or sets a CIDR notation IP range from which to assign service
        /// cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        public string ServiceCidr { get; set; }

        /// <summary>
        /// Gets or sets an IP address assigned to the Kubernetes DNS service.
        /// It must be within the Kubernetes service address range specified in
        /// serviceCidr.
        /// </summary>
        public string DnsServiceIP { get; set; }

        /// <summary>
        /// Gets or sets a CIDR notation IP range assigned to the Docker bridge
        /// network. It must not overlap with any Subnet IP ranges or the
        /// Kubernetes service address range.
        /// </summary>
        public string DockerBridgeCidr { get; set; }

        /// <summary>
        /// Gets or sets the load balancer sku for the managed cluster.
        /// Possible values include: 'standard', 'basic'
        /// </summary>
        public string LoadBalancerSku { get; set; }

        /// <summary>
        /// Gets or sets profile of the cluster load balancer.
        /// </summary>
        public PSManagedClusterLoadBalancerProfile LoadBalancerProfile { get; set; }

    }
}
