
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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class AzureFirewallPolicyDraftCmdlet : NetworkBaseCmdlet
    {
        public IFirewallPolicyDraftsOperations AzureFirewallPolicyDraftClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyDrafts;
            }
        }

        protected string ExtractFirewallPolicyNameFromDraftResourceId(string resourceId)
        {
            string pattern = @"firewallpolicies\/([^,\/]+)";
            Match match = new Regex(pattern).Match(resourceId.ToLower());
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                throw new ArgumentException(Properties.Resources.InvalidResourceId);
            }
        }

        public PSAzureFirewallPolicyDraft GetAzureFirewallPolicyDraft(string resourceGroupName, string name)
        {
            var azureFirewallPolicyDraft = this.AzureFirewallPolicyDraftClient.Get(resourceGroupName, name);
            var psAzureFirewallDraft = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicyDraft>(azureFirewallPolicyDraft);
            return psAzureFirewallDraft;
        }

        public PSAzureFirewallPolicyDraft ToPsAzureFirewallPolicyDraft(FirewallPolicy firewallPolicy)
        {
            var azureFirewallPolicyDraft = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicyDraft>(firewallPolicy);
            return azureFirewallPolicyDraft;
        }
    }
}
