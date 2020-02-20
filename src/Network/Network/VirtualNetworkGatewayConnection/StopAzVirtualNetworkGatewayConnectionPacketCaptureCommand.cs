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
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayConnectionPacketCapture",
        DefaultParameterSetName = "ByName", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGatewayPacketCaptureResult))]
    public class StopAzVirtualNetworkGatewayConnectionPacketCaptureCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ConnectionName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway connection name where packet capture is to be started.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualNetworkGatewayConnection")]
        [Parameter(
            ParameterSetName = "ByInputObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway connection object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGatewayConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VirtualNetworkGatewayConnection where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SAS Url for stop packet capture on virtual network gateway.")]
        public string SasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSVirtualNetworkGatewayConnection existingConnection = null;
            if (ParameterSetName.Equals("ByInputObject"))
            {
                existingConnection = InputObject;
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

                existingConnection = this.GetVirtualNetworkGatewayConnection(this.ResourceGroupName, this.Name);
            }

            if (existingConnection == null)
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, "Virtual Network Gateway connection");
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
                PSVirtualNetworkGatewayConnectionPacketCaptureResult output = new PSVirtualNetworkGatewayConnectionPacketCaptureResult()
                {
                    Name = existingConnection.Name,
                    ResourceGroupName = existingConnection.ResourceGroupName,
                    Tag = existingConnection.Tag,
                    ResourceGuid = existingConnection.ResourceGuid,
                    Location = existingConnection.Location,
                };
                output.StartTime = DateTime.UtcNow;
                var result = this.VirtualNetworkGatewayConnectionClient.StopPacketCapture(this.ResourceGroupName, this.Name, parameters);
                output.EndTime = DateTime.UtcNow;
                WriteObject(output);
            }
        }
    }
}
