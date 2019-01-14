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
using Microsoft.Azure.Management.Compute.Models;
using N = Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class SubResourceStrategy
    {
        static SubResource GetSubResourceReference(
            this IEngine engine, IEntityConfig config)
            => config == null ? null : new SubResource { Id = engine.GetId(config) };

        public static SubResource GetReference(
            this IEngine engine, ResourceConfig<AvailabilitySet> availabilitySet)
            => engine.GetSubResourceReference(availabilitySet);

        public static SubResource GetReference(
            this IEngine engine,
            NestedResourceConfig<N.BackendAddressPool, N.LoadBalancer> backendAddressPool)
            => engine.GetSubResourceReference(backendAddressPool);

        public static SubResource GetReference(
            this IEngine engine,
            NestedResourceConfig<N.InboundNatPool, N.LoadBalancer> inboundNatPool)
            => engine.GetSubResourceReference(inboundNatPool);
    }
}
