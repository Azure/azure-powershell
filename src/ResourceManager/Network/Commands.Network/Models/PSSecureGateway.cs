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
    public class PSSecureGateway : PSTopLevelResource
    {
        public List<PSSecureGatewayIpConfiguration> IpConfigurations { get; set; }

        public List<PSSecureGatewayApplicationRuleCollection> ApplicationRuleCollections { get; set; }
        
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

        public void AddApplicationRuleCollection(PSSecureGatewayApplicationRuleCollection ruleCollection)
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
                this.ApplicationRuleCollections = new List<PSSecureGatewayApplicationRuleCollection>();
            }

            this.ApplicationRuleCollections.Add(ruleCollection);
        }

        public PSSecureGatewayApplicationRuleCollection GetApplicationRuleCollectionByName(string ruleCollectionName)
        {
            if (null == ruleCollectionName)
            {
                return null;
            }

            return this.ApplicationRuleCollections?.FirstOrDefault(rc => ruleCollectionName.Equals(rc.Name));
        }

        public PSSecureGatewayApplicationRuleCollection GetApplicationRuleCollectionByPriority(uint priority)
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
