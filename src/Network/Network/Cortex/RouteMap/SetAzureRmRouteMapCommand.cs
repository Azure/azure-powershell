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

    [Cmdlet("Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMap",
        DefaultParameterSetName = CortexParameterSetNames.ByRouteMapName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMap))]
    public class SetAzureRmRouteMapCommand : RouteMapBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "The resource group name.")]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "RouteMapName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapName,
            HelpMessage = "Name of the route table.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "Name of the route table.")]
        public string Name { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent virtual hub object.")]
        public PSVirtualHub ParentObject { get; set; }

        [Alias("RouteMap")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapObject,
            HelpMessage = "The route map resource to modify.")]
        public PSRouteMap InputObject { get; set; }

        [Alias("RouteMapId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByRouteMapResourceId,
            HelpMessage = "The resource id of the route map to modify.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/routeMaps")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of route map rules for this route map resource.")]
        public PSRouteMapRule[] RouteMapRules { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSRouteMap routeMapToUpdate = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByRouteMapObject, StringComparison.OrdinalIgnoreCase))
            {
                routeMapToUpdate = this.InputObject;
                this.ResourceId = this.InputObject.Id;
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.RouteMapNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByRouteMapResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    this.Name = parsedResourceId.ResourceName;
                }
                else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
                {
                    var parentResourceId = this.ParentObject.Id;
                    var parsedParentResourceId = new ResourceIdentifier(parentResourceId);
                    this.ResourceGroupName = parsedParentResourceId.ResourceGroupName;
                    this.ParentResourceName = parsedParentResourceId.ResourceName;
                }

                try
                {
                    routeMapToUpdate = this.GetRouteMap(this.ResourceGroupName, this.ParentResourceName, this.Name);
                }
                catch (Exception ex)
                {
                    if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                    {
                        throw new PSArgumentException(Properties.Resources.RouteMapNotFound);
                    }
                    throw;
                }
            }

            // this will thorw if hub does not exist.
            IsParentVirtualHubPresent(this.ResourceGroupName, this.ParentResourceName);

            if (this.RouteMapRules != null)
            {
                routeMapToUpdate.Rules = this.RouteMapRules.ToList();
            }

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateRouteMap(this.ResourceGroupName, this.ParentResourceName, this.Name, routeMapToUpdate));
                });
        }
    }
}
