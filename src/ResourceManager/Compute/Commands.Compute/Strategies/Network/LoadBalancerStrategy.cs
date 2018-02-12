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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{

    public static class LoadBalancerStrategy
    {
        public const string Dynamic = "Dynamic";
        public const string Static = "Static";
        public const string LoadBalancerRuleName = "loadBalancingRules";
        public const string LoadBalancerChildResourceId = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}";
        public const string LoadBalancerInBoundNatRuleName = "inboundNatRules";
        public const string LoadBalancerInboundNatPoolName = "inboundNatPools";
        public const string LoadBalancerFrontendIpConfigName = "frontendIPConfigurations";
        public const string LoadBalancerProbeName = "probes";
        public const string LoadBalancerBackendAddressPoolName = "backendAddressPools";
        public const string ResourceGroupNotSet = "ResourceGroupNotSet";
        public const string LoadBalancerNameNotSet = "LoadBalancerNameNotSet";

        public static ResourceStrategy<LoadBalancer> Strategy { get; }
            = NetworkStrategy.Create(
                "load balancer",
                "loadBalancers",
                client => client.LoadBalancers,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                _ => 30);

        public static ResourceConfig<LoadBalancer> CreateLoadBalancerConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string froontendPoolName,
            string backendPoolName,
            IList<string> zones,
            ResourceConfig<PublicIPAddress> publicIPAddress,
            NestedResourceConfig<Subnet, VirtualNetwork> subnet)
                => Strategy.CreateResourceConfig(
                    resourceGroup: resourceGroup,
                    name: name,
                    createModel: subscriptionId =>
                    {
                        var lb = new LoadBalancer();
                        NormalizeChildResourcesId(lb, subscriptionId, resourceGroup.Name);
                        return lb;
                    },
                    dependencies: new IEntityConfig[] { subnet, publicIPAddress });

        internal static void NormalizeChildResourcesId(LoadBalancer loadBalancer, string subscriptionId, string resourceGroupName)
        {
            // Normalize LoadBalancingRules
            if (loadBalancer.LoadBalancingRules != null)
            {
                foreach (var loadBalancingRule in loadBalancer.LoadBalancingRules)
                {
                    loadBalancingRule.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerRuleName, loadBalancingRule.Name);

                    if (loadBalancingRule.FrontendIPConfiguration != null)
                    {
                        loadBalancingRule.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.FrontendIPConfiguration.Id,
                                resourceGroupName,
                                loadBalancer.Name);
                    }

                    if (loadBalancingRule.BackendAddressPool != null)
                    {
                        loadBalancingRule.BackendAddressPool.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.BackendAddressPool.Id,
                                resourceGroupName,
                                loadBalancer.Name);
                    }

                    if (loadBalancingRule.Probe != null)
                    {
                        loadBalancingRule.Probe.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                loadBalancingRule.Probe.Id,
                                resourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize InboundNatRule
            if (loadBalancer.InboundNatRules != null)
            {
                foreach (var inboundNatRule in loadBalancer.InboundNatRules)
                {
                    inboundNatRule.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerInBoundNatRuleName, inboundNatRule.Name);

                    if (inboundNatRule.FrontendIPConfiguration != null)
                    {
                        inboundNatRule.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                inboundNatRule.FrontendIPConfiguration.Id,
                                resourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize InboundNatPool
            if (loadBalancer.InboundNatPools != null)
            {
                foreach (var inboundNatPool in loadBalancer.InboundNatPools)
                {
                    inboundNatPool.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerInboundNatPoolName, inboundNatPool.Name);

                    if (inboundNatPool.FrontendIPConfiguration != null)
                    {
                        inboundNatPool.FrontendIPConfiguration.Id =
                            NormalizeLoadBalancerChildResourceIds(
                                inboundNatPool.FrontendIPConfiguration.Id,
                                resourceGroupName,
                                loadBalancer.Name);
                    }
                }
            }

            // Normalize FrontendIpconfig
            if (loadBalancer.FrontendIPConfigurations != null)
            {
                foreach (var frontendIpConfig in loadBalancer.FrontendIPConfigurations)
                {
                    frontendIpConfig.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerFrontendIpConfigName, frontendIpConfig.Name);
                }
            }

            // Normalize Probe
            if (loadBalancer.Probes != null)
            {
                foreach (var probe in loadBalancer.Probes)
                {
                    probe.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerProbeName, probe.Name);
                }
            }

            // Normalize BackendAddressPool
            if (loadBalancer.BackendAddressPools != null)
            {
                foreach (var backendAddressPool in loadBalancer.BackendAddressPools)
                {
                    backendAddressPool.Id = GetResourceId(subscriptionId, resourceGroupName, loadBalancer.Name, LoadBalancerBackendAddressPoolName, backendAddressPool.Name);
                }
            }
        }

        internal static string GetResourceId(
                    string subscriptionId,
                    string resourceGroupName,
                    string loadBalancerName,
                    string resource,
                    string resourceName)
        {
            return string.Format(
                LoadBalancerChildResourceId,
                subscriptionId,
                resourceGroupName,
                loadBalancerName,
                resource,
                resourceName);
        }

        internal static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                LoadBalancerChildResourceId,
                subscriptionId,
                ResourceGroupNotSet,
                LoadBalancerNameNotSet,
                resource,
                resourceName);
        }

        internal static string NormalizeLoadBalancerChildResourceIds(string id, string resourceGroupName, string loadBalancerName)
        {
            id = NormalizeId(id, "resourceGroups", resourceGroupName);
            id = NormalizeId(id, "loadBalancers", loadBalancerName);
            return id;
        }

        internal static string NormalizeId(string id, string resourceName, string resourceValue)
        {
            int startIndex = id.IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) + resourceName.Length + 1;
            int endIndex = id.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            // Replace the following string '/{value}/'
            startIndex--;
            string orignalString = id.Substring(startIndex, endIndex - startIndex + 1);
            return id.Replace(orignalString, string.Format("/{0}/", resourceValue));
        }
    }
}
