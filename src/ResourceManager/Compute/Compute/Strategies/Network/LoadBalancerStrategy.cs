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
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{

    public static class LoadBalancerStrategy
    {
        public const string Dynamic = "Dynamic";
        public const string Static = "Static";

        public static bool IgnorePreExistingConfigCheck { get; set; }

        public static ResourceStrategy<LoadBalancer> Strategy { get; }
            = NetworkStrategy.Create(
                "loadBalancers",
                client => client.LoadBalancers,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                _ => 30,
                EvaluatePreExistingConfig);

        public enum Sku
        {
            Basic,
            Standard,
        }

        static bool EvaluatePreExistingConfig(LoadBalancer configToCompare)
        {
            if (IgnorePreExistingConfigCheck)
            {
                return true;
            }

            // TODO: Figure out the differences in the two configs n see if we can work with the existing resource.
            // If we can use the resource return true, otherwise return false

            //Throw in case the config for the existing LB is not cvompatible with the one expected by the cmdlet
            throw new System.ArgumentException("Existing loadbalancer config is not compatible with what is required by the cmdlet. Kindly rerun the cmdlet after deleting the existing LB with name : " + configToCompare.Name + " and ID : " + configToCompare.Id);
        }

        public static ResourceConfig<LoadBalancer> CreateLoadBalancerConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Sku sku)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: engine => new LoadBalancer
                {
                    Sku = new LoadBalancerSku
                    {
                        Name = sku.ToString()
                    }
                });
    }
}
