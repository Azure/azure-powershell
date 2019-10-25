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

namespace Microsoft.Azure.Commands.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System.Linq;

    public class PSBastion : PSTopLevelResource
    {
        private const string BastionSubnetName = "AzureBastionSubnet";
        private const string BastionIpConfigurationName = "IpConf";

        public List<PSBastionIPConfiguration> IpConfigurations { get; set; }

        public string DnsName { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public void Allocate(PSVirtualNetwork virtualNetwork, PSPublicIpAddress publicIpAddress)
        {
            if (virtualNetwork == null)
            {
                throw new ArgumentNullException(nameof(virtualNetwork), "Virtual Network cannot be null!");
            }

            if (publicIpAddress == null)
            {
                throw new ArgumentNullException(nameof(publicIpAddress), "Public IP Addresses cannot be null or empty!");
            }

            //proper error message 
            PSSubnet BastionSubnet = null;
            try
            {
                BastionSubnet = virtualNetwork.Subnets.Single(subnet => BastionSubnetName.Equals(subnet.Name, StringComparison.OrdinalIgnoreCase));
            }

            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Virtual Network {virtualNetwork.Name} should contain a Subnet named {BastionSubnetName}");
            }

            this.IpConfigurations = new List<PSBastionIPConfiguration>();

            this.IpConfigurations.Add(
                    new PSBastionIPConfiguration
                    {
                        Name = BastionIpConfigurationName,
                        PublicIpAddress = new PSResourceId { Id = publicIpAddress.Id },
                    });

            this.IpConfigurations[0].Subnet = new PSResourceId { Id = BastionSubnet.Id };
        }

        public void Deallocate()
        {
            this.IpConfigurations = new List<PSBastionIPConfiguration>();
        }
    }
}