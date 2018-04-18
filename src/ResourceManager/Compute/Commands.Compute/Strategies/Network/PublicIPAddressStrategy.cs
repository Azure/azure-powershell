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

        public static string UpdateDomainNameLabelAsync(
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

                // // remove digits from the first letter.
                // hash[0] |= 0xC0
                // return string.Join("", hash.Select(v => v.ToString("x2")));

                // remove digits from the first letter.
                hash[0] |= 0x80;
                return string.Join("", Crockford(hash));
            }
            return domainNameLabel;
        }

        private static IEnumerable<char> Crockford(IEnumerable<byte> stream)
        {
            //                     0         1         2         3
            //                     01234567890123456789012345678901
            const string Encode = "0123456789abcdefghjkmnpqrstvwxyz";
            var b = 0;
            var size = 0;
            var first = true;
            foreach (var v in stream)
            {
                b = (b << 8) | v;
                size += 8;
                //
                while (size >= 5)
                {
                    size -= 5;
                    var index = (b >> size) & 0x1F;
                    yield return Encode[index];
                }
            }
            if (size > 0)
            {
                var index = (b << (5 - size)) & 0x1F;
                yield return Encode[index];
            }
        }

        public static string Fqdn(string domainNameLabel, string location)
            => domainNameLabel + "." + location + ".cloudapp.azure.com";
    }
}
