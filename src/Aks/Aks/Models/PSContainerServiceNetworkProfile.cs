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

using Microsoft.Azure.Management.ContainerService.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Aks.Models
{
    public class PSContainerServiceNetworkProfile
    {
        /// <summary>
        /// Gets or sets network plugin used for building the Kubernetes
        /// network. Possible values include: 'azure', 'kubenet', 'none'
        /// </summary>
        public string NetworkPlugin { get; set; }

        /// <summary>
        /// Gets or sets network policy used for building the Kubernetes
        /// network. Possible values include: 'calico', 'azure'
        /// </summary>
        public string NetworkPolicy { get; set; }

        /// <summary>
        /// Gets or sets the network mode Azure CNI is configured with.
        /// </summary>
        /// <remarks>
        /// This cannot be specified if networkPlugin is anything other than
        /// 'azure'. Possible values include: 'transparent', 'bridge'
        /// </remarks>
        public string NetworkMode { get; set; }

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
        /// Gets or sets the outbound (egress) routing method.
        /// </summary>
        /// <remarks>
        /// This can only be set at cluster creation time and cannot be changed
        /// later. For more information see [egress outbound
        /// type](https://docs.microsoft.com/azure/aks/egress-outboundtype).
        /// Possible values include: 'loadBalancer', 'userDefinedRouting',
        /// 'managedNATGateway', 'userAssignedNATGateway'
        /// </remarks>
        public string OutboundType { get; set; }

        /// <summary>
        /// Gets or sets the load balancer sku for the managed cluster.
        /// </summary>
        /// <remarks>
        /// The default is 'standard'. See [Azure Load Balancer
        /// SKUs](https://docs.microsoft.com/azure/load-balancer/skus) for more
        /// information about the differences between load balancer SKUs.
        /// Possible values include: 'standard', 'basic'
        /// </remarks>
        public string LoadBalancerSku { get; set; }

        /// <summary>
        /// Gets or sets profile of the cluster load balancer.
        /// </summary>
        public PSManagedClusterLoadBalancerProfile LoadBalancerProfile { get; set; }

        /// <summary>
        /// Gets or sets profile of the cluster NAT gateway.
        /// </summary>
        public ManagedClusterNATGatewayProfile NatGatewayProfile { get; set; }

        /// <summary>
        /// Gets or sets the CIDR notation IP ranges from which to assign pod
        /// IPs.
        /// </summary>
        /// <remarks>
        /// One IPv4 CIDR is expected for single-stack networking. Two CIDRs,
        /// one for each IP family (IPv4/IPv6), is expected for dual-stack
        /// networking.
        /// </remarks>
        public IList<string> PodCidrs { get; set; }

        /// <summary>
        /// Gets or sets the CIDR notation IP ranges from which to assign
        /// service cluster IPs.
        /// </summary>
        /// <remarks>
        /// One IPv4 CIDR is expected for single-stack networking. Two CIDRs,
        /// one for each IP family (IPv4/IPv6), is expected for dual-stack
        /// networking. They must not overlap with any Subnet IP ranges.
        /// </remarks>
        public IList<string> ServiceCidrs { get; set; }

        /// <summary>
        /// Gets or sets the IP families used to specify IP versions available
        /// to the cluster.
        /// </summary>
        /// <remarks>
        /// IP families are used to determine single-stack or dual-stack
        /// clusters. For single-stack, the expected value is IPv4. For
        /// dual-stack, the expected values are IPv4 and IPv6.
        /// </remarks>
        public IList<string> IpFamilies { get; set; }

    }
}
