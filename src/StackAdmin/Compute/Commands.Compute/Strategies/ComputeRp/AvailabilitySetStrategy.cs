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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class AvailabilitySetStrategy
    {
        public static ResourceStrategy<AvailabilitySet> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "availabilitySets",
                getOperations: client => client.AvailabilitySets,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: c => 1);

        public static ResourceConfig<AvailabilitySet> CreateAvailabilitySetConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: _ =>
                {
                    throw new InvalidOperationException("Availability set doesn't exist.");
                },
                dependencies: Enumerable.Empty<IEntityConfig>());
    }
}
