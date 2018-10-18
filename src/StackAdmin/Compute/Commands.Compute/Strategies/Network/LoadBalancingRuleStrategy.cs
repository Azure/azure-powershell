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
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class LoadBalancingRuleStrategy
    {
        public static NestedResourceStrategy<LoadBalancingRule, LoadBalancer> Strategy { get; }
            = NestedResourceStrategy.Create<LoadBalancingRule, LoadBalancer>(
                provider: "loadBalancingRules",
                getList: parentModel => parentModel.LoadBalancingRules,
                setList: (parentModel, list) => parentModel.LoadBalancingRules = list,
                getName: model => model.Name,
                setName: (model, name) => model.Name = name);

        public static NestedResourceConfig<LoadBalancingRule, LoadBalancer> CreateLoadBalancingRule(
            this ResourceConfig<LoadBalancer> loadBalancer,
            string name,
            NestedResourceConfig<FrontendIPConfiguration, LoadBalancer> fronendIpConfiguration,
            NestedResourceConfig<BackendAddressPool, LoadBalancer> backendAddressPool,
            int frontendPort,
            int backendPort)
            => loadBalancer.CreateNested(
                Strategy,
                name,
                engine => new LoadBalancingRule
                {
                    FrontendIPConfiguration = engine.GetReference(fronendIpConfiguration),
                    BackendAddressPool = engine.GetReference(backendAddressPool),
                    Protocol = NetworkStrategy.Tcp,
                    FrontendPort = frontendPort,
                    BackendPort = backendPort,
                });
    }
}
