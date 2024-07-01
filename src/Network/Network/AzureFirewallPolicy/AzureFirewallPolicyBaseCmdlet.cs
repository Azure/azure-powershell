
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

using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class AzureFirewallPolicyBaseCmdlet : NetworkBaseCmdlet
    {
        public IFirewallPoliciesOperations AzureFirewallPolicyClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicies;
            }
        }

        public IAzureFirewallFqdnTagsOperations AzureFirewallPolicyFqdnTagClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.AzureFirewallFqdnTags;
            }
        }

        public IFirewallPolicyDeploymentsOperations AzureFirewallPolicyDeploymentsClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyDeployments;
            }
        }

        public PSAzureFirewallPolicy GetAzureFirewallPolicy(string resourceGroupName, string name)
        {
            var azureFirewallPolicy = this.AzureFirewallPolicyClient.Get(resourceGroupName, name);

            var psAzureFirewall = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicy>(azureFirewallPolicy);
            if(azureFirewallPolicy.RuleCollectionGroups != null)
            {
                psAzureFirewall.RuleCollectionGroups = new List<SubResource>(azureFirewallPolicy.RuleCollectionGroups);
            }
            else
            {
                psAzureFirewall.RuleCollectionGroups = new List<SubResource>();
            }
            psAzureFirewall.ResourceGroupName = resourceGroupName;
            psAzureFirewall.Tag = TagsConversionHelper.CreateTagHashtable(azureFirewallPolicy.Tags);

            return psAzureFirewall;
        }

        public PSAzureFirewallPolicy ToPsAzureFirewallPolicy(FirewallPolicy firewall)
        {
            var azureFirewallPolicy = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicy>(firewall);

            azureFirewallPolicy.Tag = TagsConversionHelper.CreateTagHashtable(firewall.Tags);

            return azureFirewallPolicy;
        }
    }
}
