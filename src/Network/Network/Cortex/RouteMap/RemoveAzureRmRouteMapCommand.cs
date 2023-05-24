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
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMap",
        DefaultParameterSetName = CortexParameterSetNames.ByRouteMapName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmRouteMapCommand : RouteMapBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVirtualHubName", "ParentResourceName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "The resource group name.")]
        public string VirtualHubName { get; set; }

        [Alias("ResourceName", "RouteMapName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "Name of the route map resource.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "Name of the route map resource.")]
        public string Name { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent virtual hub object.")]
        public PSVirtualHub VirtualHubObject { get; set; }

        [Alias("RouteMap")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapObject,
            HelpMessage = "The route map resource to delete.")]
        public PSRouteMap InputObject { get; set; }

        [Alias("RouteMapId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapResourceId,
            HelpMessage = "The resource id of the Route Map to delete.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/routeMaps")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSRouteMap routeMapToDelete = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByRouteMapObject, StringComparison.OrdinalIgnoreCase))
            {
                routeMapToDelete = this.InputObject;
                this.ResourceId = this.InputObject.Id;
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.RouteMapNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.VirtualHubName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByRouteMapResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.VirtualHubName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    this.Name = parsedResourceId.ResourceName;
                }
                else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
                {
                    var parentResourceId = this.VirtualHubObject.Id;
                    var parsedParentResourceId = new ResourceIdentifier(parentResourceId);
                    this.ResourceGroupName = parsedParentResourceId.ResourceGroupName;
                    this.VirtualHubName = parsedParentResourceId.ResourceName;
                }
            }

            // this will thorw if hub does not exist.
            IsParentVirtualHubPresent(this.ResourceGroupName, this.VirtualHubName);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemoveRouteMapWarning),
                Properties.Resources.RemoveResourceMessage,
                this.Name,
                () =>
                {
                    RouteMapClient.Delete(this.ResourceGroupName, this.VirtualHubName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
