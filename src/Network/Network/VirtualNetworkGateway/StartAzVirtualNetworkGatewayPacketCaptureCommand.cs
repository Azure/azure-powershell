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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualnetworkGatewayPacketCapture", 
        DefaultParameterSetName = "ByVirtualNetworkGatewayName", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGatewayPacketCaptureResult))]
    public class StartAzVirtualNetworkGatewayPacketCaptureCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualNetworkGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway name where packet capture to be started.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualNetworkGateway")]
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VirtualNetworkGateway where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Filter options for start packet capture on virtual network gateway.")]
        public string PacketCaptureParameters { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSVirtualNetworkGateway existingVirtualNetworkGateway = null;
            if (ParameterSetName.Equals("ByVirtualNetworkGatewayObject"))
            {
                existingVirtualNetworkGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals("ByVirtualNetworkGatewayResourceId"))
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

            VpnPacketCaptureStartParameters parameters = new VpnPacketCaptureStartParameters();
            if (this.PacketCaptureParameters != null)
            {
                parameters.FilterData = PacketCaptureParameters;
            }

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    var result = this.VirtualNetworkGatewayClient.StartPacketCapture(this.ResourceGroupName, this.Name, parameters);
                    VpnGatewayPacketCaptureResponse resultObj = JsonConvert.DeserializeObject<VpnGatewayPacketCaptureResponse>(result);

                    PSVirtualNetworkGatewayPacketCaptureResult output = new PSVirtualNetworkGatewayPacketCaptureResult
                    {
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now
                    };

                    output.Code = resultObj.Status;
                    output.ResultsText = resultObj.Data;

                    WriteObject(output);
                });
        }
    }
}
