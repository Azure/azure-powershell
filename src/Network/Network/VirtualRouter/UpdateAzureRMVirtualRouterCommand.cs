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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Update-AzRouteServer")]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName), OutputType(typeof(PSVirtualRouter))]
    public partial class UpdateAzureRmVirtualRouter : VirtualRouterBaseCmdlet
    {
        [Parameter(
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName,
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName,
            Mandatory = true,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RouterName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName,
            HelpMessage = "Flag to allow branch to branch traffic for virtual router.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterResourceId,
            HelpMessage = "Flag to allow branch to branch traffic for virtual router.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowBranchToBranchTraffic { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, VirtualRouterParameterSetNames.ByVirtualRouterResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.RouterName = resourceInfo.ResourceName;
            }

            string ipConfigName = "ipconfig1";

            var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, RouterName);
            virtualHub.AllowBranchToBranchTraffic = this.AllowBranchToBranchTraffic.IsPresent;
            this.NetworkClient.NetworkManagementClient.VirtualHubs.CreateOrUpdate(this.ResourceGroupName, this.RouterName, virtualHub);

            var psVirtualHub = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
            psVirtualHub.ResourceGroupName = this.ResourceGroupName;
            psVirtualHub.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
            AddBgpConnectionsToPSVirtualHub(virtualHub, psVirtualHub, ResourceGroupName, RouterName);
            AddIpConfigurtaionToPSVirtualHub(psVirtualHub, this.ResourceGroupName, RouterName, ipConfigName);

            var psVirtualRouter = new PSVirtualRouter(psVirtualHub);
            psVirtualRouter.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
            WriteObject(psVirtualRouter, true);
        }
    }
}