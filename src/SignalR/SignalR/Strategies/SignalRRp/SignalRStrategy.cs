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
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Strategies.SignalRRp
{
    static class SignalRStrategy
    {
        public static ResourceStrategy<SignalRResource> Strategy { get; }
            = ResourceStrategy.Create(
                type: new ResourceType("Microsoft.SignalRService", "SignalR"),
                getOperations: (SignalRManagementClient client) => client.SignalR,
                getAsync: (o, p) => o.GetAsync(p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName,
                    p.Name,
                    new SignalRResource(
                        location: p.Model.Location,
                        tags: p.Model.Tags,
                        sku: p.Model.Sku,
                        hostNamePrefix: p.Model.HostNamePrefix),
                    p.CancellationToken),
                getLocation: config => config.Location,
                setLocation: (config, location) => config.Location = location,
                createTime: c => 180,
                compulsoryLocation: true);
    }
}
