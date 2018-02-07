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
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class PublicIPAddressStrategy
    {
        public static ResourceStrategy<PublicIPAddress> Strategy { get; }
            = NetworkStrategy.Create(
                type: "public IP address",
                provider: "publicIPAddresses",
                getOperations: client => client.PublicIPAddresses,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 15);

        public static ResourceConfig<PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string> getDomainNameLabel,
            string allocationMethod)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: _ => new PublicIPAddress
                {
                    PublicIPAllocationMethod = allocationMethod,
                    DnsSettings = new PublicIPAddressDnsSettings
                    {
                        DomainNameLabel = getDomainNameLabel(),
                    }
                });

        public static async Task<string> UpdateDomainNameLabelAsync(
            string domainNameLabel,
            string name,
            string location,
            IClient client)
        {
            if (domainNameLabel == null)
            {
                var networkClient = client.GetClient<NetworkManagementClient>();
                do
                {
                    domainNameLabel = (name + '-' + Guid.NewGuid().ToString().Substring(0, 6))
                        .ToLower();
                } while ((await networkClient.CheckDnsNameAvailabilityAsync(
                            location,
                            domainNameLabel))
                        .Available
                    != true);
            }
            return domainNameLabel;
        }

        public static string Fqdn(string domainNameLabel, string location)
            => domainNameLabel + "." + location + ".cloudapp.azure.com";
    }
}
