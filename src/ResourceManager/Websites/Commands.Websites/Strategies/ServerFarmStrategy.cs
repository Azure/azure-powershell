﻿//
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

using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.Common.Strategies.WebApps
{
    static class ServerFarmStrategy
    {
        public static ResourceStrategy<AppServicePlan> Strategy { get; } = AppServicePolicy.Create(
            provider: "serverFarms",
            getOperations: client => client.AppServicePlans,
            getAsync: (o, p) => o.GetAsync(p.ResourceGroupName, p.Name, p.CancellationToken),
            createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(p.ResourceGroupName, p.Name, p.Model, cancellationToken: p.CancellationToken),
            createTime: _ => 5,
            compulsoryLocation: true);

        public static ResourceConfig<AppServicePlan> CreateServerFarmConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string resourceGroupName,
            string name, bool isXenon = false ) => Strategy.CreateResourceConfig(
                resourceGroup,
                name,
                createModel: _ => 
				{
					string tier = isXenon ? "PremiumContainer" : "Basic";
					return new AppServicePlan(location: null, name: name)
					{
						Sku = new SkuDescription { Tier = tier, Capacity = 1, Name = CmdletHelpers.GetSkuName(tier, 1) },
						IsXenon = isXenon
					};
				});
    }
}
