//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewall : PSTopLevelResource
    {
        private const string AzureFirewallSubnetName = "SecureGatewaySubnet";
        private const int AzureFirewallSubnetMinSize = 25;
        private const string AzureFirewallIpConfigurationName = "SecureGatewayIpConfiguration";

        public List<PSAzureFirewallIpConfiguration> IpConfigurations { get; set; }

        public List<PSAzureFirewallApplicationRuleCollection> ApplicationRuleCollections { get; set; }
        
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationRuleCollectionsText
        {
            get { return JsonConvert.SerializeObject(ApplicationRuleCollections, Formatting.Indented); }
        }

        public void AttachToVirtualNetwork(PSVirtualNetwork virtualNetwork)
        {
            if (virtualNetwork == null)
            {
                throw new ArgumentNullException(nameof(virtualNetwork), $"Virtual Network cannot be null!");
            }

            PSSubnet firewallSubnet = null;
            try
            {
                firewallSubnet = virtualNetwork.Subnets.Single(subnet => AzureFirewallSubnetName.Equals(subnet.Name));
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Virtual Network {virtualNetwork.Name} should contain a Subnet named {AzureFirewallSubnetName}");
            }

            var subnetSize = int.Parse(firewallSubnet.AddressPrefix.Split(new[] { '/' })[1]);
            if (subnetSize > AzureFirewallSubnetMinSize)
            {
                throw new ArgumentException($"The AddressPrefix ({firewallSubnet.AddressPrefix}) of the {AzureFirewallSubnetName} of the referenced Virtual Network must be at least /{AzureFirewallSubnetMinSize}");
            }

            this.IpConfigurations = new List<PSAzureFirewallIpConfiguration>
                {
                    new PSAzureFirewallIpConfiguration
                    {
                        Name = AzureFirewallIpConfigurationName,
                        Subnet = new PSResourceId { Id = firewallSubnet.Id }
                    }
                };
        }

        public void DetachFromVirtualNetwork()
        {
            this.IpConfigurations = null;
        }

        public void AddApplicationRuleCollection(PSAzureFirewallApplicationRuleCollection ruleCollection)
        {
            // Validate
            if (this.ApplicationRuleCollections != null)
            {
                if (this.ApplicationRuleCollections.Any(rc => rc.Name.Equals(ruleCollection.Name)))
                {
                    throw new ArgumentException($"Application Rule Collection names must be unique. {ruleCollection.Name} name is already used.");
                }

                var samePriorityRuleCollections = this.ApplicationRuleCollections.Where(rc => rc.Priority == ruleCollection.Priority);
                if (samePriorityRuleCollections.Any())
                {
                    throw new ArgumentException($"Application Rule Collection priorities must be unique. Priority {ruleCollection.Priority} is already used by Rule Collection {samePriorityRuleCollections.First().Name}.");
                }
            }
            else
            {
                this.ApplicationRuleCollections = new List<PSAzureFirewallApplicationRuleCollection>();
            }

            this.ApplicationRuleCollections.Add(ruleCollection);
        }

        public PSAzureFirewallApplicationRuleCollection GetApplicationRuleCollectionByName(string ruleCollectionName)
        {
            if (null == ruleCollectionName)
            {
                return null;
            }

            return this.ApplicationRuleCollections?.FirstOrDefault(rc => ruleCollectionName.Equals(rc.Name));
        }

        public PSAzureFirewallApplicationRuleCollection GetApplicationRuleCollectionByPriority(uint priority)
        {
            return this.ApplicationRuleCollections?.FirstOrDefault(rc => rc.Priority == priority);
        }

        public void RemoveApplicationRuleCollectionByName(string ruleCollectionName)
        {
            var ruleCollection = this.GetApplicationRuleCollectionByName(ruleCollectionName);
            this.ApplicationRuleCollections?.Remove(ruleCollection);
        }

        public void RemoveApplicationRuleCollectionByPriority(uint priority)
        {
            var ruleCollection = this.GetApplicationRuleCollectionByPriority(priority);
            this.ApplicationRuleCollections?.Remove(ruleCollection);
        }
    }
}
