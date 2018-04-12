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
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.Network
{
    static class PublicIPAddressStrategy
    {
        public static ResourceStrategy<PublicIPAddress> Strategy { get; }
            = NetworkStrategy.Create(
                provider: "publicIPAddresses",
                getOperations: client => client.PublicIPAddresses,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: _ => 15);

        public enum Sku
        {
            Basic,
            Standard,
        }

        public static ResourceConfig<PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string domainNameLabel,
            string allocationMethod,
            Sku sku,
            IList<string> zones)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: _ => new PublicIPAddress
                {
                    PublicIPAllocationMethod = allocationMethod,
                    DnsSettings = new PublicIPAddressDnsSettings
                    {
                        DomainNameLabel = domainNameLabel,
                    },
                    Sku = new PublicIPAddressSku
                    {
                        Name = sku.ToString(),
                    },
                    Zones = zones,
                });

        public static async Task<string> UpdateDomainNameLabelAsync(
            string domainNameLabel,
            string subscriptionId,
            string resourceGroupName,
            string publicIpAddressName)
        {
            if (domainNameLabel == null)
            {
                var id = subscriptionId + "/" + resourceGroupName + "/" + publicIpAddressName;
                var bytes= Encoding.UTF8.GetBytes(id);
                var hash = SHA1.Create().ComputeHash(bytes);
                return "x" + string.Join("", hash.Select(v => v.ToString("x2")));
            }
            return domainNameLabel;
        }

        public static string Fqdn(string domainNameLabel, string location)
            => domainNameLabel + "." + location + ".cloudapp.azure.com";
    }
}
