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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Get-AzRouteServer")]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", DefaultParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterSubscriptionId), OutputType(typeof(PSVirtualRouter))]
    public partial class GetAzureRmVirtualRouter : VirtualRouterBaseCmdlet
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
            Mandatory = false,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RouterName { get; set; }

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
                ResourceGroupName = resourceInfo.ResourceGroupName;
                RouterName = resourceInfo.ResourceName;
            }

            string ipConfigName = "ipconfig1";
            if (ShouldGetByName(ResourceGroupName, RouterName))
            {
                var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, RouterName);
                var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                virtualHubModel.ResourceGroupName = this.ResourceGroupName;
                virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                AddBgpConnectionsToPSVirtualHub(virtualHub, virtualHubModel, ResourceGroupName, RouterName);
                AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, RouterName, ipConfigName);

                var virtualRouterModel = new PSVirtualRouter(virtualHubModel);
                virtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                WriteObject(virtualRouterModel, true);
            }
            else
            {
                IPage<VirtualHub> virtualHubPage;
                if (ShouldListByResourceGroup(ResourceGroupName, RouterName))
                {
                    virtualHubPage = this.NetworkClient.NetworkManagementClient.VirtualHubs.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    virtualHubPage = this.NetworkClient.NetworkManagementClient.VirtualHubs.List();
                }

                var virtualHubList = ListNextLink<VirtualHub>.GetAllResourcesByPollingNextLink(virtualHubPage,
                    this.NetworkClient.NetworkManagementClient.VirtualHubs.ListNext);
                List<PSVirtualRouter> virtualRouterList = new List<PSVirtualRouter>();
                foreach (var virtualHub in virtualHubList)
                {
                    RouterName = virtualHub.Name;
                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                    virtualHubModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(virtualHub.Id);
                    virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    AddBgpConnectionsToPSVirtualHub(virtualHub, virtualHubModel, ResourceGroupName, RouterName);
                    AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, RouterName, ipConfigName);

                    var virtualRouterModel = new PSVirtualRouter(virtualHubModel);
                    virtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    virtualRouterList.Add(virtualRouterModel);
                }
                WriteObject(virtualRouterList, true);
            }
        }
    }
}