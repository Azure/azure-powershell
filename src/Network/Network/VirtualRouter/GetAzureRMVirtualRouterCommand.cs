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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", DefaultParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName), OutputType(typeof(PSVirtualRouter))]
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
        [ResourceIdCompleter("Microsoft.Network/virtualRouters")]
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

            if (ShouldGetByName(ResourceGroupName, RouterName))
            {
                var vVirtualRouter = this.NetworkClient.NetworkManagementClient.VirtualRouters.Get(ResourceGroupName, RouterName);
                var vVirtualRouterModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualRouter>(vVirtualRouter);
                vVirtualRouterModel.ResourceGroupName = this.ResourceGroupName;
                vVirtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(vVirtualRouter.Tags);
                AddPeeringsToPSVirtualRouter(vVirtualRouter, vVirtualRouterModel, ResourceGroupName, RouterName);
                WriteObject(vVirtualRouterModel, true);
            }
            else
            {
                IPage<VirtualRouter> vVirtualRouterPage;
                if(ShouldListByResourceGroup(ResourceGroupName, RouterName))
                {
                    vVirtualRouterPage = this.NetworkClient.NetworkManagementClient.VirtualRouters.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    vVirtualRouterPage = this.NetworkClient.NetworkManagementClient.VirtualRouters.List();
                }

                var vVirtualRouterList = ListNextLink<VirtualRouter>.GetAllResourcesByPollingNextLink(vVirtualRouterPage,
                    this.NetworkClient.NetworkManagementClient.VirtualRouters.ListNext);
                List<PSVirtualRouter> psVirtualRouterList = new List<PSVirtualRouter>();
                foreach (var vVirtualRouter in vVirtualRouterList)
                {
                    RouterName = vVirtualRouter.Name;
                    var vVirtualRouterModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualRouter>(vVirtualRouter);
                    vVirtualRouterModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vVirtualRouter.Id);
                    vVirtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(vVirtualRouter.Tags);
                    AddPeeringsToPSVirtualRouter(vVirtualRouter, vVirtualRouterModel, ResourceGroupName, RouterName);

                    psVirtualRouterList.Add(vVirtualRouterModel);
                }
                WriteObject(psVirtualRouterList, true);
            }
        }
    }
}
