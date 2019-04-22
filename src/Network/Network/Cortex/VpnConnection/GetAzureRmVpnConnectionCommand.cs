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

namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName),
        OutputType(typeof(PSVpnConnection))]
    public class GetAzureRmVpnConnectionCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ParentVpnGateway", "VpnGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            HelpMessage = "The parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway ParentObject { get; set; }

        [Alias("ParentVpnGatewayId", "VpnGatewayId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            HelpMessage = "The resource id of the parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnGateways")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "VpnConnectionName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways/vpnConnections", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                WriteObject(this.GetVpnConnection(this.ResourceGroupName, this.ParentResourceName, this.Name));
            }
            else
            {
                WriteObject(SubResourceWildcardFilter(Name, this.ListVpnConnections(this.ResourceGroupName, this.ParentResourceName)), true);
            }
        }
    }
}
