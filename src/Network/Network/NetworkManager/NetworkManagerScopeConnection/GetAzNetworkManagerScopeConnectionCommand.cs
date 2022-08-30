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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerScopeConnection", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerScopeConnection))]
    public class GetAzNetworkManagerScopeConnectionCommand : NetworkManagerScopeConnectionBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/scopeConnections", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

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
                var networkManagerScopeConnection = this.GetNetworkManagerScopeConnection(this.ResourceGroupName, this.NetworkManagerName, this.Name);

                WriteObject(networkManagerScopeConnection);
            }
            else
            {
                IPage<ScopeConnection> ccPage;
                ccPage = this.NetworkManagerScopeConnectionClient.List(this.ResourceGroupName, this.NetworkManagerName);

                // Get all resources by polling on next page link
                var nccList = ListNextLink<ScopeConnection>.GetAllResourcesByPollingNextLink(ccPage, this.NetworkManagerScopeConnectionClient.ListNext);

                var psNmccList = new List<PSNetworkManagerScopeConnection>();

                foreach (var networkManagerScopeConnection in nccList)
                {
                    var psNmsc = this.ToPsNetworkManagerScopeConnection(networkManagerScopeConnection);
                    psNmsc.ResourceGroupName = this.ResourceGroupName;
                    psNmsc.NetworkManagerName = this.NetworkManagerName;
                    psNmccList.Add(psNmsc);
                }

                WriteObject(psNmccList);
            }
        }
    }
}
