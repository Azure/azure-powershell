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

using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public static class ChildResourceHelper
    {
        public static string GetResourceId(string subscriptionId, string resourceGroupName, string loadBalancerName,
            string resource, string resourceName)
        {
            return string.Format(Resources.LoadBalancerChildResourceId, subscriptionId, resourceGroupName,
                loadBalancerName, resource, resourceName);
        }

        public static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(Resources.LoadBalancerChildResourceId, subscriptionId, Resources.ResourceGroupNotSet,
                Resources.LoadBalancerNameNotSet, resource, resourceName);
        }

        public static string NormalizeResourceId(string id, string resourceGroupName, string loadBalancerName)
        {
            id = id.Replace(Resources.ResourceGroupNotSet, resourceGroupName);
            id = id.Replace(Resources.LoadBalancerNameNotSet, loadBalancerName);

            return id;
        }

        public static void NormalizeChildResourcesId(PSLoadBalancer loadBalancer)
        {
            // Normalize LoadBalancingRules
            foreach (var loadBalancingRule in loadBalancer.Properties.LoadBalancingRules)
            {
                loadBalancingRule.Id = string.Empty;

                foreach (var frontendIpConfiguration in loadBalancingRule.Properties.FrontendIPConfigurations)
                {
                    frontendIpConfiguration.Id = NormalizeResourceId(frontendIpConfiguration.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);
                }

                loadBalancingRule.Properties.BackendAddressPool.Id =
                    NormalizeResourceId(loadBalancingRule.Properties.BackendAddressPool.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);

                loadBalancingRule.Properties.Probe.Id =
                    NormalizeResourceId(loadBalancingRule.Properties.Probe.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);
            }

            // Normalize InboundNatRule
            foreach (var inboundNatRule in loadBalancer.Properties.InboundNatRules)
            {
                inboundNatRule.Id = string.Empty;

                foreach (var frontendIpConfiguration in inboundNatRule.Properties.FrontendIPConfigurations)
                {
                    frontendIpConfiguration.Id = NormalizeResourceId(frontendIpConfiguration.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);
                }
            }

            // Normalize FrontendIpconfig
            foreach (var frontendIpConfig in loadBalancer.Properties.FrontendIpConfigurations)
            {
                frontendIpConfig.Id = string.Empty;
            }

            // Normalize Probe
            foreach (var probe in loadBalancer.Properties.Probes)
            {
                probe.Id = string.Empty;
            }

            // Normalize BackendAddressPool
            foreach (var backendAddressPool in loadBalancer.Properties.BackendAddressPools)
            {
                backendAddressPool.Id = string.Empty;
            }
        }
    }
}
