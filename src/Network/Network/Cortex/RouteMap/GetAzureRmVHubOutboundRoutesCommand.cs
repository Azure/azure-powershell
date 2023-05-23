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
    using Microsoft.Azure.Commands.Common.Strategies;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VHubOutboundRoute",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName),
        OutputType(typeof(PSVirtualHubEffectiveRouteMapRouteList))]
    public class GetAzureRmVHubOutboundRoutesCommand : VirtualHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVirtualHubName", "ParentResourceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        public string VirtualHubName { get; set; }

        [Alias("ParentObject", "ParentVirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent resource.")]
        public PSVirtualHub VirtualHubObject { get; set; }

        [Alias("VirtualHubId", "ParentVirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The parent resource id.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Resource Uri of the connection that inbound routes are being requested.")]
        [ValidateNotNullOrEmpty]
        public string ResourceUri { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "VirtualWan Connection Type of the specified connection like VpnConnection, ExpressRouteConnection.")]
        [ValidateNotNullOrEmpty]
        public string VirtualWanConnectionType { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHubObject.Name;
                this.ResourceGroupName = this.VirtualHubObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubResourceId);
                this.VirtualHubName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            GetOutboundRoutesParameters outboundRoutesParameters = new GetOutboundRoutesParameters()
            {
                ResourceUri = this.ResourceUri,
                ConnectionType = this.VirtualWanConnectionType
            };

            WriteObject(GetVirtualHubOutboundRoutes(ResourceGroupName, VirtualHubName, outboundRoutesParameters));
        }
    }
}
