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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServer", SupportsShouldProcess = true, DefaultParameterSetName = RouteServerParameterSetNames.ByRouteServerName), OutputType(typeof(PSRouteServer))]
    public partial class UpdateAzureRmRouteServer : RouteServerBaseCmdlet
    {
        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            Mandatory = true,
            HelpMessage = "The name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RouteServerName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            HelpMessage = "Flag to allow branch to branch traffic for route server.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerResourceId,
            HelpMessage = "Flag to allow branch to branch traffic for route server.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowBranchToBranchTraffic { get; set; }

        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, RouteServerParameterSetNames.ByRouteServerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.RouteServerName = resourceInfo.ResourceName;
            }

            string ipConfigName = "ipconfig1";

            var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, RouteServerName);
            virtualHub.AllowBranchToBranchTraffic = this.AllowBranchToBranchTraffic.IsPresent;
            this.NetworkClient.NetworkManagementClient.VirtualHubs.CreateOrUpdate(this.ResourceGroupName, this.RouteServerName, virtualHub);

            var psVirtualHub = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
            psVirtualHub.ResourceGroupName = this.ResourceGroupName;
            psVirtualHub.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
            AddBgpConnectionsToPSVirtualHub(psVirtualHub, ResourceGroupName, RouteServerName);
            AddIpConfigurtaionToPSVirtualHub(psVirtualHub, this.ResourceGroupName, RouteServerName, ipConfigName);

            var routeServerModel = new PSRouteServer(psVirtualHub);
            routeServerModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
            WriteObject(routeServerModel, true);
        }
    }
}