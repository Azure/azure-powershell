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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet("Disconnect",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnGatewayVpnConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName, 
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnGateway))]
    public class DisconnectAzureP2SVpnGatewayVpnConnectionCommand : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName, 
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/p2sVpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/p2sVpnGateways")]
        public string ResourceId { get; set; }

        [Alias("P2SVpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The P2S vpn gateway object")]
        [ValidateNotNullOrEmpty]
        public PSP2SVpnGateway InputObject { get; set; }
        
        [Parameter(
            Mandatory = true,
            HelpMessage = "P2S Vpn gateway gateway Vpn connection Id, which is returned by getting P2S Vpn gateway detailed connection health")]
        [ValidateNotNullOrEmpty] 
        public string[] VpnConnectionId { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSP2SVpnGateway existingP2SVpnGateway;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                existingP2SVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingP2SVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingP2SVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.P2SVpnGatewayNotFound);
            }

            var req = new P2SVpnConnectionRequest(new List<string>(VpnConnectionId));
            this.P2SVpnGatewayClient.DisconnectP2sVpnConnections(ResourceGroupName, Name, req);

            WriteObject(existingP2SVpnGateway);
        }
    }
}
