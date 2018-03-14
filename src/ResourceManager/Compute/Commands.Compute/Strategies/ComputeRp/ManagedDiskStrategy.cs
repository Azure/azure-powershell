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

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class ManagedDiskStrategy
    {
        public static ResourceStrategy<Disk> Strategy { get; }
            = ComputeStrategy.Create(
                provider: "disks",
                getOperations: client => client.Disks,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: d => 120);

        public static ResourceConfig<Disk> CreateManagedDiskConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string sourceUri)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: subscription => new Disk
                {
                    Sku = new DiskSku
                    {
                        Name = StorageAccountTypes.PremiumLRS
                    },
                    CreationData = new CreationData
                    {
                        CreateOption = DiskCreateOption.Import,
                        SourceUri = sourceUri
                    }
                });
    }
}
