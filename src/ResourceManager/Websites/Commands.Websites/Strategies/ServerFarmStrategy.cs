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

using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.Common.Strategies.WebApps
{
    static class ServerFarmStrategy
    {
        public static ResourceStrategy<ServerFarmWithRichSku> Strategy { get; } = AppServicePolicy.Create(
            type: "App Service Plan",
            provider: "serverFarms",
            getOperations: client => client.ServerFarms,
            getAsync: (o, p) => o.GetServerFarmAsync(p.ResourceGroupName, p.Name, p.CancellationToken),
            createOrUpdateAsync: (o, p) => o.CreateOrUpdateServerFarmAsync(p.ResourceGroupName, p.Name, p.Model, cancellationToken: p.CancellationToken),
            createTime: _ => 5,
            compulsoryLocation: true);

        public static ResourceConfig<ServerFarmWithRichSku> CreateServerFarmConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string resourceGroupName,
            string name) => Strategy.CreateConfig(
                resourceGroupName,
                name,
                createModel: subscription => 
                    new ServerFarmWithRichSku
                    {
                        Name = name,
                        Sku = new SkuDescription {Tier = "Free", Capacity = 1, Name = CmdletHelpers.GetSkuName("Free", 1) }
                    },
                dependencies: new IEntityConfig[] { resourceGroup });
    }
}
