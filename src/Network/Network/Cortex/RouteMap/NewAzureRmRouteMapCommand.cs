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

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMap",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMap))]
    public class NewAzureRmRouteMapCommand : RouteMapBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVirtualHubName", "ParentResourceName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        public string VirtualHubName { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent resource.")]
        public PSVirtualHub VirtualHubObject { get; set; }

        [Alias("VirtualHubId", "ParentVirtualHubId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The parent resource.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubResourceId { get; set; }

        [Alias("ResourceName", "RouteMapName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the route map resource.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of route map rules for this route map resource.")]
        public PSRouteMapRule[] RouteMapRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.VirtualHubObject.ResourceGroupName;
                this.VirtualHubName = this.VirtualHubObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.VirtualHubName = parsedResourceId.ResourceName;
            }

            // this will thorw if hub does not exist.
            IsParentVirtualHubPresent(this.ResourceGroupName, this.VirtualHubName);

            PSRouteMap routeMap = new PSRouteMap
            {
                Name = this.Name,
                Rules = this.RouteMapRule.ToList()
            };

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateRouteMap(this.ResourceGroupName, this.VirtualHubName, this.Name, routeMap));
                });
        }
    }
}
