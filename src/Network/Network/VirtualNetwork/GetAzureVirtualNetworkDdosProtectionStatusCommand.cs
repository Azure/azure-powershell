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

using AutoMapper;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using CNM = Microsoft.Azure.Commands.Network.Models;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkDdosProtectionStatus"), OutputType(typeof(PSPublicIpDdosProtectionStatusResult))]
    public class GetAzureVirtualNetworkDdosProtectionStatusCommand : VirtualNetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "TestByResource",
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The virtualNetwork name")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SkipToken.")]
        public string SkipToken { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of Results returned")]
        public int Top { get; set; }


        public override void Execute()
        {
            base.Execute();

            List<PSPublicIpDdosProtectionStatusResult> result = null;

            if (string.Equals(ParameterSetName, "TestByResource"))
            {
                result = this.ListDdosProtectionStatus(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, this.SkipToken, this.Top);
            }
            else
            {
                result = this.ListDdosProtectionStatus(this.ResourceGroupName, this.VirtualNetworkName, this.SkipToken, this.Top);
            }

            WriteObject(result, true);
        }

        public List<PSPublicIpDdosProtectionStatusResult> ListDdosProtectionStatus(string resourceGroupName, string vnetName, string skipToken, int top)
        {
            var vList = this.NetworkClient.NetworkManagementClient.VirtualNetworks.ListDdosProtectionStatus(resourceGroupName, vnetName, top, skipToken);
            var vnetUsageList = new List<PSPublicIpDdosProtectionStatusResult>();
            foreach (var pip in vList)
            {
                var vVirtualNetworkModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSPublicIpDdosProtectionStatusResult>(pip);
                vnetUsageList.Add(vVirtualNetworkModel);
            }

            return vnetUsageList;
        }
    }
}
