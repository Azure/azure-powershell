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
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public static class ChildResourceHelper
    {
        public static string GetResourceId(
            string subscriptionId,
            string resourceGroupName,
            string loadBalancerName,
            string resource,
            string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerChildResourceId,
                subscriptionId,
                resourceGroupName,
                loadBalancerName,
                resource,
                resourceName);
        }

        public static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerChildResourceId,
                subscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerNameNotSet,
                resource,
                resourceName);
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
            if (loadBalancer.LoadBalancingRules != null)
            {
                foreach (var loadBalancingRule in loadBalancer.LoadBalancingRules)
                {
                    loadBalancingRule.Id = string.Empty;

                    if (loadBalancingRule.FrontendIPConfiguration != null)
                    {
                        loadBalancingRule.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.FrontendIPConfiguration.Id,
                                loadBalancer.ResourceGroupName,
                                loadBalancer.Name);
                    }

                    if (loadBalancingRule.BackendAddressPool != null)
                    {
                        loadBalancingRule.BackendAddressPool.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.BackendAddressPool.Id,
                                loadBalancer.ResourceGroupName,
                                loadBalancer.Name);
                    }

                    if (loadBalancingRule.Probe != null)
                    {
                        loadBalancingRule.Probe.Id = 
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.Probe.Id,
                                loadBalancer.ResourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize InboundNatRule
            if (loadBalancer.InboundNatRules != null)
            {
                foreach (var inboundNatRule in loadBalancer.InboundNatRules)
                {
                    inboundNatRule.Id = string.Empty;

                    if (inboundNatRule.FrontendIPConfiguration != null)
                    {
                        inboundNatRule.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                inboundNatRule.FrontendIPConfiguration.Id,
                                loadBalancer.ResourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize InboundNatPool
            if (loadBalancer.InboundNatPools != null)
            {
                foreach (var inboundNatPool in loadBalancer.InboundNatPools)
                {
                    inboundNatPool.Id = string.Empty;

                    if (inboundNatPool.FrontendIPConfiguration != null)
                    {
                        inboundNatPool.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                inboundNatPool.FrontendIPConfiguration.Id,
                                loadBalancer.ResourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize FrontendIpconfig
            if (loadBalancer.FrontendIpConfigurations != null)
            {
                foreach (var frontendIpConfig in loadBalancer.FrontendIpConfigurations)
                {
                    frontendIpConfig.Id = string.Empty;
                }
            }

            // Normalize Probe
            if (loadBalancer.Probes != null)
            {
                foreach (var probe in loadBalancer.Probes)
                {
                    probe.Id = string.Empty;
                }
            }

            // Normalize BackendAddressPool
            if (loadBalancer.BackendAddressPools != null)
            {
                foreach (var backendAddressPool in loadBalancer.BackendAddressPools)
                {
                    backendAddressPool.Id = string.Empty;
                }
            }
        }
    }
}
