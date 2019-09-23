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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayConnectionPacketCapture",
        DefaultParameterSetName = "ByVirtualNetworkGatewayConnectionName", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGatewayPacketCaptureResult))]
    public class StopAzVirtualNetworkGatewayConnectionPacketCaptureCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayConnectionName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ByVirtualNetworkGatewayConnectionName", "ConnectionName")]
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayConnectionName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway connection name where packet capture to be started.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualNetworkGatewayConnection")]
        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayConnectionObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway connection object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGatewayConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByVirtualNetworkGatewayConnectionResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VirtualNetworkGatewayConnection where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SAS Url for stop packet capture on virtual network gateway.")]
        public string PacketCaptureParameters { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSVirtualNetworkGatewayConnection existingConnection = null;
            if (ParameterSetName.Equals("ByVirtualNetworkGatewayConnectionObject"))
            {
                existingConnection = InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals("ByVirtualNetworkGatewayConnectionResourceId"))
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
            if (this.PacketCaptureParameters != null)
            {
                parameters.SasUrl = PacketCaptureParameters;
            }

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    var result = this.VirtualNetworkGatewayConnectionClient.StopPacketCapture(this.ResourceGroupName, this.Name, parameters);
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
