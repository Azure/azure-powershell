// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Models
{
    /// <summary>
    /// Load balancer settings for managed NVAs and their Permanent inbound security rules.
    /// Compatibility model for the 2026-05-01 contract; remove when SDK regeneration supplies it.
    /// </summary>
    public class NetworkVirtualApplianceLoadBalancerConfiguration
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "loadDistribution")]
        public string LoadDistribution { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "idleTimeoutInMinutes")]
        public int? IdleTimeoutInMinutes { get; set; }
    }

    public partial class NetworkVirtualAppliance
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.loadBalancerConfiguration")]
        public NetworkVirtualApplianceLoadBalancerConfiguration LoadBalancerConfiguration { get; set; }
    }

    public partial class InboundSecurityRules
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "loadBalancerConfiguration")]
        public NetworkVirtualApplianceLoadBalancerConfiguration LoadBalancerConfiguration { get; set; }
    }
}
