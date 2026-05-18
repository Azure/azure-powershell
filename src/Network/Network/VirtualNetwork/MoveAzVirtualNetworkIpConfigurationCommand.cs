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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Move", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkIpConfiguration",
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class MoveAzVirtualNetworkIpConfigurationCommand : VirtualNetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworks", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of IP configuration move items. Each item should specify the source and target IP configuration resource IDs.")]
        [ValidateNotNullOrEmpty]
        public PSMoveIpConfigurationItem[] MoveIpConfigurationItem { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Returns an object representing the item with which you are working. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Build SDK request from PS model
            var moveItems = new List<MoveIpConfigurationItem>();
            foreach (var item in this.MoveIpConfigurationItem)
            {
                moveItems.Add(new MoveIpConfigurationItem(
                    sourceIpConfiguration: new SubResource(item.SourceIpConfigurationId),
                    targetIpConfiguration: new SubResource(item.TargetIpConfigurationId)));
            }

            var parameters = new MoveIpConfigurationsRequest(moveItems);

            string shouldProcessMessage = string.Format(
                "Execute Move-AzVirtualNetworkIpConfiguration on VirtualNetwork '{0}' in ResourceGroup '{1}' with {2} item(s)",
                this.VirtualNetworkName,
                this.ResourceGroupName,
                this.MoveIpConfigurationItem.Length);

            if (ShouldProcess(shouldProcessMessage, "Move-AzVirtualNetworkIpConfiguration"))
            {
                this.VirtualNetworkClient.MoveIpConfigurations(
                    this.ResourceGroupName,
                    this.VirtualNetworkName,
                    parameters);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
