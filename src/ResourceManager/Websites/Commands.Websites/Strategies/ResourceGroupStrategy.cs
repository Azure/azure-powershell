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

using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Resources
{
    public static class ResourceGroupStrategy
    {
        public static ResourceStrategy<ResourceGroup> Strategy { get; }
            = ResourceStrategy.Create(
                type: ResourceType.ResourceGroup,
                getOperations: (ResourceManagementClient client) => client.ResourceGroups,
                getAsync: (o, p) => o.GetAsync(p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p)
                    => o.CreateOrUpdateAsync(p.Name, p.Model, p.CancellationToken),
                getLocation: model => model.Location,
                setLocation: (model, location) => model.Location = location,
                createTime: _ => 3,
                compulsoryLocation: false);

        public static ResourceConfig<ResourceGroup> CreateResourceGroupConfig(string name)
            => Strategy.CreateResourceConfig(null, name);
    }
}
