//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network.Models;

    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualHubBgpConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName),
        OutputType(typeof(PSBgpConnection))]
    public class GetAzVirtualHubBgpConnectionCommand : HubBgpConnectionBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentResourceName", "ParentVirtualHubName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string VirtualHubName { get; set; }

        [Alias("ResourceName", "BgpConnectionName")]
        [Parameter(Mandatory = false,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs/bgpConnections", "ResourceGroupName", "VirtualHubName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ParentObject", "ParentVirtualHub")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject)]
        [ValidateNotNull]
        public PSVirtualHub VirtualHub { get; set; }

        [Alias("BgpConnectionId")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId)]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHub.Name;
                this.ResourceGroupName = this.VirtualHub.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByHubBgpConnectionResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.VirtualHubName = parsedResourceId.ParentResource.Split('/').Last();
                this.Name = parsedResourceId.ResourceName;
            }

            if (this.ShouldGetByName(ResourceGroupName, this.Name))
            {
                this.WriteObject(this.GetVirtualHubBgpConnection(this.ResourceGroupName, this.VirtualHubName, this.Name));
            }
            else
            {
                this.WriteObject(this.ListVirtualHubBgpConnections(this.ResourceGroupName, this.VirtualHubName, this.Name), true);
            }
        }
    }
}
