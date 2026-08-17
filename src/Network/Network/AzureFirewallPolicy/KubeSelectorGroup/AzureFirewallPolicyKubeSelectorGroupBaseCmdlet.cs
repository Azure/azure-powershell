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

using Microsoft.Azure.Commands.Network.Common;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class AzureFirewallPolicyKubeSelectorGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public IFirewallPolicyKubeSelectorGroupsOperations KubeSelectorGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyKubeSelectorGroups;
            }
        }

        public PSAzureFirewallPolicyKubeSelectorGroupWrapper GetKubeSelectorGroup(string resourceGroupName, string firewallPolicyName, string name)
        {
            var kubeSelectorGroup = this.KubeSelectorGroupClient.Get(resourceGroupName, firewallPolicyName, name);
            return ToPSWrapper(kubeSelectorGroup);
        }

        public PSAzureFirewallPolicyKubeSelectorGroupWrapper ToPSWrapper(MNM.FirewallPolicyKubeSelectorGroup kubeSelectorGroup)
        {
            var psKubeSelectorGroup = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicyKubeSelectorGroup>(kubeSelectorGroup);
            return new PSAzureFirewallPolicyKubeSelectorGroupWrapper
            {
                Name = kubeSelectorGroup.Name,
                Properties = psKubeSelectorGroup
            };
        }

        public MNM.FirewallPolicyKubeSelectorGroup BuildSdkModel(PSKubeLabelSelector podSelector, PSKubeLabelSelector namespaceSelector)
        {
            return new MNM.FirewallPolicyKubeSelectorGroup
            {
                Properties = new MNM.FirewallPolicyKubeSelectorGroupProperties
                {
                    PodSelector = podSelector == null ? null : NetworkResourceManagerProfile.Mapper.Map<MNM.KubeLabelSelector>(podSelector),
                    NamespaceSelector = namespaceSelector == null ? null : NetworkResourceManagerProfile.Mapper.Map<MNM.KubeLabelSelector>(namespaceSelector)
                }
            };
        }
    }
}
