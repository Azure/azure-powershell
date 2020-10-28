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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Reset",
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2sVpnGateway",
    DefaultParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
    SupportsShouldProcess = true),
    OutputType(typeof(PSP2SVpnGateway))]
    public class ResetAzureP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The p2s vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/p2sVpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("P2SVpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The p2s vpn gateway to reset")]
        [ValidateNotNullOrEmpty]
        public PSP2SVpnGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to reset.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSP2SVpnGateway existingVpnGateway = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayObject))
            {
                existingVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.P2SVpnGatewayNotFound);
            }

            string shouldProcessMessage = string.Format("Execute {0}P2sVpnGateway for ResourceGroupName {1} P2SVpnGateway {2}", ResourceManager.Common.AzureRMConstants.AzureRMPrefix, this.ResourceGroupName, this.Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Reset))
            {
                this.P2SVpnGatewayClient.Reset(this.ResourceGroupName, this.Name);

                var getVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);
                WriteObject(getVpnGateway);
            }
        }
    }
}
