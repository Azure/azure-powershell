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
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerConnectivityGroupItem"), OutputType(typeof(PSNetworkManagerConnectivityGroupItem))]
    public class NewAzNetworkManagerConnectivityGroupItemCommand : NetworkManagerConnectivityConfigurationBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Network Group Id")]
        public string NetworkGroupId { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Use hub gateway flag")]
        public SwitchParameter UseHubGateway { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Group Connectivity. Valid values include 'None' and 'DirectlyConnected'.")]
        [ValidateSet("None", "DirectlyConnected", IgnoreCase = true)]
        public string GroupConnectivity { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "IsGlobal flag")]
        public SwitchParameter IsGlobal { get; set; }

        public override void Execute()
        {
            base.Execute();
            var psConnectivityGroupItem = new PSNetworkManagerConnectivityGroupItem();
            psConnectivityGroupItem.NetworkGroupId = this.NetworkGroupId;
            if(this.UseHubGateway)
            {
                psConnectivityGroupItem.UseHubGateway = "True";
            }
            else
            {
                psConnectivityGroupItem.UseHubGateway = "False";
            }

            if (!string.IsNullOrEmpty(GroupConnectivity))
            {
                psConnectivityGroupItem.GroupConnectivity = this.GroupConnectivity;
            }
            else
            {
                psConnectivityGroupItem.GroupConnectivity = "None";
            }

            if (this.IsGlobal)
            {
                psConnectivityGroupItem.IsGlobal = "True";
            }
            else
            {
                psConnectivityGroupItem.IsGlobal = "False";
            }
            
            WriteObject(psConnectivityGroupItem);
        }
    }
}
