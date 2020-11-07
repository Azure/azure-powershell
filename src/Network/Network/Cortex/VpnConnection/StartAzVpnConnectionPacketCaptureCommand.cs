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
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Network.Models.Cortex;
using System.Linq;

namespace Microsoft.Azure.Commands.Network.Cortex.VpnConnection
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnConnectionPacketCapture",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnConnectionName
        , SupportsShouldProcess = true)
        , OutputType(typeof(PSVpnConnectionPacketCaptureResult))]
    public class StartAzVpnConnectionPacketCaptureCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            HelpMessage = "The parent Vpn Gateway resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "VpnConnectionName", "ConnectionName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            Mandatory = true,
            HelpMessage = "The Vpn connection name where packet capture to be started.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways/vpnConnections", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnConnection")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Vpn connection object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVpnConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VpnConnection where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Filter options for start packet capture on Vpn connection.")]
        public string FilterData { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "VpnSiteLink Name of Vpn Connection to  start packet capture on Vpn connection.")]
        public string LinkConnectionName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnConnectionName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.VpnConnectionNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the vpngateway object - this will throw not found if the object is not found
            PSVpnGateway parentGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);

            if (parentGateway == null ||
                parentGateway.Connections == null ||
                !parentGateway.Connections.Any(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.VpnConnectionNotFound);
            }

            var existingConnection = parentGateway.Connections.FirstOrDefault(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));

            VpnConnectionPacketCaptureStartParameters parameters = new VpnConnectionPacketCaptureStartParameters();

            if (this.FilterData != null)
            {
                parameters.FilterData = FilterData;
            }

            if (this.LinkConnectionName != null)
            {
                parameters.LinkConnectionNames = LinkConnectionName.Split(',').Select(x => x.Trim()).ToList();
            }

            base.Execute();

            if (ShouldProcess(this.Name, String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name)))
            {
                WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                PSVpnConnectionPacketCaptureResult output = new PSVpnConnectionPacketCaptureResult()
                {
                    Name = existingConnection.Name,
                    ResourceGroupName = parentGateway.ResourceGroupName,
                    Tag = parentGateway.Tag,
                    ResourceGuid = existingConnection.Id,
                    Location = parentGateway.Location,
                    LinkConnectionName = this.LinkConnectionName
                };
                output.StartTime = DateTime.UtcNow;
                var result = this.VpnConnectionClient.StartPacketCapture(this.ResourceGroupName, ParentResourceName, this.Name, parameters);
                output.EndTime = DateTime.UtcNow;
                WriteObject(output);
            }
        }
    }
}