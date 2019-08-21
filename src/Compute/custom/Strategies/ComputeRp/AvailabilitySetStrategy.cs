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
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class AvailabilitySetStrategy
    {
        public static ResourceStrategy<AvailabilitySet> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "availabilitySets",
                getOperations: client => client.GetAvailabilitySetOperations(),
                getAsync: (o, p) => o.Get(p.ResourceGroupName, p.Name),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdate(p.ResourceGroupName, p.Name, p.Model as AvailabilitySet), createTime: t => -1);

        public static ResourceConfig<AvailabilitySet> CreateAvailabilitySetConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<IEngine, SubResource> proximityPlacementGroup)
            => Strategy.CreateNoncreatableResourceConfig(resourceGroup: resourceGroup, name: name);
    }
}
