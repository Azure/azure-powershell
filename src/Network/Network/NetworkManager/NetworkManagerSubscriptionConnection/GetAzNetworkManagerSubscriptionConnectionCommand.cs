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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSubscriptionConnection", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManagerConnection))]
    public class GetAzNetworkManagerSubscriptionConnectionCommand : NetworkManagerSubscriptionConnectionBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagerConnections")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var networkManagerSubscriptionConnection = this.GetNetworkManagerSubscriptionConnection(this.Name);

                WriteObject(networkManagerSubscriptionConnection);
            }
            else
            {
                IPage<NetworkManagerConnection> ccPage;
                ccPage = this.NetworkManagerSubscriptionConnectionClient.List();

                // Get all resources by polling on next page link
                var nccList = ListNextLink<NetworkManagerConnection>.GetAllResourcesByPollingNextLink(ccPage, this.NetworkManagerSubscriptionConnectionClient.ListNext);

                var psNmccList = new List<PSNetworkManagerConnection>();

                foreach (var networkManagerSubscriptionConnection in nccList)
                {
                    var psNmsc = this.ToPsNetworkManagerSubscriptionConnection(networkManagerSubscriptionConnection);
                    psNmccList.Add(psNmsc);
                }

                WriteObject(psNmccList);
            }
        }
    }
}
