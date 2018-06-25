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
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set,
         "AzureRmVpnClientIpsecParameter",
         DefaultParameterSetName = "ByFactoryName",
         SupportsShouldProcess = true),
     OutputType(typeof(PSVpnClientIPsecParameters))]
    public class SetAzureVpnClientIpsecParametersCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The virtual network gateway name.")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Vpn client ipsec parameters")]
        [ValidateNotNull]
        public PSVpnClientIPsecParameters VpnClientIPsecParameter { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateaway object")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
            {
                VirtualNetworkGatewayName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VirtualNetworkGatewayName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            if (!this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vpnClientIPsecParametersModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnClientIPsecParameters>(this.VpnClientIPsecParameter);

            string shouldProcessMessage = string.Format("Execute Set-AzureRmVpnClientIpsecParameters for ResourceGroupName {0} VirtualNetworkGateway {1}", this.ResourceGroupName, this.VirtualNetworkGatewayName);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Set))
            {
                var vpnClientIpsecParameters = this.VirtualNetworkGatewayClient.SetVpnclientIpsecParameters(this.ResourceGroupName, this.VirtualNetworkGatewayName, vpnClientIPsecParametersModel);
                var psVpnClientIPsecParameters = NetworkResourceManagerProfile.Mapper.Map<PSVpnClientIPsecParameters>(vpnClientIpsecParameters);

                WriteObject(vpnClientIpsecParameters);
            }
        }
    }
}