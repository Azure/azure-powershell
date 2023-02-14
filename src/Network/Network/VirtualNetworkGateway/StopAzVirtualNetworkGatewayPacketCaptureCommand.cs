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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayPacketCapture",
        DefaultParameterSetName = "ByName", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGatewayPacketCaptureResult))]
    public class StopAzVirtualNetworkGatewayPacketCaptureCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualNetworkGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway name where packet capture to be started.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualNetworkGateway")]
        [Parameter(
            ParameterSetName = "ByInputObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VirtualNetworkGateway where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SAS URL packet capture on virtual network gateway.")]
        public string SasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSVirtualNetworkGateway existingVirtualNetworkGateway = null;
            if (ParameterSetName.Equals("ByInputObject"))
            {
                existingVirtualNetworkGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals("ByResourceId"))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);
            }

            if (existingVirtualNetworkGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, "Virtual Network Gateway");
            }

            VpnPacketCaptureStopParameters parameters = new VpnPacketCaptureStopParameters();
            if (this.SasUrl != null)
            {
                parameters.SasUrl = SasUrl;
            }

            base.Execute();
            if (ShouldProcess(this.Name, String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name)))
            {
                WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                PSVirtualNetworkGatewayPacketCaptureResult output = new PSVirtualNetworkGatewayPacketCaptureResult()
                {
                    Name = existingVirtualNetworkGateway.Name,
                    ResourceGroupName = existingVirtualNetworkGateway.ResourceGroupName,
                    Tag = existingVirtualNetworkGateway.Tag,
                    ResourceGuid = existingVirtualNetworkGateway.ResourceGuid,
                    Location = existingVirtualNetworkGateway.Location,
                };
                output.StartTime = DateTime.UtcNow;
                var result = this.VirtualNetworkGatewayClient.StopPacketCapture(this.ResourceGroupName, this.Name, parameters);
                output.EndTime = DateTime.UtcNow;
                WriteObject(output);
            }
        }
    }
}
