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
    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Add,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubRoute",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName),
        OutputType(typeof(PSVirtualHubRouteTable))]
    public class AddAzureRmVirtualHubRouteCommand : VirtualHubRouteTableBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        public string HubName { get; set; }

        [Alias("VirtualHubRouteTableName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The virtualhubroutetable name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs/routeTables", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string RouteTableName { get; set; }

        [Alias("VirtualHubRouteTable")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableObject,
            HelpMessage = "The virtualhubroutetable resource.")]
        public PSVirtualHubRouteTable RouteTable { get; set; }

        [Alias("VirtualHubRoute")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableObject,
           HelpMessage = "The virtualhubroute resource.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
           HelpMessage = "The virtualhubroute resource.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHubRoute InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            // Resolve the parameters
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubRouteTableObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.RouteTable.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.HubName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.RouteTableName = parsedResourceId.ResourceName;
            }

            base.Execute();

            var route = new PSVirtualHubRoute
            {
                Destinations = this.InputObject.Destinations,
                DestinationType = this.InputObject.DestinationType,
                NextHops = this.InputObject.NextHops,
                NextHopType = this.InputObject.NextHopType
            };

            this.RouteTable.Routes.Add(route);

            WriteObject(this.RouteTable);
        }
    }
}
