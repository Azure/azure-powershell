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

using System;
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

        private static string NormalizeLoadBalancerChildResourceIds(string id, string resourceGroupName, string loadBalancerName)
        {
            id = NormalizeId(id, "resourceGroups", resourceGroupName);
            id = NormalizeId(id, "loadBalancers", loadBalancerName);

            return id;
        }

        private static string NormalizeId(string id, string resourceName, string resourceValue)
        {
            int startIndex = id.IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) + resourceName.Length + 1;
            int endIndex = id.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);
            
            // Replace the following string '/{value}/'
            startIndex--;
            string orignalString = id.Substring(startIndex, endIndex - startIndex + 1);

            return id.Replace(orignalString, string.Format("/{0}/", resourceValue));
        }

        public static void NormalizeChildResourcesId(PSLoadBalancer loadBalancer)
        {
            // Normalize LoadBalancingRules
            foreach (var loadBalancingRule in loadBalancer.Properties.LoadBalancingRules)
            {
                loadBalancingRule.Id = string.Empty;

                foreach (var frontendIpConfiguration in loadBalancingRule.Properties.FrontendIPConfigurations)
                {
                    frontendIpConfiguration.Id = NormalizeLoadBalancerChildResourceIds(frontendIpConfiguration.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);
                }

                loadBalancingRule.Properties.BackendAddressPool.Id =
                    NormalizeLoadBalancerChildResourceIds(loadBalancingRule.Properties.BackendAddressPool.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);

                loadBalancingRule.Properties.Probe.Id =
                    NormalizeLoadBalancerChildResourceIds(loadBalancingRule.Properties.Probe.Id,
                        loadBalancer.ResourceGroupName, loadBalancer.Name);
            }

            // Normalize InboundNatRule
            if (loadBalancer.Properties.InboundNatRules != null)
            {
                foreach (var inboundNatRule in loadBalancer.Properties.InboundNatRules)
                {
                    inboundNatRule.Id = string.Empty;

                    foreach (var frontendIpConfiguration in inboundNatRule.Properties.FrontendIPConfigurations)
                    {
                        frontendIpConfiguration.Id = NormalizeLoadBalancerChildResourceIds(frontendIpConfiguration.Id,
                            loadBalancer.ResourceGroupName, loadBalancer.Name);
                    }
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
