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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerStaticMember", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerStaticMember))]
    public class GetAzNetworkManagerStaticMemberCommand : NetworkManagerStaticMemberBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/networkGroups/staticMembers", "ResourceGroupName", "NetworkManagerName", "NetworkManagerGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager group name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/networkGroups", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var psStaticMember = this.GetNetworkManagerStaticMember(this.ResourceGroupName, this.NetworkManagerName, this.NetworkGroupName, this.Name);
                WriteObject(psStaticMember);
            }
            else
            {
                IPage<StaticMember> memberPage;
                memberPage = this.NetworkManagerStaticMemberClient.List(this.ResourceGroupName, this.NetworkManagerName, this.NetworkGroupName);

                // Get all resources by polling on next page link
                var staticMemberList = ListNextLink<StaticMember>.GetAllResourcesByPollingNextLink(memberPage, this.NetworkManagerStaticMemberClient.ListNext);

                var psStaticMemberList = new List<PSNetworkManagerStaticMember>();

                foreach (var staticMember in staticMemberList)
                {
                    var psStaticMember = this.ToPsNetworkManagerStaticMember(staticMember);
                    psStaticMember.ResourceGroupName = this.ResourceGroupName;
                    psStaticMember.NetworkGroupName = this.NetworkGroupName;
                    psStaticMember.NetworkManagerName = this.NetworkManagerName;
                    psStaticMemberList.Add(psStaticMember);
                }

                WriteObject(psStaticMemberList);
            }
        }
    }
}
