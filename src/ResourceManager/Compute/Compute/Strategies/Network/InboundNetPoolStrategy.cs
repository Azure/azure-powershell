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
    static class InboundNetPoolStrategy
    {
        public static NestedResourceStrategy<InboundNatPool, LoadBalancer> Strategy { get; }
            = NestedResourceStrategy.Create<InboundNatPool, LoadBalancer>(
                provider: "inboundNatPools",
                getList: b => b.InboundNatPools,
                setList: (b, list) => b.InboundNatPools = list,
                getName: p => p.Name,
                setName: (p, name) => p.Name = name);

        public static NestedResourceConfig<InboundNatPool, LoadBalancer> CreateInboundNatPool(
            this ResourceConfig<LoadBalancer> loadBalancer,
            string name,
            NestedResourceConfig<FrontendIPConfiguration, LoadBalancer> frontendIpConfiguration,
            int frontendPortRangeStart,
            int frontendPortRangeEnd,
            int backendPort)
            => loadBalancer.CreateNested(
                Strategy,
                name,
                engine => new InboundNatPool
                {
                    FrontendIPConfiguration = engine.GetReference(frontendIpConfiguration),
                    Protocol = NetworkStrategy.Tcp,
                    FrontendPortRangeStart = frontendPortRangeStart,
                    FrontendPortRangeEnd = frontendPortRangeEnd,
                    BackendPort = backendPort
                });
    }
}
